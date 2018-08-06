using System;
using NUnit.Framework;
using LeetCode.DynamicProgramming;

namespace LeetCode.Tests.DynamicProgramming
{
    [TestFixture]
    public class CountUniqPalindromicSubsequencesTests
    {
        [TestCase]
		public void TestCase()
		{
            var p = new CountUniqPalindromicSubsequences();
            var result = p.CountPalindromicSubsequences("aa");
            Assert.AreEqual(2, result);

		    result = p.CountPalindromicSubsequences("aab");
			Assert.AreEqual(3, result);

			result = p.CountPalindromicSubsequences("aaa");
			Assert.AreEqual(3, result);

			result = p.CountPalindromicSubsequences("aabbcb");
			Assert.AreEqual(8, result);


            result = p.CountPalindromicSubsequences("bccb");
            Assert.AreEqual(6, result);

           // result = p.CountPalindromicSubsequences("abcdabcdabcdabcdabcdabcdabcdabcddcbadcbadcbadcbadcbadcbadcbadcba");
            //Assert.AreEqual(104860361, result);
		}
    }
}
