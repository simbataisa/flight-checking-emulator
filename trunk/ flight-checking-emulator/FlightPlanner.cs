
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
		Dictionary<String,Flight> flights;
		CityGraph<String,Flight> routes;
		MzObjClass schemeObj;
		
		public CityGraph<String,Flight> Routes {
			get { return routes; }
		}
		
		public Dictionary<String,Flight> Flights {
			get { return flights; }
		}
		
		public FlightPlanner()
		{
			try {
				flights = ReadFlights("flights.txt");
                routes = new CityGraph<String, Flight>();

                foreach (Flight f in flights.Values)
                {
                    routes.AddCity(f.Origin);
                    routes.AddCity(f.Destination);
                    routes.AddFlight(f.Origin, f);
                }

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
		
		private void LoadScheme()
		{
			schemeObj = new MzObjClass();
			schemeObj.SchemeError += new _IMzObjEvents_SchemeErrorEventHandler(error);
			
			StreamReader reader = new StreamReader("CompareByCost.ss");
			string content = reader.ReadToEnd();
			reader.Close();
			
            schemeObj.Eval(content);
		}
		
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
			
			string call = "(CompareByCost " + ToSchemeList(a) + ToSchemeList(b) + ")";
			
			string result = schemeObj.Eval(call);
			result = result.Trim(new Char[] {'"'});
			
			return Int32.Parse(result);
		}
	
		/* Compare two routes, return difference in cost */
		private int CompareByCost(List<String> a, List<String> b)
		{
			if (a == null && b == null) return 0;
            if (a == null && b != null) return -b.Count;
            if (a != null && b == null) return a.Count;
            return a.Count - b.Count;
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
                for (int i = 1; i <= 7; i++)
                {
                    if (fA.Days.Get(i))
                    {
                        dA = i;
                        depA = fA.DepartureTime;
                        depDayA = i;
                        if (fA.ArrivalOnNextDay)
                        {
                            dA %= 7;
                            dA++;
                            
                        }
                        arrA = fA.ArrivalTime;
                        break;
                    }
                }
                for (int i = 0; i < a.Count; i++)
                {
                    fA = flights[a[i]];

                    bool found = false;
                    for (int day = dA; day <= 7; day++) if (fA.Days.Get(day))
                        if (day > dA || (day == dA && fA.DepartureTime >= arrA))
                        {
                            dA = day;
                            arrA = fA.ArrivalTime;
                            arrDayA = day;
                            if (fA.ArrivalOnNextDay)
                            {
                                arrDayA %= 7; arrDayA++; 
                                dA %= 7; dA++; 
                            }
                            found = true;
                            break;
                        }

                    if (!found)
                    {
                        for (int day = 1; day <= 7; day++) if (fA.Days.Get(day))
                        {
                            dA = day;
                            weekA++;
                            arrDayA = day;
                            arrA = fA.ArrivalTime;
                            if (fA.ArrivalOnNextDay)
                            {
                                arrDayA %= 7; arrDayA++;
                                dA %= 7; dA++; 
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
                for (int i = 1; i <= 7; i++)
                {
                    if (fB.Days.Get(i))
                    {
                        dB = i;
                        depB = fB.DepartureTime;
                        depDayB = i;
                        if (fB.ArrivalOnNextDay)
                        {
                            dB %= 7;
                            dB++;
                            
                        }
                        arrB = fB.ArrivalTime;
                        break;
                    }
                }
                for (int i = 0; i < b.Count; i++)
                {
                    fB = flights[b[i]];

                    bool found = false;
                    for (int day = dB; day <= 7; day++) if (fB.Days.Get(day))
                            if (day > dB || (day == dB && fB.DepartureTime >= arrB))
                            {
                                dB = day;
                                arrB = fB.ArrivalTime;
                                arrDayB = day;
                                if (fB.ArrivalOnNextDay)
                                {
                                    arrDayB %= 7; arrDayB++;
                                    dB %= 7; dB++; 
                                }
                                found = true;
                                break;
                            }

                    if (!found)
                    {
                        for (int day = 1; day <= 7; day++) if (fB.Days.Get(day))
                            {
                                dB = day;
                                weekB++;
                                arrDayB = day;
                                arrB = fB.ArrivalTime;
                                if (fB.ArrivalOnNextDay)
                                {
                                    arrDayB %= 7; arrDayB++;
                                    dB %= 7; dB++; 
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
		
		private List<String> ClnPath(List<String> d)
		{
            List<String> newD = new List<String>();

			if( d == null )	return null;
			
			for(int i = 0; i < d.Count; i++)
			{
				newD.Add((string)d[i].Clone());
			}
			return newD;
		}
					
		
		private bool HasFlightArrivalDays(BitArray days, BitArray nextFlightDays)
		{
            BitArray tmp = new BitArray(days.Length, false);
            tmp[0] = (days[0] && nextFlightDays[0]);
            return !days.And(nextFlightDays).Equals(tmp);
		}
		
		private bool HasFlightNotArrivalDays(BitArray days, BitArray nextFlightDays)
		{
            BitArray tmp = new BitArray(days.Length, false);
            tmp[0] = (days[0] != nextFlightDays[0]);
            return !days.Xor(nextFlightDays).Equals(tmp);
		}
		
		private bool IsPathSynchronized(List<String> curPath, Stack<Flight> stack)
		{
			if( curPath == null || stack == null )
				throw new ArgumentNullException();
			
			if( curPath.Count == 0 || stack.Count == 0 )
				return true;
			
            string currentLocation = flights[curPath[curPath.Count - 1]].Destination;
			string nextFlightOrigin = stack.Peek().Origin;
			
			return (currentLocation == nextFlightOrigin);
		}
		
		public List<List<String>> CheckFlights(FlightConstraint con, int sortOption)
		{
			List<List<String>> results = new List<List<String>>();
			
			if( !con.IsReturnTrip && con.Origin == con.Destination )
				return results;
			
			Stack<Flight> stack = new Stack<Flight>();
			List<String> curPath = new List<String>();
			Dictionary<String,String> curVisited = new Dictionary<String,String>();
			
			BitArray days = (BitArray)con.Days.Clone();
			Stack<BitArray> daysTrack = new Stack<BitArray>();

			City<String,Flight> originNode = routes.GetCity(con.Origin);
			curVisited.Add(originNode.Value, null);
			
			foreach(Flight nextFlight in originNode.Neighbours)
			{
                BitArray tmp = new BitArray(days.Length, false);
                tmp[0] = (days[0] && nextFlight.Days[0]);
                bool isVisitable = !days.And(nextFlight.Days).Equals(tmp);
				if( con.TimeSlot.InSlot(nextFlight.DepartureTime) && isVisitable )
				{
                    stack.Push(nextFlight);
				}
			}

			daysTrack.Push(days);

			while(stack.Count != 0)
			{
				Flight curFlight = stack.Pop();
				curVisited.Add(curFlight.Destination, null);
				
				days = ((BitArray)curFlight.Days.Clone()).And(days);

				daysTrack.Push(days);
				
				curPath.Add(curFlight.FlightNo);
								
				if(curFlight.Destination == con.Destination)
				{
					if( con.IsReturnTrip )
					{
                        if (curPath!=null && flights[curPath[curPath.Count-1]].Days[con.ReturnDay])
							results.Add( ClnPath(curPath) );
					}
					else
					{
						results.Add( ClnPath(curPath) );
					}
					
					goto PathSync;
				}
				
				if( con.DirectFlightOnly && curPath.Count >= 1 )
				{
                    curVisited.Remove(flights[curPath[curPath.Count - 1]].Destination);
                    curPath.RemoveAt(curPath.Count - 1);
                    days = daysTrack.Pop();
					continue;
				}
				
                foreach (Flight nextFlight in routes.GetCity(curFlight.Destination).Neighbours)
				{
					if( curVisited.ContainsKey(nextFlight.Destination) )
					{
						if( nextFlight.Destination != con.Destination )
							continue;
						else
							curVisited.Remove(nextFlight.Destination);
					}
					
                    if (curFlight.ArrivalOnNextDay)
                    {
                        BitArray newD = new BitArray(days.Length, false);
                        for (int j = 1; j <= 7; j++) if (days[j])
                            {
                                int jj = j % 7 + 1;
                                newD[jj] = true;
                            }

                        days = newD;
                    }

                    bool isVisitable = false;
                    if (con.FlightOnArrivalDay)
                    {
                        if (nextFlight.DepartureTime - curFlight.ArrivalTime >= FlightConstraint.MinimumInterval)
                        {
                            BitArray tmp = new BitArray(days.Length, false);
                            tmp[0] = (days[0] && nextFlight.Days[0]);
                            isVisitable = !days.And(nextFlight.Days).Equals(tmp);
                        }
                    }
                    else
                    {
                        BitArray tmp = new BitArray(days.Length, false);
                        tmp[0] = (days[0] != nextFlight.Days[0]);
                        isVisitable = !days.Xor(nextFlight.Days).Equals(tmp);
                    }
					if( isVisitable )
					{
						stack.Push(nextFlight);
					}
				}
				
				PathSync:		while( curPath.Count > 0 && stack.Count > 0
				                 && !IsPathSynchronized(curPath, stack) )
				{
                    curVisited.Remove(flights[curPath[curPath.Count - 1]].Destination);
                    curPath.RemoveAt(curPath.Count - 1);
                    days = daysTrack.Pop();
				}
			}

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
				
		private bool IsUniqueSequence(List<String> seq, List<List<String>> seqs)
		{
			foreach(List<String> s in seqs)
			{
				bool same = true;
				for(int i = 0; i < s.Count; i++)
				{
                    if (s[i] != seq[i]) same = false;
				}
                if (same) return false;
			}

            return true;
		}
		
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
		
		private Dictionary<String,Flight> ReadFlights(string filename) {
			Dictionary<String,Flight> flights = new Dictionary<String,Flight>(50);
			TextReader reader = null;
			
			try {
				reader = new StreamReader(filename);
				string[] pt;
				Flight newFlight;
				char[] separator = {' ', ',', '\t'};
				
				while(reader.Peek() != -1) {
					pt = reader.ReadLine().Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries);
					newFlight = new Flight();
					newFlight.Origin = pt[0];
					newFlight.Destination = pt[1];
					{
						string[] tmp = pt[2].Split(new Char[]{':'});
						System.Console.WriteLine(tmp[0]);
						newFlight.DepartureTime = new Time(Int32.Parse(tmp[0]), Int32.Parse(tmp[1]));
					}
					{
						if(pt[3].EndsWith("*")) {
							newFlight.ArrivalOnNextDay = true;
							pt[3] = pt[3].Remove(pt[3].Length - 1);
						}
						string[] tmp = pt[3].Split(new Char[]{':'});
						newFlight.ArrivalTime = new Time(Int32.Parse(tmp[0]), Int32.Parse(tmp[1]));
					}
					newFlight.FlightNo = pt[4];
					if(pt[5] == "Alldays") {
						newFlight.Days.SetAll(true);
					}
					else {
						for(int i = 5; i < pt.Length; i++) {
							switch(pt[i]) {
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
