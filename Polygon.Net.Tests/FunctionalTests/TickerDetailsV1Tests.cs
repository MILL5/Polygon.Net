using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Polygon.Net.Tests.TestManager;

namespace Polygon.Net.Tests.FunctionalTests
{
    [TestClass]
    public class TickerDetailsV1Tests
    {
        private const string TICKER_MSFT = "MSFT";

        [TestMethod]
        public async Task GetTickerDetailsV1SucceedsAsync()
        {
            var tickerDetailsV1 = await PolygonTestClient.GetTickerDetailsV1Async(TICKER_MSFT);

            Assert.IsInstanceOfType(tickerDetailsV1, typeof(TickerDetailsInfoV1));

            Assert.IsNotNull(tickerDetailsV1);
            Assert.AreEqual(TICKER_MSFT, tickerDetailsV1.Symbol);
            Assert.IsNotNull(tickerDetailsV1.Phone);
        }

        [TestMethod]
        public async Task GetTickerDetailsV1NoCikTickerSucceedsAsync()
        {
            var tickerDetailsV1 = await PolygonTestClient.GetTickerDetailsV1Async("AAXJ");

            Assert.IsInstanceOfType(tickerDetailsV1, typeof(TickerDetailsInfoV1));

            Assert.IsNotNull(tickerDetailsV1);
            Assert.AreEqual("AAXJ", tickerDetailsV1.Symbol);
            Assert.IsNull(tickerDetailsV1.Cik);
        }

        [TestMethod]
        public async Task GetTickerDetailsLowerCaseTickerAsync()
        {
            await Assert.ThrowsExceptionAsync<PolygonHttpException>(
                async () => await PolygonTestClient.GetTickerDetailsV1Async("msft"));
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