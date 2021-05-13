using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Polygon.Net.Tests.TestManager;

namespace Polygon.Net.Tests.FunctionalTests
{
    [TestClass]
    public class StockApiTests
    {
        [TestMethod]
        public async Task GetAggregatesSucceedsAsync()
        {
            var ticker = "MSFT";
            var multiplier = 2;
            var timespan = "day";
            var from = "2020-10-14";
            var to = "2020-10-20";

            var response = await PolygonTestClient.GetAggregatesAsync(ticker, multiplier, timespan, from, to);

            Assert.IsNotNull(response);
            Assert.AreEqual("OK", response.Status);
            Assert.IsTrue(response.Results.Count >= 1);
            Assert.AreEqual(response.Ticker, ticker);
        }
    }
}