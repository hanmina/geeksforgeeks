using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Hard
{
    /// <summary>
    /// https://practice.geeksforgeeks.org/problems/adventure-in-a-maze/0
    /// </summary>
    public class AdventureMaze
    {

        public static Int64 CountPath = 0;
        public static int MaxVal = 0;

        public static int[,] FeedInput(int n)
        {
            Random rd = new Random();
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //a[i, j] = rd.Next(1, 4);
                    a[i, j] = 3;
                }
            }

            return a;
        }



        public static int FindPath(int n, int[,] a)
        {
            if (n < 2)//single cell martrix
            {
                CountPath++;
                return a[0, 0];
            }

            if (a[n - 1, n - 2] == 2 && a[n - 2, n - 1] == 1)//can not reach to last cell
            {
                return 0;
            }

            int i = 0, j = 0, max = 0, curMax = 0, v = 0, boundary = n - 1;
            int maxAproxVal = 3 * (2 * n - 1);
            Stack<int> s = new Stack<int>(n + n);

            do
            {
                v = a[i, j];
                curMax += v;

                if (v == 2)
                    i++;
                else
                    j++;

                v = v > 2 ? ++v : v;
                s.Push(v);

                if (i == boundary && j == boundary)
                {
                    CountPath++;
                    //curMax += a[i, j];
                    max = Math.Max(max, curMax);
                    curMax = 0;
                }

                if (i > boundary || j > boundary)
                {
                    //i = i > boundary ? boundary : i;
                    //j = j > boundary ? boundary : j;
                    s = BackTrack(ref i, ref j, ref curMax, n, s);
                }



            } while (s.Count > 0);

            return max;
        }

        private static Stack<int> BackTrack(ref int i, ref int j, ref int curMax, int n, Stack<int> s)
        {
            int v = 0;
            do
            {
                v = s.Pop();

                if (v == 1 || v == 4)
                    j--;
                else if (v == 2 || v == 5)
                    i--;

                if (v == 4 && i < n - 1)
                {
                    s.Push(5);
                    i++;
                    return s;
                }

                curMax -= v > 3 ? 3 : v;
            } while (s.Count > 0);

            return s;
        }

        public static void FindPath(int n, int x, int y, int[,] a, int v, int curVal)
        {
            if ((x == n - 1) && (y == n - 1))
            {
                CountPath++;
                MaxVal = Math.Max(MaxVal, curVal);
                curVal = 0;
                return;
            }

            if (x >= n || y >= n)
            {
                curVal = 0;
                return;
            }

            if (v == 1 && y < n - 1)
            {
                FindPath(n, x, y + 1, a, a[x, y + 1], a[x, y + 1] + curVal);
                return;
            }

            if (v == 2 && x < n - 1)
            {
                FindPath(n, x + 1, y, a, a[x + 1, y], a[x + 1, y] + curVal);
                return;
            }
            if (v == 3)
            {
                if (y < n - 1)
                    FindPath(n, x, y + 1, a, a[x, y + 1], a[x, y + 1] + curVal);
                if (x < n - 1)
                    FindPath(n, x + 1, y, a, a[x + 1, y], a[x + 1, y] + curVal);
            }
        }
    }
}
