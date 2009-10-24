
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using System.Windows.Forms;
using MZCOMLib;

namespace FlightCheckingEmulator
{
	public class FlightPlanner
	{
		/* Basic Facts:
         * - Dictionary -
         * Each value in the collection is identified by key
         * keys are unique, not more than 1 key with the same name
         * - Use of Generics -
         * Prevent using cast when retrieving values
         * Prevent boxing and unboxing when adding / fetching item from collection
         * Check inserion of object in compile-time rather than on run-time
		 */
		Dictionary<String,Flight> flights;
		Graph<String,Flight> routes;
		MzObjClass schemeObj;
		
		public Graph<String,Flight> Routes {
			get { return routes; }
		}
		
		public Dictionary<String,Flight> Flights {
			get { return flights; }
		}
		
		public FlightPlanner()
		{
			try {
				//Read database from flights.txt and store as list of flight objects, indexed by unique flight no
                flights = ReadFlights("flights.txt");
                //Building a graph based on the flights read
				routes = BuildRoutes(flights);	

				//this.LoadScheme();
				
			}
			catch(FileNotFoundException e) {
				throw e;
			}
		}
		
		private void error(string s)
		{
			MessageBox.Show("scheme error: " + s);
		}
		
		/* Load scheme COM */
		private void LoadScheme()
		{
			schemeObj = new MzObjClass();
			schemeObj.SchemeError += new _IMzObjEvents_SchemeErrorEventHandler(error);
			
			/* Load procedures from CompareByCost.ss */
			StreamReader reader = new StreamReader("CompareByCost.ss");
			string content = reader.ReadToEnd();
			reader.Close();
			
			/* Evaluate the procedures */
            schemeObj.Eval(content);
		}
		
		/* Convert a path list into scheme representation */
		private string ToSchemeList(List<String> input)
		{
			string s = "(list ";
			foreach(String f in input)
			{
				string tmp = "(list ";
				tmp += "\"" + flights[f].ArrivalTime + "\"" + " ";
				tmp += "\"" + flights[f].DepartureTime + "\"" + " ";
				tmp += "\"";
					tmp += flights[f].ArrivalOnNextDay ? "1" : "0";
				tmp += "\"";
				tmp += ") ";
				s += tmp;
			}
			s += ") ";
			return s;
		}
		
		private int CompareByCostScheme(List<String> a, List<String> b)
		{
			if( schemeObj == null )
				throw new NullReferenceException("schemeObj is null.");
			
			/* Format input string to CompareByCost in scheme */
			string call = "(CompareByCost " + ToSchemeList(a) + ToSchemeList(b) + ")";
			
			/* Call CompareByCost and format the result string */
			string result = schemeObj.Eval(call);
			result = result.Trim(new Char[] {'"'});
			
			/* Convert result string to integer	and return */
			return Int32.Parse(result);
		}
	
		/* Compare two routes, return difference in cost */
		private int CompareByCost(List<String> a, List<String> b)
		{
			int diff;
            /* 1st case: if both route has no information, return 0, no difference */
			if(a == null && b == null)
				diff = 0;
             /* Note: 
              * b.Count is to count how many nodes in list (possible solution paths)
              * a.Count is to count how many nodes in list (another possible solution path)
              */
            /* 2nd case: if route a is null, return 0 - cost of route b */
			else if(a == null && b != null)
				diff = (- b.Count);
            /* 3rd case: if route b is null, return cost of route a */
			else if(a != null && b == null)
				diff = a.Count;
			else
			{
				/* 4th case: if both route cost is same meaning same route length to solution, compare the time */
                if(a.Count == b.Count)
				{
					/* Compare the total travel time */
					int tA = 0, tB = 0;
					Flight fA, fB;
					for(int i = 0; i < a.Count; i++)
					{
						/* a[i] will return a string and the string is passed to the hash table flights to get the flight object */
                        fA = flights[a[i]];
						fB = flights[b[i]];

                        /* Calculate the total time needed for a flight and add to total time */
						tA += fA.ArrivalTime - fA.DepartureTime;
                        /* if the flight arrival is on next day, add 24 hours */
						if( fA.ArrivalOnNextDay )
							tA += 24 * 60;
						
						tB += fB.ArrivalTime - fB.DepartureTime;
						if( fB.ArrivalOnNextDay )
							tB += 24 * 60;
					}
                    /* Finally, calculate the difference in time between these 2 flights in minutes */
					diff = tA - tB;
				}
				else
				{
					/* 5th case: if the route length for 2 routes are different, take the difference */
                    diff = a.Count - b.Count;
				}
			}
			
			return diff;
		}

        /* Compare two routes by the duration in plane, return difference in cost */
        private int CompareByInPlaneDuration(List<String> a, List<String> b)
        {
            int diff;

            int tA = 0, tB = 0;
            Flight fA, fB;
            if (a != null)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    /* a[i] will return a string and the string is passed to the hash table flights to get the flight object */
                    fA = flights[a[i]];

                    /* Calculate the total time needed for a flight and add to total time */
                    tA += fA.ArrivalTime - fA.DepartureTime;
                    /* if the flight arrival is on next day, add 24 hours */
                    if (fA.ArrivalOnNextDay)
                        tA += 24 * 60;
                }
            }

            if (b != null)
            {
                for (int i = 0; i < b.Count; i++)
                {
                    /* b[i] will return a string and the string is passed to the hash table flights to get the flight object */
                    fB = flights[b[i]];

                    /* Calculate the total time needed for a flight and add to total time */
                    tB += fB.ArrivalTime - fB.DepartureTime;
                    /* if the flight arrival is on next day, add 24 hours */
                    if (fB.ArrivalOnNextDay)
                        tB += 24 * 60;
                }
            }

            diff = tA - tB;

            return diff;
        }


        /* Compare two routes by the total duration of the trip, return difference in cost */
        private int CompareByTotalDuration(List<String> a, List<String> b)
        {
            int diff;

            int tA = 0, tB = 0, dA = 0, dB = 0;
            Flight fA, fB;

            int weekA = 0, depDayA = 0, arrDayA = 0;
            Time depA = new Time(0, 0);
            Time arrA = new Time(0, 0);
            if (a != null)
            {
                fA = flights[a[0]];
                for (int i = 0; i < 7; i++)
                {
                    if (fA.Days.Get(i))
                    {
                        dA = i;
                        depA = fA.DepartureTime;
                        depDayA = i;
                        if (fA.ArrivalOnNextDay)
                        {
                            dA++;
                            dA %= 7;
                        }
                        arrA = fA.ArrivalTime;
                        break;
                    }
                }
                for (int i = 0; i < a.Count; i++)
                {
                    /* a[i] will return a string and the string is passed to the hash table flights to get the flight object */
                    fA = flights[a[i]];

                    bool found = false;
                    for (int day = dA; day < 7; day++) if (fA.Days.Get(day))
                        if (day > dA || (day == dA && fA.DepartureTime >= arrA))
                        {
                            dA = day;
                            arrA = fA.ArrivalTime;
                            arrDayA = day;
                            if (fA.ArrivalOnNextDay)
                            {
                                arrDayA++; arrDayA %= 7;
                                dA++; dA %= 7;
                            }
                            found = true;
                            break;
                        }

                    if (!found)
                    {
                        for (int day = 0; day < 7; day++) if (fA.Days.Get(day))
                        {
                            dA = day;
                            weekA++;
                            arrDayA = day;
                            arrA = fA.ArrivalTime;
                            if (fA.ArrivalOnNextDay)
                            {
                                arrDayA++; arrDayA %= 7;
                                dA++; dA %= 7;
                            }
                            break;
                        }
                    }
                }

                tA = weekA * 7 * 24 * 60 + (arrDayA - depDayA) * 24 * 60 + (arrA - depA);
            }

            int weekB = 0, depDayB = 0, arrDayB = 0;
            Time depB = new Time(0, 0);
            Time arrB = new Time(0, 0);
            if (b != null)
            {
                fB = flights[b[0]];
                for (int i = 0; i < 7; i++)
                {
                    if (fB.Days.Get(i))
                    {
                        dB = i;
                        depB = fB.DepartureTime;
                        depDayB = i;
                        if (fB.ArrivalOnNextDay)
                        {
                            dB++;
                            dB %= 7;
                        }
                        arrB = fB.ArrivalTime;
                        break;
                    }
                }
                for (int i = 0; i < b.Count; i++)
                {
                    /* a[i] will return a string and the string is passed to the hash table flights to get the flight object */
                    fB = flights[b[i]];

                    bool found = false;
                    for (int day = dB; day < 7; day++) if (fB.Days.Get(day))
                            if (day > dB || (day == dB && fB.DepartureTime >= arrB))
                            {
                                dB = day;
                                arrB = fB.ArrivalTime;
                                arrDayB = day;
                                if (fB.ArrivalOnNextDay)
                                {
                                    arrDayB++; arrDayB %= 7;
                                    dB++; dB %= 7;
                                }
                                found = true;
                                break;
                            }

                    if (!found)
                    {
                        for (int day = 0; day < 7; day++) if (fB.Days.Get(day))
                            {
                                dB = day;
                                weekB++;
                                arrDayB = day;
                                arrB = fB.ArrivalTime;
                                if (fB.ArrivalOnNextDay)
                                {
                                    arrDayB++; arrDayB %= 7;
                                    dB++; dB %= 7;
                                }
                                break;
                            }
                    }
                }

                tB = weekB * 7 * 24 * 60 + (arrDayB - depDayB) * 24 * 60 + (arrB - depB);
            }

            diff = tA - tB;

            return diff;
        }
		
		/* Returns day of week index in BitArray representation */
		public int DayIndex(string s)
		{
			int i = -1;
			switch(s)
			{
					case "Alldays":		i = 0; break;
					case "Monday": 		i = 1; break;
					case "Tuesday": 	i = 2; break;
					case "Wednesday": 	i = 3; break;
					case "Thursday": 	i = 4; break;
					case "Friday": 		i = 5; break;
					case "Saturday": 	i = 6; break;
					case "Sunday": 		i = 7; break;
			}
			return i;
		}
		
		/* To make a clone of the path, so that it does not mess with the original data */
		private List<String> PathClone(List<String> path)
		{
			if( path == null )
				return null;
			
			List<String> newPath = new List<String>();
			for(int i = 0; i < path.Count; i++)
			{
				newPath.Add((string)path[i].Clone());
			}
			return newPath;
		}
		
        /*To remove the last node from the current path and make the necessary updates */
		private void RemoveLastVisit<T>(List<String> curPath,
		                                Dictionary<String,String> curVisited,
		                                Stack<T> daysTrack,
		                                out T days)
		{
			/* Remove the visited node based on the last node's destination of the current path
            * Since last node of the current path is removed, its destination can be marked as unvisited again through removal by the algorithm
            * The "destination" can be used by the algorithm to find possible routes 
            */
            curVisited.Remove(flights[curPath[curPath.Count - 1]].Destination);
            /* Remove the last node from the current path */
			curPath.RemoveAt(curPath.Count - 1);
            /* Update the days to consider the next flight */
			days = daysTrack.Pop();
		}
		
		/* To get the last flight object on the current path */
        private Flight GetLastFlight(List<String> path)
		{
			if( path == null )
				return null;
			
			return flights[path[path.Count - 1]];
		}
		
         /* To return a list of neighbours available based on the city name from the routes graph */
		private List<Flight> GetNeighboursOf(String city)
		{
			return routes.GetNode(city).Neighbours;
		}
		
		/* Basic Facts: BitArray
         * Used to maintain a compact array of bits values (1 and 0) that can be represented as booleans
         * The advance days will pass in the current days and shift the true/false or 0/1 to the next day
         */
		private BitArray AdvanceDays(BitArray days)
		{
			//Create an array of booleans and initalize to false
            BitArray newDays = new BitArray(days.Length, false);
            //Start from 1 instead, 0 is reserved for all days only
			for(int i = 1; i < days.Length; i++)
			{
				if( days[i] )
				{
                    //days.Length = 8, when i == 7 (Sunday), it will mark i = 1 as true (Monday)
                    if(i == days.Length - 1)
						newDays[1] = true;
                    //Mark next day as true
					else
						newDays[i+1] = true;
				}
			}
			return newDays;
		}
		
		/* Checks if next flight is applicable on arrival days
         * days = Possible arrival days 
         * nextflightdays = Departure days available for the next day
         * All flights arrivial and departure must be within the same day
         */
		private bool HasFlightOnArrivalDays(BitArray days, BitArray nextFlightDays)
		{
			bool hasFlight = false;
			for(int i = 1; i < days.Length; i++)
			{
				/* If there are common days that arrival and the departure falls on same day */
				if( days[i] && nextFlightDays[i] )
				{
					hasFlight = true;
					break;
				}
			}
			return hasFlight;
		}
		
		/* Checks if next flight is applicable on arrival days
         * days = Possible arrival days 
         * nextflightdays = Departure days available for the next day
         * All flights arrivial and departure must be within the same day
         */
		private bool HasFlightNotOnArrivalDays(BitArray days, BitArray nextFlightDays)
		{
			bool hasFlight = false;
			for(int i = 1; i < days.Length; i++)
			{
				/* if the day is not on the current arrival day but appears on the departure days */
				if( !days[i] && nextFlightDays[i] )
				{
					hasFlight = true;
					break;
				}
			}
			return hasFlight;
		}
		
		/* Checks if next flight is applicable NOT ON arrival days
         * Use to handle the visit plan Q3 where each day can only have 1 flight only
         */
		private bool IsNextFlightVisitable(BitArray days,
		                                   Flight curF,
		                                   Flight nextF,
		                                   FlightConstraint con)
		{
			bool isVisitable = false;
			/* if there is a departure flight on arrival day and both are on the same day */
			if( con.FlightOnArrivalDay )
			{
				/* Make sure the waiting time must be more than the threshold (60mins) to allow some time to board onto the next flight */
				if( nextF.DepartureTime - curF.ArrivalTime >= FlightConstraint.MinimumInterval)
					isVisitable = HasFlightOnArrivalDays(days, nextF.Days);
			}
			else
			{
				/* if the flight can be on different day excluding today (only 1 flight per day restriction) */
				isVisitable = HasFlightNotOnArrivalDays(days, nextF.Days);
			}
			return isVisitable;
		}
		
		/* Checks whether the path is synchronized with flight on top of stack */
		private bool IsPathSynchronized(List<String> curPath, Stack<Flight> stack)
		{
			/* Ensure that both curPath and stack must not be null before continue, else throw exception */
			if( curPath == null || stack == null )
				throw new ArgumentNullException();
			
			/* Either 1 is empty, it is still synchronized */
			if( curPath.Count == 0 || stack.Count == 0 )
				return true;
			
			/* Get the current location based on the last node of the current path's destination */
            string currentLocation = flights[curPath[curPath.Count - 1]].Destination;
            /* Peek into the top of the stack and determine where the flight came from */
			string nextFlightOrigin = stack.Peek().Origin;
			
			/* Return true if the current location's destination is equal to the next flight's origin */
			return (currentLocation == nextFlightOrigin);
		}
		
		private void DisplayDays(BitArray days, string s)
		{
			string d = "";
			for(int i = 1; i < 8; i++) {
				if( days[i] )
					d += "1";
				else
					d += "0";
			}
			
			MessageBox.Show(s + d);
		}
		/* CheckFlights returns all routes that fit the flight constraint
		 * Depth-first search with loop detection is used
		 */
		public List<List<String>> CheckFlights(FlightConstraint con, int sortOption)
		{
			List<List<String>> results = new List<List<String>>();
			
			/* if it is not a return trip and it is a single trip (example: SG fly to SG), return result */
			if( !con.IsReturnTrip && con.Origin == con.Destination )
				return results;
			
			Stack<Flight> stack = new Stack<Flight>();
			List<String> curPath = new List<String>();
			Dictionary<String,String> curVisited = new Dictionary<String,String>();
			
			/* Clone another copy for days */
			BitArray days = (BitArray)con.Days.Clone();
			/* Use to keep track the current available days */
			Stack<BitArray> daysTrack = new Stack<BitArray>();

			Node<String,Flight> originNode = routes.GetNode(con.Origin);
			/* Use to ensure the city names are unique keys by using dictionary and add the 1st node. */
			curVisited.Add(originNode.Value, null);
			
			/* Check constraints specifically for the 1st flights
			* Including: departure time & week days match 
			*/
			foreach(Flight nextFlight in originNode.Neighbours)
			{
				/* If the neighbours's departure time is within 24 hours after arrival
                * and there is flight on arrival days
                */
				if( con.TimeSlot.InSlot(nextFlight.DepartureTime)
				   && HasFlightOnArrivalDays(days, nextFlight.Days) )
				{
					/* to mark as possible place to visit but has not been visited yet */
                    stack.Push(nextFlight);
					// MessageBox.Show("stack.push " + nextFlight.FlightNo);
				}
			}

			/* Push the 1st flight's available days into stack */
			daysTrack.Push(days);

			while(stack.Count != 0)
			{
				/* Take the flight to destination */
				Flight curFlight = stack.Pop();
				// MessageBox.Show("stack.pop() = " + curFlight.FlightNo);
				
				/* Mark curFlight.Destination as visited */
				curVisited.Add(curFlight.Destination, null);
				
				/* Mask off the days that are not applicable */
				days = ((BitArray)curFlight.Days.Clone()).And(days);

				/* Keep track of available days */
				daysTrack.Push(days);
				
				/* Update curPath to track the path */
				curPath.Add(curFlight.FlightNo);
				
				/*
				string tmp = "current path: ";
				foreach(string s in curPath) {
					tmp += s + ", ";
				}
				tmp += "at " + curFlight.Destination + "\n";
				MessageBox.Show(tmp);
				 */
				
				if(curFlight.Destination == con.Destination)
				{
					// MessageBox.Show("path found! curPath count = " + curPath.Count);
					if( con.IsReturnTrip )
					{
						/* Return the path if return day constraint is satisfied */
						if( GetLastFlight(curPath).Days[con.ReturnDay] )
							results.Add( PathClone(curPath) );
					}
					else
					{
					/* if it does not require return trip back to origin, just add results */
						results.Add( PathClone(curPath) );
					}
					
					/* Perform path sychronization if necessary */
					goto PathSync;
				}
				
				if( con.DirectFlightOnly && curPath.Count >= 1 )
				{
					RemoveLastVisit(curPath, curVisited, daysTrack, out days);
					continue;
				}
				
				/* For every edge of the node (curFlight's destination)
				 * Push edge into stack iff the edge is accessible under constraints
				 */
				foreach(Flight nextFlight in GetNeighboursOf(curFlight.Destination))
				{
					if( curVisited.ContainsKey(nextFlight.Destination) )
					{
						/* Skip nextFlight if it does not lead to destination */
						if( nextFlight.Destination != con.Destination )
							continue;
						else
							curVisited.Remove(nextFlight.Destination);
					}
					
					/* Adjust current available days, since arriving on next day */
					if( curFlight.ArrivalOnNextDay )
					days = AdvanceDays(days);
				
					if( IsNextFlightVisitable(days, curFlight, nextFlight, con) )
					{
						stack.Push(nextFlight);
						// MessageBox.Show("stack.push " + nextFlight.FlightNo);
					}
				}
				
				PathSync:		while( curPath.Count > 0 && stack.Count > 0
				                 && !IsPathSynchronized(curPath, stack) )
				{
					RemoveLastVisit(curPath, curVisited, daysTrack, out days);
				}
			}
			/* Sort the results using Scheme */

            switch (sortOption)
            {
                case 0:
                    results.Sort(CompareByTotalDuration);
                    break;
                case 1:
                    results.Sort(CompareByCost);
                    break;
                case 2:
                    results.Sort(CompareByInPlaneDuration);
                    break;
            }
			
			return results;
		}
		
		/* Basic Fact
		 * int? is nullable where int allows null values 
		 */
		private int? DayCost(int curDay, BitArray nextFlightDays)
		{
			int? nextDay = null, diff = null;
			int start = curDay + 1;
			/* if the current day is sun(8) and next day is mon(1) */
			if(start == 8)
				start = 1;
			
			for(int i = start; ; )
			{
				/* if there is flight on the next days for the current start day */
				if( nextFlightDays[i] )
				{
					nextDay = i;
					break;
				}
				if(++i == 8)
					i = 1;
			}

			/* if the next day is smaller than the current day, add 7 days */
			diff = nextDay - curDay;
			if( diff < 0 )
				diff += 7;
			return diff;
		}
		
		public List<List<String>> WorldTravel(String origin,
		                                      String startOn,
		                                      out List<List<String>> seqs)
		{
			List<List<String>> results = new List<List<String>>();
			Stack<Flight> stack = new Stack<Flight>();
			List<String> curPath = new List<String>();
			Dictionary<String,String> curVisited = new Dictionary<String,String>();
			
			int curDay = DayIndex(startOn);
			Stack<int> daysTrack = new Stack<int>();

			Node<String,Flight> originNode = routes.GetNode(origin);
			curVisited.Add(originNode.Value, null);
			
			/* Check constraints specifically for the 1st flight
			* Including: week days match 
			*/
			foreach(Flight nextFlight in originNode.Neighbours)
			{
				if( nextFlight.Days[curDay] )
				{
					stack.Push(nextFlight);
					//MessageBox.Show("stack.push " + nextFlight.FlightNo);
				}
			}

			daysTrack.Push(curDay);

			while(stack.Count != 0)
			{
				/* Take the flight to destination */
				Flight curFlight = stack.Pop();
				// MessageBox.Show("stack.pop() = " + curFlight.FlightNo);
				
				/* Mark curFlight.Destination as visited */
				curVisited.Add(curFlight.Destination, null);

				/* Keep track of available days */
				daysTrack.Push(curDay);
				
				/* Update curPath to track the path */
				curPath.Add(curFlight.FlightNo);

				/* If all cities have been visited */
				if( curVisited.Count == routes.Count )
				{
					//MessageBox.Show("path found! curPath count = " + curPath.Count);
					List<String> resultPath = PathClone(curPath);
					results.Add( resultPath );

					/* Perform path sychronization if necessary */
					goto PathSync;
				}
				
				/* For every edge of the node (curFlight's destination)
				 * Push edge into stack iff the edge is accessible under constraints
				 */
				foreach(Flight nextFlight in GetNeighboursOf(curFlight.Destination))
				{
					if( curVisited.ContainsKey(nextFlight.Destination) )
					{
						/* Skip nextFlight if it leads to a visited city */
						continue;
					}
					
					/* Assume nextFlight is available at least 2 days/week */
					stack.Push(nextFlight);
				}
				
				PathSync:		while( curPath.Count > 0 && stack.Count > 0
				                 && !IsPathSynchronized(curPath, stack) )
				{
					RemoveLastVisit(curPath, curVisited, daysTrack, out curDay);
				}
			}
			
			seqs = GetUniqueSequences(results);
			
			results.Sort(CompareByCostScheme);
			
			return results;
		}
		
		/* To get unique sequences of the flight path such that no 2 paths are the same */
		private List<List<String>> GetUniqueSequences(List<List<String>> results)
		{
			List<List<String>> seqs = new List<List<String>>();
			foreach(List<String> s in results)
			{
				/* Convert flight path into city path */
				List<String> p = new List<String>();
				for(int i = 0; i < s.Count; i++)
				{
					p.Add(flights[s[i]].Origin);
					if(i == s.Count - 1)
						p.Add(flights[s[i]].Destination);
				}
				if( IsUniqueSequence(p, seqs) )
					seqs.Add(p);
			}
			return seqs;
		}
		
		/* Validate if the seq exists in the list of current unique sequences */
		private bool IsUniqueSequence(List<String> seq, List<List<String>> seqs)
		{
			bool isUnique = true;
			
			foreach(List<String> s in seqs)
			{
				bool same = true;
				for(int i = 0; i < s.Count; i++)
				{
					/* Found a sequence that is not the same */
					if(s[i] != seq[i])
					{
						same = false;
						break;
					}
				}
				/* The current sequence exists in the list of unique sequences */
				if( same )
				{
					isUnique = false;
					break;
				}
			}
			
			return isUnique;
		}
		
		/* Return the results of the plan based on the constraints */
		public List<List<String>> GetPlanResults(List<List<String>> results,
		                                         FlightConstraint con,
		                                         out List<List<String>> seqs)
		{
			List<List<String>> final = new List<List<String>>();
			seqs = new List<List<String>>();
			{
				bool[] flag;
				bool isQualified;
				foreach(List<String> path in results)
				{
					flag = new bool[] {false, false, false};
					List<string> seq = new List<string>();
					foreach(String s in path)
					{
						for(int i = 0; i < con.Places.Length; i++)
						{
							if(flights[s].Destination == con.Places[i])
							{
								flag[i] = true;
								seq.Add(con.Places[i]);
							}
						}
					}
					isQualified = true;
					for(int i = 0; i < flag.Length; i++)
					{
						if( !flag[i] )
						{
							isQualified = false;
							break;
						}
					}
					if( isQualified )
					{
						final.Add(path);
						if( IsUniqueSequence(seq, seqs) )
							seqs.Add(seq);
					}
				}
			}
			
			return final;
		}
		
		private Graph<String,Flight> BuildRoutes(Dictionary<String,Flight> flights) {
			Graph<String,Flight> routes = new Graph<String,Flight>();
			
			foreach(Flight f in flights.Values) {
				routes.AddNode(f.Origin);
				routes.AddNode(f.Destination);
				routes.AddEdge(f.Origin, f);
			}
			
			return routes;
		}
		
		public void NewFlights(string filename)
		{
			flights = ReadFlights(filename);
			routes = BuildRoutes(flights);
		}
		
		private Dictionary<String,Flight> ReadFlights(string filename) {
			Dictionary<String,Flight> flights = new Dictionary<String,Flight>(50);
			TextReader reader = null;
			
			try {
				reader = new StreamReader(filename);
				string[] tokens;
				Flight newFlight;
				char[] separator = {' ', ',', '\t'};
				
				while(reader.Peek() != -1) {
					tokens = reader.ReadLine().Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries);
					newFlight = new Flight();
					newFlight.Origin = tokens[0];
					newFlight.Destination = tokens[1];
					{
						string[] tmp = tokens[2].Split(new Char[]{':'});
						System.Console.WriteLine(tmp[0]);
						newFlight.DepartureTime = new Time(Int32.Parse(tmp[0]), Int32.Parse(tmp[1]));
					}
					{
						if(tokens[3].EndsWith("*")) {
							newFlight.ArrivalOnNextDay = true;
							tokens[3] = tokens[3].Remove(tokens[3].Length - 1);
						}
						string[] tmp = tokens[3].Split(new Char[]{':'});
						newFlight.ArrivalTime = new Time(Int32.Parse(tmp[0]), Int32.Parse(tmp[1]));
					}
					newFlight.FlightNo = tokens[4];
					if(tokens[5] == "Alldays") {
						newFlight.Days.SetAll(true);
					}
					else {
						for(int i = 5; i < tokens.Length; i++) {
							switch(tokens[i]) {
									case "Mo": newFlight.Days.Set(1, true); break;
									case "Tu": newFlight.Days.Set(2, true); break;
									case "We": newFlight.Days.Set(3, true); break;
									case "Th": newFlight.Days.Set(4, true); break;
									case "Fr": newFlight.Days.Set(5, true); break;
									case "Sa": newFlight.Days.Set(6, true); break;
									case "Su": newFlight.Days.Set(7, true); break;
									
									default: break;
							}
						}
					}
					flights.Add(newFlight.FlightNo, newFlight);
				}
				reader.Close();
			}
			catch (FileNotFoundException e) {
				throw e;
			}
			finally {
				if(reader != null) {
					reader.Close();
				}
			}
			
			return flights;
		}
	}
}
