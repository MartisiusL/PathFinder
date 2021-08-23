using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder.SolutionWithBinaryTree
    {
    public static class SolutionWithBinaryTree
        {
        public static void Run ()
            {
            // Default pyramid that was required.
            var pyramid = PyramidHelperForBinaryTree.CreatePredefinedPyramid ();

            // Pyramid that is created by reading contents of the "pyramid.txt" file.
            // var pyramid = PyramidHelperForBinaryTree.CreatePyramidFromFile ();

            // Pyramid that is generated with random integers.
            // var pyramid = PyramidHelperForBinaryTree.CreateRandomPyramid (10);

            // Pyramid that is generated with random integers, but always has odd - even pattern.
            // var pyramid = PyramidHelperForBinaryTree.CreatePatternPyramid (10);

            // Prints out entire pyramid to visually see it.
            // PyramidHelperForBinaryTree.ShowPyramid (pyramid);

            var depth = PyramidHelperForBinaryTree.GetPyramidDepth (pyramid);
            var bestPath = Enumerable.Repeat (0, depth).ToList ();
            var currentPath = Enumerable.Repeat (0, depth).ToList ();

            GoDeeper (pyramid, 0, ref bestPath, currentPath);
            Utilities.ShowResults (bestPath);
            }

        private static void GoDeeper (Node currentNode, int depth, ref List<int> bestPath, List<int> currentPath)
            {
            currentPath[depth] = currentNode.Value;
            if (currentNode.LeftNode is null)
                {
                if (Utilities.CountSum (currentPath) > Utilities.CountSum (bestPath))
                    {
                    bestPath = currentPath.ToList ();
                    }

                return;
                }

            if (Utilities.MatchPattern (currentNode.Value, currentNode.LeftNode.Value))
                {
                GoDeeper (currentNode.LeftNode, depth + 1, ref bestPath, currentPath);
                }

            if (Utilities.MatchPattern (currentNode.Value, currentNode.RightNode.Value))
                {
                GoDeeper (currentNode.RightNode, depth + 1, ref bestPath, currentPath);
                }
            }
        }
    }
