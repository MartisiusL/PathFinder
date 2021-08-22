using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder
    {
    class Program
        {
        static void Main (string[] args)
            {
            // Default pyramid that was required.
            var pyramid = PyramidHelper.CreatePredefinedPyramid ();

            // Pyramid that is created by reading contents of the "pyramid.txt" file.
            // var pyramid = PyramidHelper.CreatePyramidFromFile ();

            // Pyramid that is generated with random integers.
            // var pyramid = PyramidHelper.CreateRandomPyramid (10);

            // Pyramid that is generated with random integers, but always has odd - even pattern.
            // var pyramid = PyramidHelper.CreatePatternPyramid (10);

            // Prints out entire pyramid to visually see it.
            // PyramidHelper.ShowPyramid (pyramid);

            var bestPath = Enumerable.Repeat (0, pyramid.Length).ToList ();
            var currentPath = Enumerable.Repeat (0, pyramid.Length).ToList ();

            GoDeeper (pyramid, 0, 0, ref bestPath, currentPath);
            Console.WriteLine ($"Max sum: {CountSum (bestPath)}");
            Console.WriteLine ($"Path: {String.Join (", ", bestPath)}");
            }

        private static void GoDeeper (int[][] pyramid, int depth, int lastIndex, ref List<int> bestPath, List<int> currentPath)
            {
            currentPath[depth] = pyramid[depth][lastIndex];
            if (depth == pyramid.Length - 1)
                {
                if (CountSum (currentPath) > CountSum (bestPath))
                    {
                    bestPath = currentPath.ToList ();
                    }

                return;
                }

            if (MatchPattern (pyramid[depth][lastIndex], pyramid[depth + 1][lastIndex]))
                {
                GoDeeper (pyramid, depth + 1, lastIndex, ref bestPath, currentPath);
                }

            if (MatchPattern (pyramid[depth][lastIndex], pyramid[depth + 1][lastIndex + 1]))
                {
                GoDeeper (pyramid, depth + 1, lastIndex + 1, ref bestPath, currentPath);
                }
            }

        private static int CountSum (List<int> path)
            {
            return path.Take (path.Count).Sum ();
            }

        private static bool MatchPattern (int current, int next)
            {
            return current % 2 == 0 ^ next % 2 == 0;
            }
        }
    }
