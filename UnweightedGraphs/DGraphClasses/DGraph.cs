using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DGraphClasses
{
    /// <summary> The graph class itself with both adjaceny lists and an adjacency matrix. </summary>
    /// <accreditation> This class is based on the class 'Graphs' from "CS 260 - Graphs" by Jim Bailey.</accreditation>
    public class DGraph
    {
        static void Main(string[] args) { }
        //class variables
        private const int SIZE = 20;
        private int NumNodes; // how many nodes are in the nodeList
        private Node[] NodeList; // the actual list of nodes
        private bool[,] AdjacencyMatrix; // the matrix of edges

        // private methods
        /// <summary> Linear search for a node with this name. </summary>
        /// <param name="name"> The name of the node to search for. </param>
        /// <returns> The index in the NodeList of the node searched for; -1 if not found. </returns>
        private int FindNode(char name)
        {
            for (int index = 0; index < NumNodes; index++)
                if (NodeList[index].Name == name)
                    return index;
            return -1;
        }  
        private void ResetVisited() => throw new NotImplementedException(); // used to reset all visited flags

        //public methods
        /// <summary> DGraph constructor; intializes all instance members. </summary>
        /// <param name="size"> The number of nodes in the graph. </param>
        public DGraph(int size = -1)
        {
            size = size < 1 ? SIZE : size;
            NumNodes = 0;
            NodeList = new Node[size];
            AdjacencyMatrix = new bool[size,size];
        }

        /// <summary> Add a new node to the graph. Only fail if graph arrays are full. </summary>
        /// <param name="node"> The node to be added to the graph. </param>
        public void AddNode(char name)
        {
            // alternately, double the size of everything and start over
            if (NumNodes >= SIZE) throw new IndexOutOfRangeException("Graph size exceeded!");

            // create a node with this name
            // initialize it with no edges and not yet visited
            Node temp = new();
            temp.Name = name;
            temp.Visited = false;
            temp.Adjacency = null;

            // add it to the list of nodes in graph
            NodeList[NumNodes++] = temp;
        }
        //TODO: Describe params of AddEdge
        /// <summary> Add a new edge to the graph. </summary>
        /// <param name="starts"></param>
        /// <param name="ends"></param>
        /// <returns> Return false and do nothing if either end is invalid. Otherwise, add to both nodes edge lists and to the matrix. </returns>
        public bool AddEdge(char starts, char ends)
        {
            if (starts == ends) return false; // return false if link to self

            // return false if either end does not exist
            int startIndex = FindNode(starts);
            int endIndex = FindNode(ends);
            if (startIndex == -1 || endIndex == -1) return false;

            // set both links in the adjacency matrix
            AdjacencyMatrix[startIndex, endIndex] = true;
            //AdjacencyMatrix[endIndex, startIndex] = true;

            // create two new edges (one for each direction)
            // add one to each node’s adjacency list
            Edge startEnd = new();
            startEnd.EndIndex = endIndex;
            startEnd.Next = NodeList[startIndex].Adjacency;
            NodeList[startIndex].Adjacency = startEnd;

            //Edge endStart = new();
            //endStart.EndIndex = startIndex;
            //endStart.Next = NodeList[endIndex].Adjacency;
            //NodeList[endIndex].Adjacency = endStart;

            return true;
        }

        /// <summary> Listing of nodes in order added to array.  </summary>
        /// <returns> A list of nodes, in the order they were added to the array. </returns>
        public string ListNodes()
        {
            string theList = "The Nodes are: ";
            for (int index = 0; index < NumNodes; index++)
                theList += NodeList[index].Name + " ";
            return theList;
        }
        /// <summary> Display the edgelist. </summary>
        /// <returns> An adjacency matrix for each node in the graph. </returns>
        public string DisplayEdges()
        {
            string buffer = "The Adjacency List is: (Node: its adjacencies)\n";
            for (int index = 0; index < NumNodes; index++)
            {
                // add the node name to the display
                buffer += NodeList[index].Name;
                buffer += ": ";

                // walk down its list of edges and add them also
                // standard linked list traversal
                Edge ptr = NodeList[index].Adjacency;
                while (ptr != null)
                {
                    buffer += NodeList[ptr.EndIndex].Name;
                    buffer += " ";
                    ptr = ptr.Next;
                }
                // end this line of output
                buffer += '\n';
            }
            return buffer;
        }
        /// <summary> Display the adjaceny matrix, 0 for unconnected and 1 for connected. </summary>
        /// <returns> A string representing the adjacency matrix of the DGraph. </returns>
        public string DisplayMatrix()
        {
            string buffer = "   "; // declare the return value
            
            // print the table header
            for (int h = 0; h < NumNodes; h++)
                buffer += NodeList[h].Name + "  ";
            buffer += "\n" + "  ";
            for (int i = 0; i < NumNodes * 3 - 1; i++)
                buffer += "_";
            buffer += "\n";
            
            // print the table contents
            for (int j = 0; j < NumNodes; j++)
            {
                buffer += NodeList[j].Name + " |";
                for (int k = 0; k < NumNodes; k++)
                {
                    if (k == j) buffer += "-"; // If the connection being printed is between a node and that node itself: skip.

                    else if (AdjacencyMatrix[j, k] is true)
                        buffer += 1;
                    else
                        buffer += 0;
                    buffer += "  ";
                }
                buffer += "\n";
            }
            return buffer;
        }

        //TODO: BreadthFirst Summary
        /// <summary>  </summary>
        /// <param name="node"> The node from which to start the breadth first FIFO search patttern. </param>
        /// <returns> A string representing the nodes that can be reached by the input, in the order that they are reached. The string also specifyies which nodes can't be reached. </returns>
        /// <accreditation> This method is based of "Breadth First Search or BFS for a Graph (C#)" found at https://www.geeksforgeeks.org/breadth-first-search-or-bfs-for-a-graph/ </accreditation>
        public string BreadthFirst(char s)
        {
            //int root = IndexOf(NodeList, s)

            bool[] visited = new bool[NumNodes]; // Keep track of visited nodes
            for (int i = 0; i < NumNodes; i++) 
                visited[i] = false; // default: not visited

            Queue<int> queue = new(); 

            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
            }
            return "";
        }
        public string DepthFirst(char node) => throw new NotImplementedException();

        public string ConnectTable() => throw new NotImplementedException();

        public string MinTree(char node) => throw new NotImplementedException();
        public string MaxTree(char node) => throw new NotImplementedException();
    }
}
