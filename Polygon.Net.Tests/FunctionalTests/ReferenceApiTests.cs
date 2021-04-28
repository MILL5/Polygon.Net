using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using static Polygon.Net.Tests.TestManager;

namespace Polygon.Net.Tests.FunctionalTests
{
    [TestClass]
    public class ReferenceApiTests
    {
        [TestMethod]
        public async Task GetTickerDetailsSucceedsAsync()
        {
            var appleTicker = "AAPL";

            var tickerDetails = await PolygonTestClient.GetTickerDetailsAsync(appleTicker, null);

            Assert.IsNotNull(tickerDetails);
            Assert.AreEqual(appleTicker, tickerDetails.Ticker);
        }

        [TestMethod]
        public async Task GetTickerDetailsWithDateSucceedsAsync()
        {
            var appleTicker = "AAPL";

            var tickerDetails = await PolygonTestClient.GetTickerDetailsAsync(appleTicker, "2019-06-29");

            Assert.IsNotNull(tickerDetails);
            Assert.AreEqual(appleTicker, tickerDetails.Ticker);
            Assert.IsNotNull(tickerDetails.PhoneNumber);
        }

        [TestMethod]
        public async Task GetTickersSucceedsAsync()
        {
            var tickers = await PolygonTestClient.GetTickersAsync();

            Assert.IsNotNull(tickers);
            Assert.IsTrue(tickers.Any());
        }

        [TestMethod]
        public async Task GetTickersWithParamsSucceedsAsync()
        {
            var limitParam = 10;

            var tickers = await PolygonTestClient
                .GetTickersAsync(
                    tickergt: "A",
                    exchange: "XNYS",
                    sort: "ticker",
                    active: true,
                    order: "asc",
                    limit: limitParam
                );

            Assert.IsNotNull(tickers);
            Assert.AreEqual(limitParam, tickers.Count());
        }

        [TestMethod]
        public async Task GetExchangesSucceedsAsync()
        {
            var exchanges = await PolygonTestClient.GetExchangesAsync();

            Assert.IsNotNull(exchanges);
            Assert.IsTrue(exchanges.Any());
        }
    }
}