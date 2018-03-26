using System;
using System.IO;
using GeeksForGeeks.Hard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class GeeksForGeeksTest
    {
        [TestMethod]
        public void Test_LargeNumberSummation()
        {

        }

        [TestMethod]
        public void Test_Adventure_Maze()
        {
            //var a= AdventureMaze.FeedInput(5);
            // AdventureMaze.FindPath(5, a);

            //int[,] b = new int[,] { { 3, 1, 2 }, { 2, 1, 2 }, { 1, 1, 2 } };

            //b = new int[,] { { 3, 2, 2 }, { 2, 1, 1 }, { 1, 1, 3 } };
            //b = new int[,] { { 3, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } };
            //b = new int[,] { { 1, 3, 2 }, { 1, 2, 2 }, { 3, 3, 3 } };
            //b = new int[,] { { 1, 1, 3, 2, 1 }, { 3, 2, 2, 1, 2 }, { 1, 3, 3, 1, 3 }, { 1, 2, 3, 1, 2 }, { 1, 1, 1, 3, 1 } };

            //b = new int[,] { { 3, 3, 3, 3, 3 }, { 3, 3, 3, 3, 3 }, { 3, 3, 3, 3, 3 }, { 3, 3, 3, 3, 3 }, { 3, 3, 3, 3, 3 } };

            int n = 15;
            var b = AdventureMaze.FeedInput(n);

            AdventureMaze.FindPath(n, 0, 0, b, b[0, 0], b[0, 0]);
            var path = AdventureMaze.CountPath;
            var max = AdventureMaze.MaxVal;
        }

        [TestMethod]
        public void Find_Path()
        {
            var t = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < t; i++)//no of test
            {
                var n = Convert.ToInt16(Console.ReadLine());//matrix size
                int[,] a = new int[n, n];

                for (int j = 0; j < n; j++) // read input one per line
                {
                    var line = Console.ReadLine();
                    var s = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (n != s.Length)
                        throw new Exception("Invalid input");

                    for (int k = 0; k < n; k++)
                        a[j, k] = Convert.ToInt16(s[k]);//fill matrix
                }
                AdventureMaze.FindPath(n, 0, 0, a, a[0, 0], a[0, 0]);
                Console.WriteLine($"{AdventureMaze.CountPath} {AdventureMaze.MaxVal}");
            }
        }

        [TestMethod]
        public void do_while()
        {
            //3383 846930886 1681692777
            //int N = 3383;
            //long M = 846930886, L = 1681692777;
            //var a = ReadInputs();
            //BikeRacing.TestMethod(a, N, M, L);

            int N = 3;
            long M = 400, L = 120;
            long[,] a = new long[N, 2];
            a[0, 0] = 20;
            a[0, 1] = 20;
            a[1, 0] = 50;
            a[1, 1] = 70;
            a[2, 0] = 20;
            a[2, 1] = 90;

            BikeRacing.TestMethod(a, N, M, L);

        }


        public static long[,] ReadInputs()
        {
            //3383 846930886 1681692777
            //Its Correct output is:
            //16816927

            //And Your Code's output is:
            //33554433

            int N = 3383;
            long[,] a = new long[N, 2];
            int j = 0;
            foreach (string line in File.ReadLines(@"D:\ProblemSolving\geeksforgeeks\ProblemSolving\GeeksForGeeks\Questions\inputs.txt"))
            {
                var s = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (s.Length != 2)//2-inputs for H & A
                    throw new Exception("Invalid input");
                a[j, 0] = Convert.ToInt64(s[1]);//H initial speed(u)
                a[j, 1] = Convert.ToInt64(s[1]);//A accelaration
                j++;
            }

            return a;
        }


    }
}
