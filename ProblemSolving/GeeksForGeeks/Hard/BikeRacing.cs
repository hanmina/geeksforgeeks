using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Hard
{
    /// <summary>
    /// https://practice.geeksforgeeks.org/problems/bike-racing/0
    /// </summary>
    public class BikeRacing
    {
        //Constraints:
        //1<=T<=100
        //1<=N<=1e5
        //1 ≤ M,L ≤ 1e10
        //1 ≤ Hi, Ai ≤ 1e9

        //1
        //3 400 120
        //20 20
        //50 70
        //20 90

        public static void ReadInputs()
        {
            foreach (string line in File.ReadLines(@"D:\ProblemSolving\geeksforgeeks\ProblemSolving\GeeksForGeeks\Questions\inputs.txt"))
            {
                Console.WriteLine("-- {0}", line);
            }
        }

        //Its Correct output is:
        //16816927

        //And Your Code's output is:
        //33554433
        public static void TestMethod(long[,] a, int N, long M, long L)
        {
            int T = 1;

            for (int i = 0; i < T; i++)//number of test
            {
                //calculate speed v=u+at
                long totalSpeed = 0, sum = 0;
                int minHours = 0, low = 0, mid = 0, high = 0;
                bool isBreak = false;
                do
                {
                    totalSpeed = 0;
                    for (int m = 0; m < N; m++)
                    {
                        sum = a[m, 0] + a[m, 1] * minHours;
                        totalSpeed += sum >= L ? sum : 0;
                        if (totalSpeed >= M)
                        {
                            isBreak = true;
                            break;
                        }
                    }

                    if (!isBreak)
                    {
                        if (minHours == 0)
                            minHours += 1;
                        else
                            minHours *= 2;
                    }
                } while (totalSpeed <= M);

                high = minHours;
                low = minHours / 2;
                mid = (high + low) / 2;

                while (high - low > 1)
                {
                    mid = (high + low) / 2;
                    if (IsOverSpeedTotal(N, M, L, a, mid))
                        high = mid;
                    else
                        low = mid;
                }
                //16816927
                Console.WriteLine(high);
            }
        }

        public static bool IsOverSpeedTotal(long N, long M, long L, long[,] a, int hour)
        {
            long totalSpeed = 0, sum = 0;

            for (int m = 0; m < N; m++)
            {
                sum = a[m, 0] + a[m, 1] * hour;
                totalSpeed += sum >= L ? sum : 0;
                if (totalSpeed >= M)
                    return true;
            }

            return false;
        }

        public static void FindMinHourToBellRing()
        {
            int T = 1, N = 0;
            long M = 0, L = 0;

            T = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < T; i++)//number of test
            {
                var line = Console.ReadLine();
                var s = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (s.Length != 3)//3-inputs N, M & L
                    throw new Exception("Invalid input");
                N = Convert.ToInt16(s[0]);
                M = Convert.ToInt64(s[1]);
                L = Convert.ToInt64(s[2]);

                long[,] a = new long[N, 2];
                for (int j = 0; j < N; j++)//read N number biker inputs
                {
                    line = Console.ReadLine();
                    s = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (s.Length != 2)//2-inputs for H & A
                        throw new Exception("Invalid input");
                    a[j, 0] = Convert.ToInt64(s[1]);//H initial speed(u)
                    a[j, 1] = Convert.ToInt64(s[1]);//A accelaration
                }

                //calculate speed v=u+at
                long totalSpeed = 0, sum = 0;
                int minHours = 0, low = 0, mid = 0, high = 0;
                bool isBreak = false;
                do
                {
                    totalSpeed = 0;
                    for (int m = 0; m < N; m++)
                    {
                        sum = a[m, 0] + a[m, 1] * minHours;
                        totalSpeed += sum >= L ? sum : 0;
                        if (totalSpeed >= M)
                        {
                            isBreak = true;
                            break;
                        }
                    }

                    if (!isBreak)
                    {
                        if (minHours == 0)
                            minHours += 1;
                        else
                            minHours *= 2;
                    }
                }
                while (totalSpeed <= M);

                high = minHours;
                low = minHours / 2;
                mid = (high + low) / 2;

                while (high - low > 1)
                {
                    mid = (high + low) / 2;
                    if (IsOverSpeedTotal(N, M, L, a, mid))
                        high = mid;
                    else
                        low = mid;
                }
                //16816927
                Console.WriteLine(high);
            }
        }
        public static void SequencialCalcuation()
        {
            int T = 1, N = 0;
            long M = 0, L = 0;

            T = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < T; i++)//number of test
            {
                var line = Console.ReadLine();
                var s = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (s.Length != 3)//3-inputs N, M & L
                    throw new Exception("Invalid input");
                N = Convert.ToInt16(s[0]);
                M = Convert.ToInt64(s[1]);
                L = Convert.ToInt64(s[2]);

                long[,] a = new long[N, 2];
                for (int j = 0; j < N; j++)//read N number biker inputs
                {
                    line = Console.ReadLine();
                    s = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (s.Length != 2)//2-inputs for H & A
                        throw new Exception("Invalid input");
                    a[j, 0] = Convert.ToInt64(s[1]);//H initial speed(u)
                    a[j, 1] = Convert.ToInt64(s[1]);//A accelaration
                }

                //calculate speed v=u+at
                long totalSpeed = 0, sum = 0;
                int minHours = 0;

                do
                {
                    for (int m = 0; m < N; m++)
                    {
                        sum = a[m, 0] + a[m, 1] * minHours;
                        totalSpeed += sum >= L ? sum : 0;
                        if (totalSpeed >= M)
                            break;
                    }

                    minHours++;
                }
                while (totalSpeed <= M);

                Console.WriteLine(minHours--);
            }
        }
    }
}
