
using System;

namespace FlightCheckingEmulator
{
	/// <summary>
	/// Description of TimeSlot.
	/// </summary>
	public class TimeSlot
	{
		private static readonly int SLOT_COUNT = 4;
		
		public static int SlotCount {
			get { return SLOT_COUNT; }
		}
		
		private readonly int slot;
		private readonly Time lower, upper;
		
		public Time Upper {
			get { return upper; }
		}
		
		public Time Lower {
			get { return lower; }
		}
		
		public TimeSlot(int slot)
		{
			if(slot < 0 || slot > SLOT_COUNT)
				throw new ArgumentOutOfRangeException();
			
			this.slot = slot;
			// Allday slot...
			if(slot == 0 )
			{
				lower = new Time(0, 0);
				upper = new Time(24, 0);
			}
			else
			{
				lower = new Time((slot - 1) * 24 / SLOT_COUNT, 0);
				upper = new Time(slot * 24 / SLOT_COUNT, 0);
			}
		
		}
		
		public bool InSlot(Time t)
		{
			return (lower <= t && t <= upper);
		}
		
		public override string ToString()
		{
			return lower.ToString() + " - " + upper.ToString();
		}
	}
}
