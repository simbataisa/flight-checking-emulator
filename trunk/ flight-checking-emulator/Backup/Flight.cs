
using System;
using System.Collections;

namespace TravelPlanner
{
	/// <summary>
	/// Description of Flight.
	/// </summary>
	public class Flight : ICloneable
	{
		string origin, destination;
		string flightNo;
		bool arrivalOnNextDay;
		Time departureTime, arrivalTime;
		BitArray days;
		
		public string this [int index]
		{
			get
			{
				string s = "";
				
				switch(index)
				{
					case 0: s = flightNo; break;
					case 1: s = origin; break;
					case 2: s = destination; break;
					case 3: s = departureTime.ToString(); break;
					case 4: s = arrivalTime.ToString();
					if( this.arrivalOnNextDay )
						s += "*";
					break;
					case 5: 
						bool isAllDays = true;
						for(int i = 1; i < days.Length; i++)
						{
							if( days[i] )
							{
								switch(i)
								{
									case 1: s += "Mo "; break;
									case 2: s += "Tu "; break;
									case 3: s += "We "; break;
									case 4: s += "Th "; break;
									case 5: s += "Fr "; break;
									case 6: s += "Sa "; break;
									case 7: s += "Su "; break;
								}
							}
							else
							{
								isAllDays = false;
							}
						}
						if( isAllDays )
							s = "Alldays";
						break;
				}
				return s;
			}
		}
		#region Getters and Setters
		public string Destination {
			get { return destination; }
			set { destination = value; }
		}
		
		public string Origin {
			get { return origin; }
			set { origin = value; }
		}
		
		public Time ArrivalTime {
			get { return arrivalTime; }
			set { arrivalTime = value; }
		}
		
		public Time DepartureTime {
			get { return departureTime; }
			set { departureTime = value; }
		}
		
		public string FlightNo {
			get { return flightNo; }
			set { flightNo = value; }
		}
		
		public bool ArrivalOnNextDay {
			get { return arrivalOnNextDay; }
			set { arrivalOnNextDay = value; }
		}
		
		public BitArray Days {
			get { return days; }
			set { days = value; }
		}
		
		#endregion
		
		public Flight()
		{
			// First bit is not used
			days = new BitArray(8, false);
		}
		
		object ICloneable.Clone()
		{
			Flight newFlight = new Flight();
			newFlight.origin = (string)origin.Clone();
			newFlight.destination = (string)destination.Clone();
			newFlight.flightNo = (string)flightNo.Clone();
			newFlight.arrivalOnNextDay = arrivalOnNextDay;
			newFlight.departureTime = departureTime;
			newFlight.arrivalTime = arrivalTime;
			newFlight.days = (BitArray)days.Clone();
			
			return newFlight;
		}
		
		public override string ToString()
		{
			string s = origin + ", "
				+ destination + ", "
				+ flightNo + ", "
				+ arrivalOnNextDay + ", "
				+ departureTime + ", "
				+ arrivalTime + ", ";
			
			for(int i = 1; i < days.Length; i++) 
			{
				if(days[i])
					s += i + ", ";
			}
			
			return s;
		}
	}
}
