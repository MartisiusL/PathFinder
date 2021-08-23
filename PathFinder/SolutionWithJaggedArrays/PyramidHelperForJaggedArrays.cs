using System;
using System.IO;

namespace PathFinder.SolutionWithJaggedArrays
    {
    public static class PyramidHelperForJaggedArrays
        {
        public static void ShowPyramid (int[][] pyramid)
            {
            int i = 0;
            foreach (var row in pyramid)
                {
                i++;
                Console.WriteLine (String.Join (" ", row));
                }
            Console.WriteLine();
            }

        public static int[][] CreateRandomPyramid (int depth)
            {
            Random rnd = new Random ();
            var pyramid = new int[depth][];
            for (int i = 0; i < depth; i++)
                {
                pyramid[i] = new int[i + 1];
                for (int x = 0; x < pyramid[i].Length; x++)
                    {
                    pyramid[i][x] = rnd.Next (1, 9);
                    }
                }

            return pyramid;
            }

        public static int[][] CreatePatternPyramid (int depth)
            {
            Random rnd = new Random ();
            var pyramid = new int[depth][];
            var isEven = rnd.Next (1, 2) % 2 == 0;
            for (int i = 0; i < depth; i++)
                {
                pyramid[i] = new int[i + 1];
                for (int x = 0; x < pyramid[i].Length; x++)
                    {
                    if (isEven)
                        {
                        pyramid[i][x] = 2 * rnd.Next (1, 4);
                        }
                    else
                        {
                        pyramid[i][x] = 2 * rnd.Next (1, 5) - 1;
                        }
                    }

                isEven = !isEven;
                }

            return pyramid;
            }

        public static int[][] CreatePyramidFromFile ()
            {
            try
                {
                string path = Path.Combine (Path.GetDirectoryName (Environment.CurrentDirectory), "../../pyramid.txt");
                string[] lines = File.ReadAllLines (path);
                var pyramid = new int[lines.Length][];
                for (int i = 0; i < lines.Length; i++)
                    {
                    pyramid[i] = new int[i + 1];
                    var values = lines[i].Split (" ");
                    for (int x = 0; x < pyramid[i].Length; x++)
                        {
                        pyramid[i][x] = int.Parse (values[x]);
                        }
                    }

                return pyramid;
                }
            catch (Exception exception)
                {
                return new int[0][];
                }
            }

        public static int[][] CreatePredefinedPyramid ()
            {
            int[][] pyramid = new int[4][];
            pyramid[0] = new int[1] { 1 };
            pyramid[1] = new int[2] { 8, 9 };
            pyramid[2] = new int[3] { 1, 5, 9 };
            pyramid[3] = new int[4] { 4, 5, 2, 3 };
            return pyramid;
            }
        }
    }
