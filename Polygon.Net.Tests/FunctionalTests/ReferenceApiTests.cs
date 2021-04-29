using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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

            Assert.IsInstanceOfType(tickersRepsonse.Results, typeof(List<TickerInfo>));

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

            Assert.IsInstanceOfType(tickersRepsonse.Results, typeof(List<TickerInfo>));

            Assert.IsNotNull(tickersRepsonse);
            Assert.AreEqual(STATUS_OK, tickersRepsonse.Status);
            Assert.AreEqual(tickersRepsonse.Count, tickersRepsonse.Results.Count);
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
            Assert.AreEqual(tickersRepsonse.Count, tickersRepsonse.Results.Count);
            Assert.AreEqual(limitParam, tickersRepsonse.Results.Count);

            var tickersRepsonseNextPage = await PolygonTestClient.GetTickersAsync(nextUrl: tickersRepsonse.NextUrl);

            Assert.IsNotNull(tickersRepsonseNextPage);
            Assert.AreEqual(STATUS_OK, tickersRepsonseNextPage.Status);
            Assert.AreEqual(tickersRepsonseNextPage.Count, tickersRepsonseNextPage.Results.Count);
            Assert.AreEqual(limitParam, tickersRepsonseNextPage.Results.Count);
        }

        [TestMethod]
        public async Task GetTickerDetailsSucceedsAsync()
        {
            var appleTicker = "AAPL";

            var tickerDetailsResponse = await PolygonTestClient.GetTickerDetailsAsync(appleTicker, null);

            Assert.IsInstanceOfType(tickerDetailsResponse.Results, typeof(TickerDetailsInfo));

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

            Assert.IsInstanceOfType(tickerDetailsResponse.Results, typeof(TickerDetailsInfo));

            Assert.IsNotNull(tickerDetailsResponse);
            Assert.AreEqual(STATUS_OK, tickerDetailsResponse.Status);
            Assert.AreEqual(appleTicker, tickerDetailsResponse.Results.Ticker);
            Assert.IsNotNull(tickerDetailsResponse.Results.PhoneNumber);
        }

        [TestMethod]
        public async Task GetStockExchangesSucceedsAsync()
        {
            var exchanges = await PolygonTestClient.GetStockExchangesAsync();

            Assert.IsInstanceOfType(exchanges, typeof(List<ExchangeInfo>));

            Assert.IsNotNull(exchanges);
            Assert.IsTrue(exchanges.Any());
        }

        [TestMethod]
        public async Task GetStockFinancialsWithParamsSucceedsAsync()
        {
            var limitParam = 5;

            var stockFinancialsRepsonse = await PolygonTestClient
                .GetStockFinancialsAsync(
                    stocksTicker: "AAPL",
                    type: "Y",
                    sort: "calendarDate",
                    limit: limitParam
                );

            Assert.IsInstanceOfType(stockFinancialsRepsonse, typeof(PolygonResponse<List<StockFinancialInfo>>));

            Assert.IsNotNull(stockFinancialsRepsonse);
            Assert.AreEqual(STATUS_OK, stockFinancialsRepsonse.Status);
            //Assert.AreEqual(stockFinancialsRepsonse.Count, stockFinancialsRepsonse.Results.Count); API doc says count is provided, but it is not
            Assert.AreEqual(limitParam, stockFinancialsRepsonse.Results.Count);
        }
    }
}