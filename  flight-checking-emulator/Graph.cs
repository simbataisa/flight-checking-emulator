
using System;
using System.Collections;
using System.Collections.Generic;

namespace FlightCheckingEmulator
{
	/// <summary>
	/// Description of Graph.
	/// </summary>
	public class Graph<T,F> where T : IComparable<T>, ICloneable where F : ICloneable
	{
		private List<Node<T,F>> nodeSet;

		public Graph() : this(null) {}
		public Graph(List<Node<T,F>> nodeSet)
		{
			if (nodeSet == null)
				this.nodeSet = new List<Node<T,F>>();
			else
				this.nodeSet = nodeSet;
		}

		public void AddNode(Node<T,F> node)
		{
			AddNode(node.Value);
		}

		public void AddNode(T value)
		{	
			if( !Contains(value) )
				nodeSet.Add(new Node<T,F>(value));
		}
		
		public void AddEdge(T from, F edge) {
			AddEdge(GetNode(from), edge);
		}
		
		public void AddEdge(Node<T,F> from, F edge)
		{
			from.Neighbours.Add(edge);
		}

		public bool Contains(T value)
		{
			return (GetNode(value) != null);
		}

		public bool Remove(T value)
		{
			return nodeSet.Remove(GetNode(value));
		}

		public Node<T,F> GetNode(T value)
		{
			foreach(Node<T,F> node in nodeSet) {
				if(node.Value.CompareTo(value) == 0)
					return node;
			}
			
			return null;
		}
		
		public List<Node<T,F>> Nodes
		{
			get { return nodeSet; }
		}

		public int Count
		{ get { return nodeSet.Count; } }
	}
}
