
using System;
using System.Collections;
using System.Collections.Generic;

namespace TravelPlanner
{
	/// <summary>
	/// Description of FlightConstraint.
	/// </summary>
	public class FlightConstraint
	{
		string origin, destination;
		
		public string Destination {
			get { return destination; }
			set { destination = value; }
		}
		
		public string Origin {
			get { return origin; }
			set { origin = value; }
		}
		TimeSlot timeSlot;
		
		public TimeSlot TimeSlot {
			get { return timeSlot; }
			set { timeSlot = value; }
		}
		BitArray days;
		
		public BitArray Days {
			get { return days; }
			set { days = value; }
		}
		bool directFlightOnly;
		
		public bool DirectFlightOnly {
			get { return directFlightOnly; }
			set { directFlightOnly = value; }
		}
		
		bool isReturnTrip, flightOnArrivalDay;
		
		public bool FlightOnArrivalDay {
			get { return flightOnArrivalDay; }
			set { flightOnArrivalDay = value; }
		}
		
		public bool IsReturnTrip {
			get { return isReturnTrip; }
			set { isReturnTrip = value; }
		}
		int returnDay;
		
		public int ReturnDay {
			get { return returnDay; }
			set { returnDay = value; }
		}
		
		static readonly int minimumInterval = 60;
		
		public static int MinimumInterval {
			get { return minimumInterval; }
		}
		
		string[] places;
		
		public string[] Places {
			get { return places; }
			set { places = value; }
		}
		
		public FlightConstraint()
		{
			days = new BitArray(8, false);
			places = new String[3];
		}
	}
}
