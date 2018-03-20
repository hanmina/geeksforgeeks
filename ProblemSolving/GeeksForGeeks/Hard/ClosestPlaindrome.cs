using System;


namespace GeeksForGeeks.Hard
{
    /// <summary>
    /// https://practice.geeksforgeeks.org/problems/closest-palindrome/0
    /// </summary>
    public class ClosestPlaindrome
    {

        public static long FindClosestPlainDrome(long N)
        {
            bool isNegativeInput = N < 0;
            N = N < 0 ? N * -1 : N;

            long M = N;
            long pre = 0;
            long post = 0;

            if (!IsPlainDrome(N))
                M = MakePlainDrome(N);

            bool isCustomPre =N.ToString().Length > 2 && GoCustomWay(M);
            bool isCustomPost = N.ToString().Length > 2 && GoCustomWay(M, false);

            if (M == N)
            {
                pre = isCustomPre ? MakePrevPlainDrome(M) : GetPrePlainDrome(N);
                post = isCustomPost ? MakeNextPlainDrome(M) : GetPostPlainDrome(N);
            }
            else if (M > N)
            {
                pre = isCustomPre ? MakePrevPlainDrome(M) : GetPrePlainDrome(N);
                post = M;
            }
            else
            {
                pre = M;
                post = isCustomPost ? MakeNextPlainDrome(M) : GetPostPlainDrome(N);
            }

            Console.WriteLine($"\n\n\n#Pre   : {pre} \n#Input : {N} \n#Post  : {post}");

            if (isNegativeInput && (Math.Abs(N - pre) == Math.Abs(N - post)))
            {
                return -post;
            }
            else if (Math.Abs(N - pre) <= Math.Abs(N - post))
            {
                if (isNegativeInput)
                    pre *= -1;

                return pre;
            }
            else
            {
                if (isNegativeInput)
                    post *= -1;

                return post;
            }
        }

        public static bool GoCustomWay(long M, bool isPre = true)
        {
            string sVal = M.ToString();
            int mid = sVal[sVal.Length / 2];

            if (isPre && (mid > 48))
                return true;
            else if (!isPre && mid < 57)
                return true;

            return false;
        }

        public static long GetPrePlainDrome(long N)
        {
            long k = N-1;
            while (k > Int64.MinValue)
            {
                if (IsPlainDrome(k))
                    return k;
                
                k--;
            }

            return -Int64.MaxValue;
        }

        public static long GetPostPlainDrome(long N)
        {
            long k = N+1;
            while (k < Int64.MaxValue)
            {
                if (IsPlainDrome(k))
                    return k;

                k++;
            }

            return Int64.MaxValue;
        }

        public static bool IsPlainDrome(long N)
        {
            N = N < 0 ? N * -1 : N;

            string sVal = N.ToString();
            int first = 0, last = sVal.Length - 1;

            while (first < last)
            {
                if (sVal[first] != sVal[last])
                    return false;
                
                first++;
                last--;
            }

            return true;
        }


        public static long MakePlainDrome(long N)
        {
            string sVal = N.ToString();
            char[] cVal = N.ToString().ToCharArray();
            int first = 0, last = sVal.Length - 1;

            while (first < last)
            {
                if (sVal[first] != sVal[last]){
                    cVal[last] = sVal[first];
                }

                first++;
                last--;
            }

            return Convert.ToInt64(new string(cVal));
        }

        public static long MakeNextPlainDrome(long N)
        {
            string sVal = N.ToString();
            char[] cVal = N.ToString().ToCharArray();
            int mid = 0, len = sVal.Length-1;

            mid = sVal[len / 2];
            if (mid < 57)
            {
                mid++;
                cVal[len / 2] = (char)mid;

                if (len % 2 == 1)
                    cVal[len / 2 + 1] = (char)mid;
            }

            return Convert.ToInt64(new string(cVal));
        }

        public static long MakePrevPlainDrome(long N)
        {
            string sVal = N.ToString();
            char[] cVal = N.ToString().ToCharArray();
            int mid = 0, len = sVal.Length-1;

            mid = sVal[len / 2];
            if (mid > 48)
            {
                mid--;
                cVal[len / 2] = (char)mid;

                if (len % 2 == 1)
                    cVal[len / 2 + 1] = (char)mid;
            }

            return Convert.ToInt64(new string(cVal));
        }


    }
}
