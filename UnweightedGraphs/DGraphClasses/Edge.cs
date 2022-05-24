namespace DGraphClasses
{
    /// <summary> "When using an adjacency list, you have a set of Edges" </summary>
    /// <accreditation> This class is based off of the 'Node' class from "CS 260 - Graphs" by Jim Bailey. </accreditation>
    public class Edge
    {
        public int EndIndex { get; set; } // the index in the Node array of the other end
        public Edge Next { get; set; } // reference to the next link(edge) in the linked list
    }
}
