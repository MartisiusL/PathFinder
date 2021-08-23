using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PathFinder.SolutionWithBinaryTree
    {
    public static class PyramidHelperForBinaryTree
        {
        public static void ShowPyramid (Node topNode)
            {
            var listOfNodes = new List<Node> () { topNode };
            while (listOfNodes.First () != null)
                {
                var nextFloorNodes = new List<Node> () { listOfNodes.First ().LeftNode };
                foreach (var node in listOfNodes)
                    {
                    nextFloorNodes.Add (node.RightNode);
                    Console.Write ($"{node.Value} ");
                    }
                Console.Write ("\n");

                listOfNodes = nextFloorNodes;
                }
            Console.WriteLine ();
            }

        public static Node CreateRandomPyramid (int redDepth)
            {
            Random rnd = new Random ();
            var topNode = new Node (rnd.Next (1, 9));
            var nodes = new List<Node> () { topNode };
            CreateNextFloor (nodes, rnd, redDepth);
            return topNode;
            }

        public static Node CreatePatternPyramid (int redDepth)
            {
            Random rnd = new Random ();
            var topNode = new Node (rnd.Next (1, 9));
            var isEven = topNode.Value % 2 == 0;
            var nodes = new List<Node> () { topNode };
            CreateNextFloor (nodes, rnd, redDepth, !isEven);
            return topNode;
            }

        private static void CreateNextFloor (List<Node> nodes, Random rnd, int reqDepth, bool? isEven = null,  int currentDepth = 0)
            {
            currentDepth++;
            if (currentDepth == reqDepth)
                {
                return;
                }
            var nextFloorOfNodes = new List<Node> ();
            nextFloorOfNodes.Add (new Node (CreatePatternNumber (isEven, rnd)));
            foreach (var node in nodes)
                {
                node.LeftNode = nextFloorOfNodes.Last ();
                nextFloorOfNodes.Add (new Node (CreatePatternNumber (isEven, rnd)));
                node.RightNode = nextFloorOfNodes.Last ();
                }

            CreateNextFloor (nextFloorOfNodes, rnd, reqDepth, !isEven, currentDepth);
            }

        private static int CreatePatternNumber (bool? isEven, Random rnd)
            {
            return isEven is null ? rnd.Next(1, 9) : (bool) isEven ? 2 * rnd.Next (1, 4) : 2 * rnd.Next (1, 5) - 1;
            }

        public static Node CreatePyramidFromFile ()
            {
            try
                {
                var path = Path.Combine (Path.GetDirectoryName (Environment.CurrentDirectory), "../../pyramid.txt");
                var lines = File.ReadAllLines (path);
                var topNode = new Node (int.Parse(lines[0]));
                var nodes = new List<Node> () { topNode };
                CreateNextFloor (nodes, lines);
                return topNode;
                }
            catch (Exception exception)
                {
                return null;
                }
            }

        private static void CreateNextFloor (List<Node> nodes, string[] lines, int currentDepth = 0)
            {
            currentDepth++;
            if (currentDepth == lines.Length)
                {
                return;
                }

            var values = lines[currentDepth].Split (" ");
            var i = 0;
            var nextFloorOfNodes = new List<Node> ();
            nextFloorOfNodes.Add (new Node (int.Parse (values[i])));
            foreach (var node in nodes)
                {
                node.LeftNode = nextFloorOfNodes.Last ();
                i++;
                nextFloorOfNodes.Add (new Node (int.Parse (values[i])));
                node.RightNode = nextFloorOfNodes.Last ();
                }

            CreateNextFloor (nextFloorOfNodes, lines, currentDepth);
            }

        public static Node CreatePredefinedPyramid ()
            {
            var node = new Node (1);
            node.LeftNode = new Node (8);
            node.RightNode = new Node (9);

            node.LeftNode.LeftNode = new Node (1);
            node.LeftNode.RightNode = new Node (5);

            node.RightNode.LeftNode = node.LeftNode.RightNode;
            node.RightNode.RightNode = new Node (9);

            node.LeftNode.LeftNode.LeftNode = new Node (4);
            node.LeftNode.LeftNode.RightNode = new Node (5);

            node.LeftNode.RightNode.LeftNode = node.LeftNode.LeftNode.RightNode;
            node.LeftNode.RightNode.RightNode = new Node (2);

            node.RightNode.LeftNode.LeftNode = node.LeftNode.LeftNode.RightNode;
            node.RightNode.LeftNode.RightNode = node.LeftNode.RightNode.RightNode;

            node.RightNode.RightNode.LeftNode = node.LeftNode.RightNode.RightNode;
            node.RightNode.RightNode.RightNode = new Node (3);

            return node;
            }

        public static int GetPyramidDepth (Node node, int depth = 1)
            {
            if (node.LeftNode != null)
                {
                depth++;
                return GetPyramidDepth (node.LeftNode, depth);
                }

            return depth;
            }
        }
    }
