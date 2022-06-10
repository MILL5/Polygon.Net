using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Polygon.Net.Tests.TestManager;

namespace Polygon.Net.Tests.FunctionalTests
{
    [TestClass]
    public class StockApiTests
    {
        private const string STATUS_OK = "OK";

        // Valid Strings
        private const string MSFT_TICKER = "MSFT";
        private const string MSFT_LOWER_TICKER = "msft";
        private const int MULTIPLIER = 2;
        private const string TIMESPAN_DAY = "day";
        private const string FROM_DATE_STRING = "2020-10-14";
        private const string TO_DATE_STRING = "2020-10-20";
        private const string FROM_STRING_MM_DD_YYYY = "10-14-2020";
        private const string TO_STRING_MM_DD_YYYY = "10-20-2020";
        private const string FROM_UNIX = "1602648000000";
        private const string TO_UNIX = "1603166400000";

        // Tests for requests without query params
        [DataTestMethod]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_DATE_STRING, TO_DATE_STRING)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_STRING_MM_DD_YYYY, TO_DATE_STRING)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_DATE_STRING, TO_STRING_MM_DD_YYYY)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_STRING_MM_DD_YYYY, TO_STRING_MM_DD_YYYY)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_UNIX, TO_DATE_STRING)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_DATE_STRING, TO_UNIX)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_UNIX, TO_UNIX)]
        public async Task GetAggregatesSucceedsAsync(string ticker, int multiplier, string timespan, string from, string to)
        {
            var response = await PolygonTestClient.GetAggregatesBarsAsync(ticker, multiplier, timespan, from, to);

            Assert.IsNotNull(response);
            AssertAllPropertiesNotNull(response);

            Assert.AreEqual(STATUS_OK, response.Status);
            Assert.IsTrue(response.Results.Count >= 1);
            Assert.AreEqual(response.Ticker, ticker);

            AssertAllPropertiesNotNull(response.Results.FirstOrDefault());
        }

        [TestMethod]
        public async Task GetAggregatesLowerCaseTickerAsync()
        {
            var response = await PolygonTestClient.GetAggregatesBarsAsync(MSFT_LOWER_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_DATE_STRING, TO_DATE_STRING);

            Assert.IsNotNull(response);
            Assert.AreEqual(STATUS_OK, response.Status);
            Assert.IsTrue(response.ResultsCount == 0);
            Assert.AreEqual(MSFT_LOWER_TICKER, response.Ticker);
        }

        [DataTestMethod]
        [DataRow(true, null, null)]
        [DataRow(null, "asc", null)]
        [DataRow(null, null, 1)]
        [DataRow(false, "desc", 10)]
        public async Task GetAggregatesWithQueryParamsSucceedsAsync(bool? adjusted, string sort, int? limit)
        {
            var response = await PolygonTestClient.GetAggregatesBarsAsync(
                MSFT_TICKER,
                MULTIPLIER,
                TIMESPAN_DAY,
                FROM_DATE_STRING,
                TO_DATE_STRING,
                adjusted,
                sort,
                limit
            );

            Assert.IsNotNull(response);
            Assert.AreEqual(STATUS_OK, response.Status);
            Assert.IsTrue(response.Results.Count >= 1);
            Assert.AreEqual(response.Ticker, MSFT_TICKER);
        }

        [DataTestMethod]
        [DataRow(null, MULTIPLIER, TIMESPAN_DAY, FROM_DATE_STRING, TO_DATE_STRING)]
        [DataRow(MSFT_TICKER, MULTIPLIER, null, FROM_STRING_MM_DD_YYYY, TO_DATE_STRING)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, null, TO_STRING_MM_DD_YYYY)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_STRING_MM_DD_YYYY, null)]
        public async Task GetAggregatesFailsWithNullParamsAsync(string ticker, int multiplier, string timespan, string from, string to)
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () => await PolygonTestClient.GetAggregatesBarsAsync(ticker, multiplier, timespan, from, to));
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public async Task GetAggrgatesFailsWithNonPositiveMultiplierAsync(int multiplier)
        {
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(
                async () => await PolygonTestClient.GetAggregatesBarsAsync(MSFT_TICKER, multiplier, TIMESPAN_DAY, FROM_DATE_STRING, TO_DATE_STRING));
        }

        [DataTestMethod]
        [DataRow(TO_DATE_STRING, FROM_DATE_STRING)]
        [DataRow(TO_UNIX, FROM_UNIX)]

        public async Task GetAggregatesFailsIfToPreceedsFromAsync(string from, string to)
        {
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(
                async () => await PolygonTestClient.GetAggregatesBarsAsync(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, from, to));
        }

        [TestMethod]
        public async Task GetGroupedDailyBarsSucceedsAsync()
        {
            var response = await PolygonTestClient.GetGroupedDailyBarsAsync(FROM_DATE_STRING);

            Assert.IsNotNull(response);
            Assert.AreEqual(STATUS_OK, response.Status);
            Assert.IsTrue(response.ResultsCount > 0);

            Assert.IsTrue(response.Adjusted);

            var bars = response.Results;

            Assert.IsNotNull(bars.First().ExchangeSymbol);
            Assert.IsNotNull(bars.First().High);
        }

        [TestMethod]
        public async Task GetGroupedDailyBarsUnadjustedSucceedsAsync()
        {
            var response = await PolygonTestClient.GetGroupedDailyBarsAsync(FROM_DATE_STRING, false);

            Assert.IsNotNull(response);
            Assert.AreEqual(STATUS_OK, response.Status);
            Assert.IsTrue(response.ResultsCount > 0);

            Assert.IsFalse(response.Adjusted);

            var bars = response.Results;

            Assert.IsNotNull(bars.First().ExchangeSymbol);
            Assert.IsNotNull(bars.First().High);
        }

        [TestMethod]
        public async Task GetGroupedDailyBarsNoDateAsync()
        {
            await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () => await PolygonTestClient.GetGroupedDailyBarsAsync(string.Empty));
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow(true)]
        [DataRow(false)]
        public async Task GetDailyOpenCloseSucceedsAsync(bool? adjusted)
        {
            var response = await PolygonTestClient.GetDailyOpenCloseAsync(MSFT_TICKER, FROM_DATE_STRING, adjusted);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(DailyOpenCloseResponse));

            Assert.AreEqual(STATUS_OK, response.Status);

            AssertAllPropertiesNotNull(response);
        }

        [DataTestMethod]
        [DataRow(null, FROM_DATE_STRING, null)]
        [DataRow(MSFT_TICKER, null, null)]
        [DataRow(null, null, null)]
        [DataRow(null, FROM_DATE_STRING, true)]
        [DataRow(MSFT_TICKER, null, true)]
        [DataRow(null, null, true)]
        public async Task GetDailyOpenCloseNullRouteParamsAsync(string stocksTicker, string date, bool? adjusted)
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () => await PolygonTestClient.GetDailyOpenCloseAsync(stocksTicker, date, adjusted));
        }

        [TestMethod]
        public async Task GetDailyOpenCloseInvalidDateAsync()
        {
            await Assert.ThrowsExceptionAsync<Exception>(
                async () => await PolygonTestClient.GetDailyOpenCloseAsync(MSFT_TICKER, "foobar"));
        }
    }
}