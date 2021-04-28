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
        }

        [TestMethod]
        public async Task GetTickersSucceedsAsync()
        {
            var tickers = await PolygonTestClient.GetTickersAsync(null);

            Assert.IsNotNull(tickers);
            Assert.IsTrue(tickers.Any());
        }
    }
}
