﻿using System;
using System.Collections.Generic;
using System.Collections;
namespace LeetCode.Maths
{
    public class BaseCalculator
    {
        public int Calculate(string s)
        {
            var total = 0;
            int current = 0;
            int symb = 1;
            int i = 0;
            // add "+" to the end to exclude index of range exception in inner while cycles
            // and to calculate last operation
            s = s + "+";
            while (i < s.Length)
            {
                while (i <= s.Length && s[i] == ' ') { i++; }
                string term = s.Substring(i, 1);
                if (term == "+" || term == "-")
                {
                    total += current * symb;
                    symb = term == "+" ? 1 : -1;
                    i++;
                }
                else if (term == "*" || term == "/")
                {
                    // get next number
                    while (s[i + 1] == ' ') { i++; };
                    string next = null;
                    while (Char.IsNumber(s[++i])) { next += s[i]; }
                    if (term == "*")
                        current *= Convert.ToInt32(next);
                    else
                        current /= Convert.ToInt32(next);
                }
                else
                {
                    while (Char.IsNumber(s[++i])) { term += s[i]; }
                    current = Convert.ToInt32(term);
                }
            }
            return total;

        }
    }
}
