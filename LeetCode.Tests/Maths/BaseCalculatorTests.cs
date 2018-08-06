﻿using System;
using NUnit.Framework;
using LeetCode.Maths;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.Tests.Maths
{
    [TestFixture]
    public class BaseCalculatorTests
    {
        [TestCase]
        public void TestCase()
        {
            var calc = new BaseCalculator();
            Assert.AreEqual(7, calc.Calculate("3+2*2"));
            var str = new StringBuilder();
            var op = new char[4] { '-', '+', '*', '/' };
            var r = new Random();
            for (int i = 0; i < 100000;i++){
                str.Append(1+r.Next(9));
                str.Append(op[r.Next(4)]);
            }
            var h = new Hashtable();
            str.Remove(str.Length - 1,1);
            calc.Calculate(str.ToString());
        }
    }
}
