using System;
namespace LeetCode.Maths
{
    public class BaseCalculator2
    {
        public int Calculate(string s)
        {
            int i = 0;
            return Convert.ToInt32(Calculate(s, ref i));
        }

        public long Calculate(string s, ref int i)
        {
            long total = 0;
            int sign = 1;
            s += '+';
            long current = 0;
            string term;
            while (i < s.Length)
            {
                while (i < s.Length && s[i] == ' ') i++;
                term = s.Substring(i, 1);
                if (term == "+" || term == "-")
                {
                    total += sign * current;
                    sign = term == "+" ? 1 : -1;
                    current = 0;
                    i++;
                }
                else if (term == "*" || term == "/")
                {
                    while (i + 1 < s.Length && s[i + 1] == ' ') i++;
                    long nextTerm = 0;
                    if (s[++i] == '(')
                    {
                        i++;
                        nextTerm = Calculate(s, ref i);
                    }
                    else
                    {
                        string next = null;
                        while (Char.IsNumber(s[i])) next += s[i++];
                        nextTerm = Convert.ToInt64(next);
                    }
                    if (term == "*")
                        current *= nextTerm;
                    else
                        current /= nextTerm;
                }
                else if (term == "(")
                {
                    i++;
                    current = Calculate(s, ref i);
                }
                else if (term == ")")
                {
                    total += sign * current;
                    i++;
                    return total;
                }
                else
                {
                    while (Char.IsNumber(s[++i])) term += s[i];
                    current = Convert.ToInt64(term);
                }
            }
            return total;

        }
    }
}
