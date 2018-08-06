using NUnit.Framework;
using System.Collections.Generic;
using LeetCode.LinkedList.Cache;

namespace LeetCode.Tests.LinkedList
{
    [TestFixture()]
    public class LRUCacheTests
    {
        [Test()]
        public void TestCase()
        {
            var cache = new LRUCache(3);
			cache.Put(1, 1);
			cache.Put(2, 2);
			cache.Put(3, 3);
            cache.Put(3, 5);
            cache.Put(4, 4);
            cache.Put(1, 4);
			Assert.AreEqual(4, cache.Get(4));
            Assert.AreEqual(-1, cache.Get(5));
            Assert.AreEqual(5, cache.Get(3));
            Assert.AreEqual(-1, cache.Get(2));
            cache.Put(3, 10);
            Assert.AreEqual(4, cache.Get(1));
            cache.Put(5,5);
            Assert.AreEqual(-1, cache.Get(1));
            Assert.AreEqual(10, cache.Get(3));
            Assert.AreEqual(4, cache.Get(4));
            cache.Put(6, 1);
            Assert.AreEqual(-1, cache.Get(4));
        }
    }
}
