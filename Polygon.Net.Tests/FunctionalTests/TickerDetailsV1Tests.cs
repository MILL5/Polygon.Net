using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Polygon.Net.Tests.TestManager;

namespace Polygon.Net.Tests.FunctionalTests
{
    [TestClass]
    public class TickerDetailsV1Tests
    {
        [DataTestMethod]
        [DataRow("MSFT")]
        [DataRow("msft")]
        public async Task GetTickerDetailsV1SucceedsAsync(string microsoftTicker)
        {
            var tickerDetailsV1 = await PolygonTestClient.GetTickerDetailsV1Async(microsoftTicker);

            Assert.IsInstanceOfType(tickerDetailsV1, typeof(TickerDetailsInfoV1));

            Assert.IsNotNull(tickerDetailsV1);
            Assert.AreEqual(microsoftTicker.ToUpper(), tickerDetailsV1.Symbol);
            Assert.IsNotNull(tickerDetailsV1.Phone);
        }
        
        [TestMethod]
        public async Task GetTickerDetailsNullTickerAsync()
        {
            string ticker = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () => await PolygonTestClient.GetTickerDetailsV1Async(ticker));
        }

        [TestMethod]
        public async Task GetTickerDetailsEmptyTickerAsync()
        {
            var ticker = string.Empty;

            await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () => await PolygonTestClient.GetTickerDetailsV1Async(ticker));
        }

        [TestMethod]
        public async Task GetTickerDetailsNonExistentTickerAsync()
        {
            var ticker = Guid.NewGuid().ToString();

            await Assert.ThrowsExceptionAsync<PolygonHttpException>(
                async () => await PolygonTestClient.GetTickerDetailsV1Async(ticker));
        }
    }
}