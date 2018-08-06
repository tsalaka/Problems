using NUnit.Framework;
using System;
using LeetCode.Trees;
using System.Collections.Generic;

namespace LeetCode.Tests.Trees
{
    [TestFixture()]
    public class TrieTests
    {
        [Test()]
        public void TestCase()
        {
            Trie obj = new Trie();
            obj.Insert("abc");
            obj.Insert("abgl");
            obj.Insert("cdf");
            obj.Insert("abcd");
            obj.Insert("lmn");

            obj.Delete("abcd");
            Assert.False(obj.Search("abcd"));
            Assert.True(obj.Search("abc"));
            obj.Delete("abc");
            Assert.False(obj.Search("abc"));
            Assert.True(obj.Search("abgl"));
            Assert.True(obj.StartsWith("ab"));
            obj.Delete("abgl");
            Assert.False(obj.Search("abgl"));
            Assert.False(obj.StartsWith("ab"));
            Assert.False(obj.StartsWith("a"));

            obj.Insert("abgl");
            obj.Insert("abcd");
            obj.Insert("abc");
			obj.Delete("abc");
			Assert.False(obj.Search("abc"));
            Assert.True(obj.Search("abcd"));
            obj.Insert("abc");
            Assert.True(obj.StartsWith("lm"));
            Assert.True(obj.StartsWith("cd"));
            Assert.True(obj.StartsWith("abg"));
            Assert.True(obj.StartsWith("abc"));
            Assert.False(obj.StartsWith("am"));
            Assert.False(obj.StartsWith("lo"));
            Assert.False(obj.StartsWith("abm"));

            Assert.True(obj.Search("abc"));
            Assert.True(obj.Search("abcd"));
            Assert.True(obj.Search("lmn"));
            Assert.True(obj.Search("abgl"));
            Assert.True(obj.Search("cdf"));
            Assert.False(obj.Search("ab"));
            Assert.False(obj.Search("abg"));
            Assert.False(obj.Search("lmk"));
            Assert.False(obj.Search("lm"));
        }
       
    }
}
