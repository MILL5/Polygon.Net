using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polygon.Net.Models;
using static Polygon.Net.Tests.TestManager;

#nullable enable
namespace Polygon.Net.Tests.FunctionalTests
{
    [TestClass]
    public class NewsApiTests
    {
        private const string STATUS_OK = "OK";
        private static DateTime START_TIME = new DateTime(2023, 03, 05);  // Start Specific Day
        private static DateTime END_TIME = new DateTime(2023, 03, 06);    // End Specific Day

        [TestMethod]
        public async Task GetNewsSucceedsAsync()
        {
            var newsResponse = await PolygonTestClient.GetNewsAsync();

            Assert.IsInstanceOfType(newsResponse.Results, typeof(List<NewsInfo>));
            Assert.IsNotNull(newsResponse);
            Assert.AreEqual(STATUS_OK, newsResponse.Status);
        }

        [TestMethod]
        public async Task GetNewsWithParametersSucceedsAsync()
        {
            int countNews = 5;
            String ticker = "GOOGL";
            DateTime dateTime = START_TIME;

            var newsResponse = await PolygonTestClient.GetNewsAsync(START_TIME, END_TIME, ticker, "asc", "published_utc", limit: countNews);

            Assert.IsInstanceOfType(newsResponse.Results, typeof(List<NewsInfo>));
            Assert.IsNotNull(newsResponse);
            Assert.AreEqual(STATUS_OK, newsResponse.Status);
            Assert.AreEqual(newsResponse.Count, countNews);

            foreach (var news in newsResponse.Results)
            {
                DateTime publishedNews = DateTime.Parse(news.PublishedUtc);

                Assert.AreEqual(START_TIME.ToString("yyyy-MM-dd"), publishedNews.ToString("yyyy-MM-dd"));
                Assert.IsTrue(news.Tickers.Contains(ticker), "The ticker was not found inside tickers");
                Assert.IsTrue(publishedNews > dateTime, "Date current news is not greater than before date news");

                dateTime = publishedNews;
            }

        }

        [TestMethod]
        public async Task GetNewsEmptyAsync()
        {
            var newsResponse = await PolygonTestClient.GetNewsAsync(ticker: "ABCXYZ");

            Assert.IsTrue(newsResponse.Count == 0, "the news count should be empty");
            Assert.AreEqual(STATUS_OK, newsResponse.Status);
        }

        [TestMethod]
        public async Task GetTodayNewsSucceedsAsync()
        {
            DateTime currentDate = DateTime.Now.Date;
            var newsResponse = await PolygonTestClient.GetNewsAsync(currentDate);

            Assert.IsInstanceOfType(newsResponse.Results, typeof(List<NewsInfo>));
            Assert.IsNotNull(newsResponse);
            Assert.AreEqual(STATUS_OK, newsResponse.Status);

            foreach (var news in newsResponse.Results)
            {
                Assert.AreEqual(currentDate.ToString("yyyy-MM-dd"), DateTime.Parse(news.PublishedUtc).ToString("yyyy-MM-dd"));
            }
        }

        [TestMethod]
        public async Task GetNextPageNewsAsync()
        {
            var newsResponse = await PolygonTestClient.GetNewsAsync(START_TIME, END_TIME);
            var nextPage = await PolygonTestClient.GetNewsAsync(nextPage: newsResponse.HashNextUrl);

            Assert.IsInstanceOfType(nextPage.Results, typeof(List<NewsInfo>));
            Assert.IsNotNull(nextPage);
            Assert.AreEqual(STATUS_OK, nextPage.Status);
        }
    }
}
