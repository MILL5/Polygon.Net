using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using static Polygon.Net.Tests.TestManager;

namespace Polygon.Net.Tests.FunctionalTests
{
    [TestClass]
    public class ReferenceApiTests
    {
        private const string STATUS_OK = "OK";

        [TestMethod]
        public async Task GetTickersSucceedsAsync()
        {
            var tickersRepsonse = await PolygonTestClient.GetTickersAsync();

            Assert.IsNotNull(tickersRepsonse);
            Assert.AreEqual(STATUS_OK, tickersRepsonse.Status);
            Assert.IsTrue(tickersRepsonse.Results.Any());
        }

        [TestMethod]
        public async Task GetTickersWithParamsSucceedsAsync()
        {
            var limitParam = 10;

            var tickersRepsonse = await PolygonTestClient
                .GetTickersAsync(
                    tickergt: "A",
                    exchange: "XNYS",
                    sort: "ticker",
                    active: true,
                    order: "asc",
                    limit: limitParam
                );

            Assert.IsNotNull(tickersRepsonse);
            Assert.AreEqual(STATUS_OK, tickersRepsonse.Status);
            Assert.AreEqual(limitParam, tickersRepsonse.Results.Count);
        }

        [TestMethod]
        public async Task GetTickersPaginationSucceedsAsync()
        {
            var limitParam = 10;

            var tickersRepsonse = await PolygonTestClient
                .GetTickersAsync(
                    tickergt: "A",
                    exchange: "XNYS",
                    sort: "ticker",
                    active: true,
                    order: "asc",
                    limit: limitParam
                );

            Assert.IsNotNull(tickersRepsonse);
            Assert.AreEqual(STATUS_OK, tickersRepsonse.Status);
            Assert.AreEqual(limitParam, tickersRepsonse.Results.Count);

            var tickersRepsonseNextPage = await PolygonTestClient.GetTickersAsync(nextUrl: tickersRepsonse.NextUrl);

            Assert.IsNotNull(tickersRepsonseNextPage);
            Assert.AreEqual(STATUS_OK, tickersRepsonseNextPage.Status);
            Assert.AreEqual(limitParam, tickersRepsonseNextPage.Results.Count);
        }

        [TestMethod]
        public async Task GetTickerDetailsSucceedsAsync()
        {
            var appleTicker = "AAPL";

            var tickerDetailsResponse = await PolygonTestClient.GetTickerDetailsAsync(appleTicker, null);

            Assert.IsNotNull(tickerDetailsResponse);
            Assert.AreEqual(STATUS_OK, tickerDetailsResponse.Status);
            Assert.AreEqual(appleTicker, tickerDetailsResponse.Results.Ticker);
            Assert.IsNotNull(tickerDetailsResponse.Results.PhoneNumber);
        }

        [TestMethod]
        public async Task GetTickerDetailsWithDateSucceedsAsync()
        {
            var appleTicker = "AAPL";

            var tickerDetailsResponse = await PolygonTestClient.GetTickerDetailsAsync(appleTicker, "2019-06-29");

            Assert.IsNotNull(tickerDetailsResponse);
            Assert.AreEqual(STATUS_OK, tickerDetailsResponse.Status);
            Assert.AreEqual(appleTicker, tickerDetailsResponse.Results.Ticker);
            Assert.IsNotNull(tickerDetailsResponse.Results.PhoneNumber);
        }

        [TestMethod]
        public async Task GetStockExchangesSucceedsAsync()
        {
            var exchanges = await PolygonTestClient.GetStockExchangesAsync();

            Assert.IsNotNull(exchanges);
            Assert.IsTrue(exchanges.Any());
        }
    }
}