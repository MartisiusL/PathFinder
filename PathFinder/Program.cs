using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder
    {
    class Program
        {
        static void Main (string[] args)
            {
            int[][] pyramid = new int[4][];
            pyramid[0] = new int[1] { 1 };
            pyramid[1] = new int[2] { 8, 9 };
            pyramid[2] = new int[3] { 1, 5, 9 };
            pyramid[3] = new int[4] { 4, 5, 2, 3 };

            var bestPath = new List<int> () { 0, 0, 0, 0 };
            var currentPath = new List<int> () { 0, 0, 0, 0 };

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
