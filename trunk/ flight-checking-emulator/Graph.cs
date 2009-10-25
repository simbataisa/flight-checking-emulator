
using System;
using System.Collections;
using System.Collections.Generic;

namespace FlightCheckingEmulator
{
	/// <summary>
	/// Description of Graph.
	/// </summary>
	public class CityGraph<T,F> where T : IComparable<T>, ICloneable where F : ICloneable
	{
		private List<City<T,F>> citySet;

		public CityGraph() : this(null) {}
		public CityGraph(List<City<T,F>> nodeSet)
		{
			if (nodeSet == null)
				this.citySet = new List<City<T,F>>();
			else
				this.citySet = nodeSet;
		}

		public void AddCity(City<T,F> node)
		{
			AddCity(node.Value);
		}

		public void AddCity(T value)
		{	
			if( !Contains(value) )
				citySet.Add(new City<T,F>(value));
		}
		
		public void AddFlight(T from, F edge) {
			AddFlight(GetCity(from), edge);
		}
		
		public void AddFlight(City<T,F> from, F edge)
		{
			from.Neighbours.Add(edge);
		}

		public bool Contains(T value)
		{
			return (GetCity(value) != null);
		}

		public bool Remove(T value)
		{
			return citySet.Remove(GetCity(value));
		}

		public City<T,F> GetCity(T value)
		{
			foreach(City<T,F> node in citySet) {
				if(node.Value.CompareTo(value) == 0)
					return node;
			}
			
			return null;
		}
		
		public List<City<T,F>> Nodes
		{
			get { return citySet; }
		}

		public int Count
		{ get { return citySet.Count; } }
	}
}
