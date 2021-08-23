using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder
    {
    public static class Utilities
        {
        public static void ShowResults (List<int> bestPath)
            {
            if (CountSum (bestPath) == 0)
                {
                Console.WriteLine ("There was no path found that would match the pattern.");
                return;
                }
            Console.WriteLine ($"Max sum: {CountSum (bestPath)}");
            Console.WriteLine ($"Path: {String.Join (", ", bestPath)}");
            }

        public static int CountSum (List<int> path)
            {
            return path.Take (path.Count).Sum ();
            }

        public static bool MatchPattern (int current, int next)
            {
            return current % 2 == 0 ^ next % 2 == 0;
            }
        }
    }
