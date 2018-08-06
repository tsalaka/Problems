using NUnit.Framework;
using System;
namespace LeetCode.Tests
{
    [TestFixture()]
    public class MinHeapTests
    {
        [Test()]
        public void TestCase()
        {
            var minHeap = new MinHeap();
            minHeap.Insert(new MinHeapItem(){Key = 3, Value = 3});
            minHeap.Insert(new MinHeapItem() { Key = 2, Value = 2 });
            minHeap.Insert(new MinHeapItem() { Key = 1, Value = 1 });
            minHeap.Insert(new MinHeapItem() { Key = 5, Value = 5 });
            Assert.AreEqual(1, minHeap.GetMin().Value);
            minHeap.Insert(new MinHeapItem() { Key = 3, Value = 3 });
            Assert.AreEqual(2, minHeap.GetMin().Value);
            minHeap.Insert(new MinHeapItem() { Key = 1, Value = 1 });
            Assert.AreEqual(1, minHeap.GetMin().Value);
            Assert.AreEqual(3, minHeap.GetMin().Value);
            Assert.AreEqual(3, minHeap.GetMin().Value);
        }
    }
}
