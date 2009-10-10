
using System;

namespace TravelPlanner
{
	/// <summary>
	/// Description of Time.
	/// </summary>
	public struct Time : IEquatable<Time>, IComparable<Time>
	{
		int hour, minute;
		
		public int Minute {
			get { return minute; }
		}
		
		public int Hour {
			get { return hour; }
		}
		
		public Time(int hour, int minute) {
			if(hour > 24 || hour < 0 || minute >= 60 || minute < 0)
				throw new ArgumentOutOfRangeException();
			this.hour = hour;
			this.minute = minute;
		}
		
		public override string ToString()
		{
			return String.Format("{0:D2}:{1:D2}", hour, minute);
		}
		
		#region CompareTo implementation
		public int CompareTo(Time another) {
			return (hour - another.hour) * 60 + (minute - another.minute);
		}
		#endregion
		
		#region Equals and GetHashCode implementation
		// The code in this region is useful if you want to use this structure in collections.
		// If you don't need it, you can just remove the region and the ": IEquatable<Time>" declaration.
		
		public override bool Equals(object obj)
		{
			if (obj is Time)
				return Equals((Time)obj); // use Equals method below
			else
				return false;
		}
		
		public bool Equals(Time other)
		{
			return this.hour == other.hour && this.minute == other.minute;
		}
		
		public override int GetHashCode()
		{
			// combine the hash codes of all members here (e.g. with XOR operator ^)
			return hour.GetHashCode() ^ minute.GetHashCode();
		}
		
		public static int operator -(Time lhs, Time rhs)
		{
			return (lhs.hour * 60 + lhs.minute) - (rhs.hour * 60 + rhs.minute);
		}
		
		public static int operator +(Time lhs, Time rhs)
		{
			return (lhs.hour * 60 + lhs.minute + rhs.hour * 60 + rhs.minute);
		}
				
		public static bool operator <(Time lhs, Time rhs)
		{
			return (lhs.hour * 60 + lhs.minute) < (rhs.hour * 60 + rhs.minute);
		}
		
		public static bool operator >(Time lhs, Time rhs)
		{
			return (lhs.hour * 60 + lhs.minute) > (rhs.hour * 60 + rhs.minute);
		}

		public static bool operator <=(Time lhs, Time rhs)
		{
			return (lhs.hour * 60 + lhs.minute) <= (rhs.hour * 60 + rhs.minute);
		}
		
		public static bool operator >=(Time lhs, Time rhs)
		{
			return (lhs.hour * 60 + lhs.minute) >= (rhs.hour * 60 + rhs.minute);
		}
		
		public static bool operator ==(Time lhs, Time rhs)
		{
			return lhs.Equals(rhs);
		}
		
		public static bool operator !=(Time lhs, Time rhs)
		{
			return !(lhs.Equals(rhs)); // use operator == and negate result
		}
		#endregion
	}
}
