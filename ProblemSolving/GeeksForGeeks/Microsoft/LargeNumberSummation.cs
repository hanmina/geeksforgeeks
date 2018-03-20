using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Microsoft
{
    public class LargeNumberSummation
    {
        public static string Sum(string x, string y)
        {
            var result = CalculateSum(x, y);

            if (result.Length == x.Length)
                return result;

            return x;
        }

        public static string CalculateSum(string x, string y)
        {
            Stack<int> stack = new Stack<int>();

            int maxLen = Math.Max(x.Length, y.Length);
            int carry = 0, a = 0, b = 0, reminder = 0;
            StringBuilder sb = new StringBuilder(maxLen + 2);
            x = x.PadLeft(maxLen+1, '0');
            y = y.PadLeft(maxLen+1, '0');

            for (int i= maxLen; i>=0; i--)
            {
                a = Convert.ToInt16(x[i].ToString());
                b = Convert.ToInt16(y[i].ToString());
                reminder = (a + b + carry) % 10;
                carry = (a + b + carry) / 10;
                if (i == 0 && reminder == 0) break;
                sb.Append(reminder);
            }
           
            return Reverse(sb.ToString());
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}
