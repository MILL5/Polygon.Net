using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polygon.Net.Models;
using static Polygon.Net.Tests.TestManager;

namespace Polygon.Net.Tests.FunctionalTests
{
    [TestClass]
    public class ReferenceApiTests
    {
        private const string STATUS_OK = "OK";

        private const string TICKER_MSFT = "MSFT";
        private const string TICKER_AAPL = "AAPL";
        private const string APPLE_EXPANDED = "Apple Incorporated";

        [TestMethod]
        public async Task GetTickerDetailsSucceedsAsync()
        {
            var tickerDetailsResponse = await PolygonTestClient.GetTickerDetailsAsync(TICKER_MSFT);

            Assert.IsInstanceOfType(tickerDetailsResponse.Results, typeof(TickerDetailsInfo));

            Assert.IsNotNull(tickerDetailsResponse);
            Assert.AreEqual(STATUS_OK, tickerDetailsResponse.Status);
            Assert.AreEqual(TICKER_MSFT, tickerDetailsResponse.Results.Ticker);
            Assert.IsNotNull(tickerDetailsResponse.Results.PhoneNumber);
        }

        [TestMethod]
        public async Task GetTickerDetailsWithExpansionSucceedsAsync()
        {
            var tickerDetailsResponse = await PolygonTestClient.GetTickerDetailsAsync(TICKER_AAPL, expandAbbreviations: true);

            Assert.IsInstanceOfType(tickerDetailsResponse.Results, typeof(TickerDetailsInfo));

            Assert.IsNotNull(tickerDetailsResponse);
            Assert.AreEqual(STATUS_OK, tickerDetailsResponse.Status);
            Assert.AreEqual(TICKER_AAPL, tickerDetailsResponse.Results.Ticker);
            Assert.IsTrue(tickerDetailsResponse.Results.Name == APPLE_EXPANDED);
            Assert.IsNotNull(tickerDetailsResponse.Results.PhoneNumber);
        }

        [TestMethod]
        public async Task GetTickerDetailsLowerCaseTickerAsync()
        {
            await Assert.ThrowsExceptionAsync<PolygonHttpException>(
                async () => await PolygonTestClient.GetTickerDetailsAsync("msft"));
        }

        [TestMethod]
        public async Task GetTickerDetailsWithDateSucceedsAsync()
        {
            var tickerDetailsResponse = await PolygonTestClient.GetTickerDetailsAsync(TICKER_MSFT, "2019-06-29");

            Assert.IsInstanceOfType(tickerDetailsResponse.Results, typeof(TickerDetailsInfo));

            Assert.IsNotNull(tickerDetailsResponse);
            Assert.AreEqual(STATUS_OK, tickerDetailsResponse.Status);
            Assert.AreEqual(TICKER_MSFT, tickerDetailsResponse.Results.Ticker);
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
        public async Task GetTickersWithExpansionSucceedsAsync()
        {
            var tickersRepsonse = await PolygonTestClient.GetTickersAsync(expandAbbreviations: true);

            Assert.IsInstanceOfType(tickersRepsonse.Results, typeof(List<TickerInfo>));

            Assert.IsNotNull(tickersRepsonse);
            Assert.AreEqual(STATUS_OK, tickersRepsonse.Status);
            Assert.IsTrue(tickersRepsonse.Results.Any());

            var aaplTicker = tickersRepsonse.Results.First(x => x.Ticker == TICKER_AAPL);

            Assert.IsTrue(aaplTicker.Name == APPLE_EXPANDED);
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

            Assert.IsInstanceOfType(stockFinancialsRepsonse, typeof(StockFinancialsResponse));

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

        [TestMethod]
        public async Task GetStockDividendSucceedsAsync()
        {
            var stockDividendsResponse = await PolygonTestClient.GetStockDividendsAsync("AFIN");

            Assert.IsInstanceOfType(stockDividendsResponse, typeof(StockDividendsResponse));

            Assert.IsNotNull(stockDividendsResponse);
            Assert.IsTrue(stockDividendsResponse.Count >= 1);

            var dividend = stockDividendsResponse.Results.FirstOrDefault();

            Assert.AreEqual("AFIN", dividend.Ticker);
            Assert.IsTrue(DateTime.TryParse(dividend.ExDate, out _));
            Assert.IsTrue(DateTime.TryParse(dividend.RecordDate, out _));
            Assert.IsTrue(DateTime.TryParse(dividend.PaymentDate, out _));
            Assert.AreEqual(STATUS_OK, stockDividendsResponse.Status);
        }

        [TestMethod]
        public async Task GetStockDividendBadTickerAsync()
        {
            var stockDividendsResponse = await PolygonTestClient.GetStockDividendsAsync("1AP2L3");

            Assert.IsInstanceOfType(stockDividendsResponse, typeof(StockDividendsResponse));

            Assert.IsNotNull(stockDividendsResponse);
            Assert.AreEqual(0, stockDividendsResponse.Count);
            Assert.AreEqual(STATUS_OK, stockDividendsResponse.Status);
        }

        [TestMethod]
        public async Task GetStockSplitSucceedsAsync()
        {
            var stockSplitsResponse = await PolygonTestClient.GetStockSplitsAsync(TICKER_AAPL);

            Assert.IsInstanceOfType(stockSplitsResponse, typeof(StockSplitsResponse));

            Assert.IsNotNull(stockSplitsResponse);
            Assert.IsTrue(stockSplitsResponse.Count >= 1);

            var split = stockSplitsResponse.Results.FirstOrDefault();

            Assert.AreEqual(stockSplitsResponse.Results.FirstOrDefault().Ticker, TICKER_AAPL);
            Assert.IsTrue(DateTime.TryParse(split.ExDate, out _));
            Assert.IsTrue(DateTime.TryParse(split.DeclaredDate, out _));
            Assert.IsTrue(DateTime.TryParse(split.PaymentDate, out _));
            Assert.AreEqual(STATUS_OK, stockSplitsResponse.Status);
        }

        [TestMethod]
        public async Task GetStockSplitBadTickerAsync()
        {
            var stockSplitsResponse = await PolygonTestClient.GetStockSplitsAsync("1AP2L3");

            Assert.IsInstanceOfType(stockSplitsResponse, typeof(StockSplitsResponse));

            Assert.IsNotNull(stockSplitsResponse);
            Assert.AreEqual(0, stockSplitsResponse.Count);
            Assert.AreEqual(STATUS_OK, stockSplitsResponse.Status);
        }

        [TestMethod]
        public async Task GetMarketHolidaysSucceeds()
        {
            var marketHolidays = await PolygonTestClient.GetMarketHolidaysAsync();

            Assert.IsNotNull(marketHolidays);
            Assert.AreNotEqual(0, marketHolidays.Count);

            var firstHoliday = marketHolidays.FirstOrDefault();

            Assert.IsInstanceOfType(firstHoliday, typeof(MarketHoliday));
        }

        [DataTestMethod]
        [DataRow("stocks", "us")]
        public async Task GetTickerTypesSucceedsForStocksUs(string assetClass, string locale)
        {
            var tickerTypes = await PolygonTestClient.GetTickerTypesAsync(assetClass, locale);

            Assert.IsNotNull(tickerTypes);
            Assert.IsTrue(tickerTypes.Count > 1);

            var actualCommonStock = tickerTypes.Results.SingleOrDefault(x => x.Code == "CS");
            var expectedCommonStock = new TickerType() { AssetClass = AssetClass.Stocks, Code = "CS", Description = "Common Stock", Locale = Locale.Us };
            Assert.AreEqual(expectedCommonStock, actualCommonStock);
        }

        [DataTestMethod]
        [DataRow("stocks", "global")]
        [DataRow("options", "us")]
        [DataRow("crypto", "us")]
        [DataRow("fx", "us")]
        public async Task GetTickerTypesSucceedsForEmptyTypes(string assetClass, string locale)
        {
            var tickerTypes = await PolygonTestClient.GetTickerTypesAsync(assetClass, locale);

            Assert.IsNotNull(tickerTypes);
            Assert.IsTrue(tickerTypes.Count == 0);
        }
    }
}
