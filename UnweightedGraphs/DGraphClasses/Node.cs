using System.Collections.Generic;

namespace DGraphClasses
{
    /// <summary> "The object used to represent a node." </summary>
    /// <accreditation> This class is from "CS 260 - Graphs" by Jim Bailey</accreditation>
    public class Node
    {
        public char Name { get; set; } // the name of this node
        public bool Visited { get; set; } // variable indicating it has been visited
        public Edge Adjacency { get; set; } // a linked list of edges to adjacent nodes
        public override string ToString() => Name.ToString(); // for easy debugging
    }
}
