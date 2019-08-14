using GreatestCommonDivisor;
using NUnit.Framework;

namespace GreatestCommonDivisorTests
{
    public class FindGCDTests
    {
        [Test]
        [TestCase(int.MaxValue, 1337, ExpectedResult = 1)]
        [TestCase(int.MinValue, 1337, ExpectedResult = 1)]
        public long SearchByEuclidTest(long x, long y)
        {
            var findGCD = new FindGCD();
            return findGCD.SearchByEuclid(x, y);
        }

        [Test]
        [TestCase(new long[] { 36, 45, 81, 9, 54, 3 }, ExpectedResult = 3)]
        [TestCase(new long[] { int.MaxValue, 1238596, 66, 1337 }, ExpectedResult = 1)]
        [TestCase(new long[] { 14, 1238596, 66, 1312 }, ExpectedResult = 2)]
        public long SearchByEuclidTest(long[] array)
        {
            var findGCD = new FindGCD();
            return findGCD.SearchByEuclid(array);
        }

        [Test]
        [TestCase(int.MaxValue, 1337, ExpectedResult = 1)]
        [TestCase(int.MinValue, 1337, ExpectedResult = 1)]
        public long SearchBySteinTest(long x, long y)
        {
            var findGCD = new FindGCD();
            return findGCD.SearchByStein(x, y);
        }

        [Test]
        [TestCase(new long[] { 36, 45, 81, 9, 54, 3 }, ExpectedResult = 3)]
        [TestCase(new long[] { int.MaxValue, 1238596, 66, 1337 }, ExpectedResult = 1)]
        [TestCase(new long[] { 14, 1238596, 66, 1312 }, ExpectedResult = 2)]
        public long SearchBySteinTest(long[] array)
        {
            var findGCD = new FindGCD();
            return findGCD.SearchByStein(array);
        }

    }
}