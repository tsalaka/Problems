using NUnit.Framework;
using System;
using LeetCode.DynamicProgramming;

namespace LeetCode.Tests.DynamicProgramming
{
    [TestFixture()]
    public class MoneyExchangerTests
    {
        [Test()]
        public void TestCase()
        {
            var exch = new MoneyExchanger();
            Assert.AreEqual(-1, exch.GetExchange(new int[]{2}, 3));
            var coins = new int[] { 1, 2, 5 };

            Assert.AreEqual(3, exch.GetExchange(coins, 11));
            Assert.AreEqual(4, exch.GetExchange(coins, 13));

			coins = new int[] { 2, 4, 5 };

			Assert.AreEqual(5, exch.GetExchange(coins, 21));

            Assert.AreEqual(-1, exch.GetExchange(new int[]{2, 6}, 15));


        }
    }
}
