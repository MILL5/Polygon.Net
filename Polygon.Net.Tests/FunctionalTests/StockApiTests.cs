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
        // Valid Strings
        private const string MSFT_TICKER = "MSFT";
        private const string MSFT_LOWER_TICKER = "msft";
        private const int MULTIPLIER = 2;
        private const string TIMESPAN_DAY = "day";
        private const string FROM_STRING = "2020-10-14";
        private const string TO_STRING = "2020-10-20";
        private const string FROM_STRING_MM_DD_YYYY = "10-14-2020";
        private const string TO_STRING_MM_DD_YYYY = "10-20-2020";
        private const string FROM_UNIX = "1602648000000";
        private const string TO_UNIX = "1603166400000";
        
        // Invalid Strings
        private const string FOOBAR = "foobar";

        // Tests for requests without query params
        [DataTestMethod]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_STRING, TO_STRING)]
        [DataRow(MSFT_LOWER_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_STRING, TO_STRING)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_STRING_MM_DD_YYYY, TO_STRING)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_STRING, TO_STRING_MM_DD_YYYY)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_STRING_MM_DD_YYYY, TO_STRING_MM_DD_YYYY)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_UNIX, TO_STRING)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_STRING, TO_UNIX)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_UNIX, TO_UNIX)]
        public async Task GetAggregatesSucceedsAsync(string ticker, int multiplier, string timespan, string from, string to)
        {
            var response = await PolygonTestClient.GetAggregatesAsync(ticker, multiplier, timespan, from, to);

            Assert.IsNotNull(response);
            Assert.AreEqual("OK", response.Status);
            Assert.IsTrue(response.Results.Count >= 1);
            Assert.AreEqual(response.Ticker, ticker.ToUpper());
        }
        
        [DataTestMethod]
        [DataRow(true, null, null)]
        [DataRow(null, "asc", null)]
        [DataRow(null, null, 1)]
        [DataRow(false, "desc", 10)]
        public async Task GetAggregatesWithQueryParamsSucceedsAsync(bool? unadjusted, string sort, int? limit)
        {
            var response = await PolygonTestClient.GetAggregatesAsync(
                MSFT_TICKER, 
                MULTIPLIER, 
                TIMESPAN_DAY, 
                FROM_STRING, 
                TO_STRING,
                unadjusted,
                sort,
                limit
            );

            Assert.IsNotNull(response);
            Assert.AreEqual("OK", response.Status);
            Assert.IsTrue(response.Results.Count >= 1);
            Assert.AreEqual(response.Ticker, MSFT_TICKER);
        }
        
        [DataTestMethod]
        [DataRow(null, MULTIPLIER, TIMESPAN_DAY, FROM_STRING, TO_STRING)]
        [DataRow(MSFT_TICKER, MULTIPLIER, null, FROM_STRING_MM_DD_YYYY, TO_STRING)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, null, TO_STRING_MM_DD_YYYY)]
        [DataRow(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, FROM_STRING_MM_DD_YYYY, null)]
        public async Task GetAggregatesFailsWithNullParamsAsync(string ticker, int multiplier, string timespan, string from, string to)
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () => await PolygonTestClient.GetAggregatesAsync(ticker, multiplier, timespan, from, to));
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public async Task GetAggrgatesFailsWithNonPositiveMultiplierAsync(int multiplier)
        {
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(
                async () => await PolygonTestClient.GetAggregatesAsync(MSFT_TICKER, multiplier, TIMESPAN_DAY, FROM_STRING, TO_STRING));
        }

        [DataTestMethod]
        [DataRow(TO_STRING, FROM_STRING)]
        [DataRow(TO_UNIX, FROM_UNIX)]

        public async Task GetAggregatesFailsIfToPreceedsFromAsync(string from, string to)
        {
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(
                async () => await PolygonTestClient.GetAggregatesAsync(MSFT_TICKER, MULTIPLIER, TIMESPAN_DAY, from, to));
        }
    }
}