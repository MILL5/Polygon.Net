using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polygon.Net.Models;

namespace Polygon.Net.Tests.ModelTests;

[TestClass]
public class TickerTypeTests
{
    private static readonly TickerType BASE_TICKER_TYPE = new() { AssetClass = AssetClass.Stocks, Code = "CS", Description = "Common Stock", Locale = Locale.Us };

    [TestMethod]
    public void TickerTypeEqualsSucceed()
    {
        var actual = BASE_TICKER_TYPE;
        var expected = BASE_TICKER_TYPE;

        Assert.IsTrue(actual.Equals(expected));
    }

    [TestMethod]
    public void TickerTypeNotEqualsSucceed()
    {
        var actual = BASE_TICKER_TYPE;
        var expected = new TickerType() { AssetClass = AssetClass.Stocks, Code = "WARRANT", Description = "Warrant", Locale = Locale.Us };

        Assert.IsFalse(actual.Equals(expected));
    }

    [TestMethod]
    public void TickerTypeHashCodeSucceed()
    {
        var actual = BASE_TICKER_TYPE;
        var actualHashCode = actual.GetHashCode();

        var expected = -892520635;

        Assert.AreEqual(expected, actualHashCode);
    }
}
