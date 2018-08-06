using System;
namespace LeetCode.Maths
{
    public class DivideTwoNumbers
    {

        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0) return Int32.MaxValue;

            int sign = 1;
            if ((dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0))
            {
                sign = -1;
            }

            uint uDividend = (uint)(dividend < 0 ? dividend * (-1) : dividend);
            uint uDivisor = (uint)(divisor < 0 ? divisor * (-1) : divisor);
            if (uDividend < uDivisor)
                return 0;

            int n = 0;
            var result = sign * Search(uDividend, uDivisor, ref n);
            if (result > Int32.MaxValue)
                return sign > 0 ? Int32.MaxValue : Int32.MinValue;
            return (int)result;
        }

        private uint Search(uint dividend, uint divisor, ref int n)
        {
            // divisor +2*divisor + 4*divisor...< dividend
            uint currentDivisor = divisor * Convert.ToUInt32(Math.Pow(2, n));
            uint reminder = dividend - currentDivisor;
            if (reminder < divisor)
                return Convert.ToUInt32(Math.Pow(2, n));

            if (reminder >= currentDivisor)
            {
                n++;
                return Search(dividend, divisor, ref n);
            }
            else
            {
                uint r = 0;
                int m = 0;
                r = Search(reminder, divisor, ref m);
                return Convert.ToUInt32(Math.Pow(2, n)) + r;
            }

        }
    }
}
