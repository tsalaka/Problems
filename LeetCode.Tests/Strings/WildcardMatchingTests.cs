using NUnit.Framework;
using System;
using LeetCode.Strings;

namespace LeetCode.Tests.Strings
{
    [TestFixture()]
    public class WildcardMatchingTests
    {
        [Test()]
        public void TestCase()
        {
            var r = new WildcardMatching();
           
            Assert.True(r.IsMatch("abbaabbbbababaababababbabbbaaaabbbbaaabbbabaabbbbbabbbbabbabbaaabaaaabbbbbbaaabbabbbbababbbaaabbabbabb", "***b**a*a*b***b*a*b*bbb**baa*bba**b**bb***b*a*aab*a**"));
			Assert.False(r.IsMatch("aa", "a"));
        }
    }
}
