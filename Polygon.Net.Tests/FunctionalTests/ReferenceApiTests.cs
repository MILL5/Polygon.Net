using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static Polygon.Net.Tests.TestManager;

namespace Polygon.Net.Tests.FunctionalTests
{
    [TestClass]
    public class ReferenceApiTests
    {
        private const string STATUS_OK = "OK";

        [DataTestMethod]
        [DataRow("MSFT")]
        [DataRow("msft")]
        public async Task GetTickerDetailsSucceedsAsync(string microsoftTicker)
        {
            var tickerDetailsResponse = await PolygonTestClient.GetTickerDetailsAsync(microsoftTicker);

            Assert.IsInstanceOfType(tickerDetailsResponse.Results, typeof(TickerDetailsInfo));

            Assert.IsNotNull(tickerDetailsResponse);
            Assert.AreEqual(STATUS_OK, tickerDetailsResponse.Status);
            Assert.AreEqual(microsoftTicker.ToUpper(), tickerDetailsResponse.Results.Ticker);
            Assert.IsNotNull(tickerDetailsResponse.Results.PhoneNumber);
        }

        [DataTestMethod]
        [DataRow("MSFT")]
        [DataRow("msft")]
        public async Task GetTickerDetailsWithDateSucceedsAsync(string microsoftTicker)
        {
            var tickerDetailsResponse = await PolygonTestClient.GetTickerDetailsAsync(microsoftTicker, "2019-06-29");

            Assert.IsInstanceOfType(tickerDetailsResponse.Results, typeof(TickerDetailsInfo));

            Assert.IsNotNull(tickerDetailsResponse);
            Assert.AreEqual(STATUS_OK, tickerDetailsResponse.Status);
            Assert.AreEqual(microsoftTicker.ToUpper(), tickerDetailsResponse.Results.Ticker);
            // Assert.IsNotNull(tickerDetailsResponse.Results.PhoneNumber);
            Assert.IsNotNull(tickerDetailsResponse.Results);
        }

        [TestMethod]
        public async Task GetTickerDetailsNullTickerAsync()
        {
            string ticker = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () => await PolygonTestClient.GetTickerDetailsAsync(ticker));
        }

        [TestMethod]
        public async Task GetTickerDetailsEmptyTickerAsync()
        {
            var ticker = string.Empty;

            await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () => await PolygonTestClient.GetTickerDetailsAsync(ticker));
        }

        [TestMethod]
        public async Task GetTickerDetailsNonExistentTickerAsync()
        {
            var ticker = Guid.NewGuid().ToString();

            await Assert.ThrowsExceptionAsync<PolygonHttpException>(
                async () => await PolygonTestClient.GetTickerDetailsAsync(ticker));
        }

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
        public async Task GetTickersWithBadParamsAsync()
        {
            await Assert.ThrowsExceptionAsync<PolygonHttpException>(
                async () => 
                await PolygonTestClient
                .GetTickersAsync(
                    tickergt: "weryb",
                    exchange: "XNYS",
                    sort: "qw",
                    active: true,
                    order: "asdf",
                    limit: 123));
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

        [TestMethod]
        public async Task GetStockFinancialsNullTickerAsync()
        {
            string ticker = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () =>
                await PolygonTestClient
                .GetStockFinancialsAsync(
                    stocksTicker: ticker,
                    type: "Y",
                    sort: "calendarDate",
                    limit: 5));
        }

        [TestMethod]
        public async Task GetStockFinancialsEmptyTickerAsync()
        {
            var ticker = string.Empty;

            await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () =>
                await PolygonTestClient
                .GetStockFinancialsAsync(
                    stocksTicker: ticker,
                    type: "Y",
                    sort: "calendarDate",
                    limit: 5));
        }

        [TestMethod]
        public async Task GetStockFinancialsBadParametersAsync()
        {
            await Assert.ThrowsExceptionAsync<PolygonHttpException>(
                async () =>
                await PolygonTestClient
                .GetStockFinancialsAsync(
                    stocksTicker: "AAPL",
                    type: "adsfasdf",
                    sort: "cxzvcxzcvz",
                    limit: 500000));
        }
    }
}