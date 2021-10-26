using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using static Polygon.Net.Tests.TestManager;

namespace Polygon.Net.Tests.FunctionalTests
{
    [TestClass]
    public class TickerDetailsV1Tests
    {
        private const string TICKER_MSFT = "MSFT";
        private const string TICKER_AAPL = "AAPL";
        private const string TICKER_NULL_LISTDATE = "AWH";


        [DataTestMethod]
        [DataRow(TICKER_MSFT)]
        [DataRow(TICKER_NULL_LISTDATE)]
        public async Task GetTickerDetailsV1SucceedsAsync(string ticker)
        {
            var tickerDetailsV1 = await PolygonTestClient.GetTickerDetailsV1Async(ticker);

            Assert.IsInstanceOfType(tickerDetailsV1, typeof(TickerDetailsInfoV1));

            Assert.IsNotNull(tickerDetailsV1);
            Assert.AreEqual(ticker, tickerDetailsV1.Symbol);
            Assert.IsNotNull(tickerDetailsV1.Phone);
        }

        [TestMethod]
        public async Task GetTickerDetailsV1WithExpansionSucceedsAsync()
        {
            var tickerDetailsV1 = await PolygonTestClient.GetTickerDetailsV1Async(TICKER_AAPL, true);

            Assert.IsInstanceOfType(tickerDetailsV1, typeof(TickerDetailsInfoV1));

            Assert.IsNotNull(tickerDetailsV1);
            Assert.AreEqual(TICKER_AAPL, tickerDetailsV1.Symbol);
            Assert.IsTrue(tickerDetailsV1.Name.Contains("Incorporated"));
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