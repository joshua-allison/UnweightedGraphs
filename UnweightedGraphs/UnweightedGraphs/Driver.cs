//
//  main.cpp
//  CS 260 Lab 8
//
//  Created by Jim Bailey on June 2, 2020.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//  Transpiled into C# 6/5/2020 by Katie Strauss
//

using System;
using DGraphClasses;

namespace GraphsDriver
{
    class Driver
    {
        static void Main(string[] args)
        {
            // create the graph
            DGraph graph = new DGraph();

            //add nodes
            graph.AddNode('A');
            graph.AddNode('C');
            graph.AddNode('T');
            graph.AddNode('Z');
            graph.AddNode('X');
            graph.AddNode('K');
            graph.AddNode('Q');
            graph.AddNode('J');
            graph.AddNode('M');
            graph.AddNode('U');

            // add some edges
            graph.AddEdge('A', 'C');
            graph.AddEdge('A', 'T');
            graph.AddEdge('A', 'Z');
            graph.AddEdge('X', 'C');
            graph.AddEdge('C', 'X');
            graph.AddEdge('C', 'K');
            graph.AddEdge('T', 'Q');
            graph.AddEdge('K', 'Q');
            graph.AddEdge('Q', 'J');
            graph.AddEdge('J', 'M');
            graph.AddEdge('Z', 'X');
            graph.AddEdge('U', 'M');
            graph.AddEdge('K', 'X');

            // uncomment the next line to see your node list, edge list, and edge matrix
            // Debug1(graph);

            BaseTest(graph);
            //ConnectTest(graph);
            //MinTreeTest(graph);

            Console.Write("Press Enter to close.");
            Console.Read();
        }

        static void BaseTest(DGraph graph)
        {
            Console.Write("Now testing base lab functionality \n\n");

            Console.Write("The list of nodes \n expected A C T Z X K Q J M U\n");
            Console.Write(" actually " + graph.ListNodes() + "\n\n");

            Console.Write("The graph edgelist is: \n");
            Console.Write(graph.DisplayEdges() + "\n\n");

            Console.Write("The graph edge matrix is\n");
            Console.Write(graph.DisplayMatrix() + "\n");
            Console.Write("The breadth traversal from A\n");
            Console.Write(" expected A: Z T C X Q K J M with U unreachable\n");
            Console.Write(" actually " + graph.BreadthFirst('A') + "\n\n");

            Console.Write("The depth first traversal from A\n");
            Console.Write(" expected A: Z X C K Q J M T with U unreachable\n");
            Console.Write(" actually " + graph.DepthFirst('A') + "\n\n");

            Console.Write("Done testing base lab\n\n");
        }

        static void ConnectTest(DGraph graph)
        {
            Console.Write("This test displays a connection table for a directed graph\n\n");

            Console.Write("The breadth first min tree from A should be: \n");
            Console.Write(" A-Z A-Z A-T A-C Z-X T-Q C-K Q-J J-M  with U unreachable\n");
            Console.Write(" is: " + graph.BreadthFirst('A') + "\n\n");


            Console.Write("The graph connect table should be: \n");
            Console.Write("A: Z X C K Q J M T \n");
            Console.Write("C: K X Q J M\n");
            Console.Write("T: Q J M\n");
            Console.Write("Z: X C K Q J M\n");
            Console.Write("X: C K Q J M\n");
            Console.Write("K: X C Q J M\n");
            Console.Write("Q: J M\n");
            Console.Write("J: M\n");
            Console.Write("M:\n");
            Console.Write("U: M \n\n");

            Console.Write("The graph connect table is: \n");
            Console.Write(graph.ConnectTable() + "\n\n");

            Console.Write("End of testing connection table\n\n");
        }

        static void Debug1(DGraph graph)
        {
            Console.Write("The list of nodes is: \n");
            Console.Write(graph.ListNodes() + "\n\n");

            Console.Write("The graph edgelist is: \n");
            Console.Write(graph.DisplayEdges() + "\n\n");

            Console.Write("The graph edge matrix is\n");
            Console.Write(graph.DisplayMatrix() + "\n");
        }

        static void MinTreeTest(DGraph graph)
        {
            Console.Write("Now testing the depth-first minimum spanning tree\n\n");

            Console.Write("The minimum spanning tree from Z \n");
            Console.Write(" expected Z: Z-X X-C C-K K-Q Q-J J-M \n");

            Console.Write(" actually ");
            Console.Write(graph.MinTree('Z') + "\n");

            Console.Write("The minimum spanning tree from C \n");
            Console.Write(" expected C: C-K K-X K-Q Q-J J-M \n");

            Console.Write(" actually ");
            Console.Write(graph.MinTree('C') + "\n");

            Console.Write("Done with testing minimum spanning tree \n\n");

        }
    }
}