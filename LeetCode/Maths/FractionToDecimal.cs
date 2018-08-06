using System;
using System.Collections;
using System.Text;
namespace LeetCode.Maths
{
    public class FractionToDecimal
    {
		public string Convert(int numerator, int denominator)
		{
            if (numerator == 0)
                return "0";
			int sign = (numerator < 0 && denominator >= 0) || (numerator >= 0 && denominator < 0) ? -1 : 1;
			StringBuilder str = new StringBuilder();
			if (sign == -1)
				str.Append("-");

            long unumerator = numerator;
            if (unumerator < 0)
                unumerator *= -1;
            long udenominator = denominator;
            if(udenominator < 0)
                udenominator *= -1;
			str.Append(unumerator / udenominator);
			long reminder = unumerator % udenominator;

			if (reminder != 0)
			{
				str.Append(".");
				Hashtable map = new Hashtable();
				while (reminder != 0)
				{
					if (map.ContainsKey(reminder))
					{
                        str.Insert((int)map[reminder], "(");
						str.Append(")");
						return str.ToString();
					}
					map.Add(reminder, str.Length);
					reminder *= 10;
					str.Append(reminder / udenominator);
					reminder %= udenominator;
				}
			}
			return str.ToString();
		}
    }
}
