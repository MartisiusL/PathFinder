using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder.SolutionWithJaggedArrays
    {
    public static class SolutionWithJaggedArrays
        {
        public static void Run ()
            {
            // Default pyramid that was required.
            // var pyramid = PyramidHelperForJaggedArrays.CreatePredefinedPyramid ();

            // Pyramid that is created by reading contents of the "pyramid.txt" file.
            var pyramid = PyramidHelperForJaggedArrays.CreatePyramidFromFile ();

            // Pyramid that is generated with random integers.
            // var pyramid = PyramidHelperForJaggedArrays.CreateRandomPyramid (10);

            // Pyramid that is generated with random integers, but always has odd - even pattern.
            // var pyramid = PyramidHelperForJaggedArrays.CreatePatternPyramid (10);

            // Prints out entire pyramid to visually see it.
            // PyramidHelperForJaggedArrays.ShowPyramid (pyramid);

            var bestPath = Enumerable.Repeat (0, pyramid.Length).ToList ();
            var currentPath = Enumerable.Repeat (0, pyramid.Length).ToList ();

            GoDeeper (pyramid, ref bestPath, currentPath);
            Utilities.ShowResults (bestPath);
            }

        private static void GoDeeper (int[][] pyramid, ref List<int> bestPath, List<int> currentPath, int depth = 0, int lastIndex = 0)
            {
            currentPath[depth] = pyramid[depth][lastIndex];
            if (depth == pyramid.Length - 1)
                {
                if (Utilities.CountSum (currentPath) > Utilities.CountSum (bestPath))
                    {
                    bestPath = currentPath.ToList ();
                    }

                return;
                }

            if (Utilities.MatchPattern (pyramid[depth][lastIndex], pyramid[depth + 1][lastIndex]))
                {
                GoDeeper (pyramid, ref bestPath, currentPath, depth + 1, lastIndex);
                }

            if (Utilities.MatchPattern (pyramid[depth][lastIndex], pyramid[depth + 1][lastIndex + 1]))
                {
                GoDeeper (pyramid, ref bestPath, currentPath, depth + 1, lastIndex + 1);
                }
            }
        }
    }
