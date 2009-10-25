
using System;
using System.Collections;
using System.Collections.Generic;

namespace FlightCheckingEmulator
{
	/// <summary>
	/// Description of Node.
	/// </summary>
	public class City<T,F> : ICloneable where T : ICloneable where F : ICloneable
	{
        private T data;
        private List<F> neighbours = null;

        public City() {}
        public City(T data) : this(data, new List<F>()) {}
        public City(T data, List<F> neighbours){
            this.data = data;
            this.neighbours = neighbours;
        }

        public T Value {
            get { return data; }
            set { data = value;}
        }

        public List<F> Neighbours {
            get { return neighbours; }
            set { neighbours = value; }
        }
	
		object ICloneable.Clone()
		{
			City<T,F> newNode = new City<T,F>();
			newNode.data = (T)data.Clone();
			foreach(F item in neighbours)
			{
				newNode.neighbours.Add((F)item.Clone());
			}
			
			return newNode;
		}
    }
}
