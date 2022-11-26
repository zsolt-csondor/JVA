using NUnit.Framework;
using Primes.API.Core;

namespace Primes.Tests;

[TestFixture]
public class PrimesManagerTests
{
    [Test]
    [TestCase(1, new int[] { })]
    [TestCase(5, new int[] {2,3,5})]
    [TestCase(20, new int[] { 2, 3, 5, 7, 11, 13, 17, 19 })]
    [TestCase(100, new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]

    public void GetPrimesToLimit_ShouldReturnCorrectPrimes(int limit, int[] expectedPrimes)
    {
        var primesManager = new PrimesManager();

        int[] actualPrimes = primesManager.GetPrimesToLimit(limit);

        Assert.AreEqual(expectedPrimes, actualPrimes);
    }

    [Test]
    public void GetPrimesToLimit_ShouldThrowExceptionOnNegativeLimit()
    {
        int negativeLimit = -1;
        var primesManager = new PrimesManager();

        Assert.Throws<ArgumentOutOfRangeException>(() => primesManager.GetPrimesToLimit(negativeLimit));
    }

    [Test]
    public void GetPrimesToLimit_ShouldThrowExceptionOnZeroLimit()
    {
        int zeroLimit = 0;
        var primesManager = new PrimesManager();

        Assert.Throws<ArgumentOutOfRangeException>(() => primesManager.GetPrimesToLimit(zeroLimit));
    }

    [Test]
    public void GetPrimesToLimit_ShouldThrowExceptionOnTooLargeLimit()
    {
        int tooLargeLimit = 101;
        var primesManager = new PrimesManager();

        Assert.Throws<ArgumentOutOfRangeException>(() => primesManager.GetPrimesToLimit(tooLargeLimit));
    }
}