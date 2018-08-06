using System;
using NUnit.Framework;
using LeetCode.Arrays;
using System.Collections.Generic;
namespace LeetCode.Tests.Arrays
{
    [TestFixture]
    public class ReverseWordsTests
    {
        [TestCase]
        public void TestCase()
        {
            var r = new ReverseWords();
            var arr = new char[] { 't', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e' };
            r.Reverse(arr);
            Assert.AreEqual("blue is sky the", new String(arr));

			arr = new char[] { 'a', ' ', 'b', ' ', 'c', ' ', 'd', ' ','e'};
			r.Reverse(arr);
			Assert.AreEqual("e d c b a", new String(arr));

			arr = new char[] { 'a', 'b', 'c', 'd', 'e' };
			r.Reverse(arr);
			Assert.AreEqual("abcde", new String(arr));
        }
		
    }
}
