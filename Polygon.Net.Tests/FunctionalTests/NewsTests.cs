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
    public class NewsApiTests
    {
        private const string STATUS_OK = "OK";

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
            DateTime startTime  = new DateTime(2023, 03, 05);  // Start Specific Day
            DateTime endTime    = new DateTime(2023, 03, 06);    // End Specific Day
            int countNews       = 5;
            String ticker       = "GOOGL";
            DateTime dateTime   = startTime;

            var newsResponse    = await PolygonTestClient.GetNewsAsync(startTime, endTime, ticker, "asc", countNews, "published_utc");

            Assert.IsInstanceOfType(newsResponse.Results, typeof(List<NewsInfo>));
            Assert.IsNotNull(newsResponse);
            Assert.AreEqual(STATUS_OK, newsResponse.Status);
            Assert.AreEqual(newsResponse.Count, countNews);

            foreach (var news in newsResponse.Results)
            {
                DateTime publishedNews = DateTime.Parse(news.Published_utc);

                Assert.AreEqual(startTime.ToString("yyyy-MM-dd"), publishedNews.ToString("yyyy-MM-dd"));
                Assert.IsTrue(news.Tickers.Contains(ticker), "The ticker was not found inside tickers");
                Assert.IsTrue(publishedNews > dateTime, "Date current news is not greater than before date news");

                dateTime = publishedNews;
            }

        }

        [TestMethod]
        public async Task GetNewsEmptyAsync()
        {
            var newsResponse = await PolygonTestClient.GetNewsAsync(null, null, "ABCXYZ");

            Assert.IsTrue(newsResponse.Count == 0, "the news count should be empty");
            Assert.IsNull(newsResponse.Status);
        }


        [TestMethod]
        public async Task GetTodayNewsSucceedsAsync()
        {
            string currentDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            var newsResponse   = await PolygonTestClient.GetTodayNewsAsync();

            Assert.IsInstanceOfType(newsResponse.Results, typeof(List<NewsInfo>));
            Assert.IsNotNull(newsResponse);
            Assert.AreEqual(STATUS_OK, newsResponse.Status);

            foreach (var news in newsResponse.Results)
            {
                Assert.AreEqual(currentDate, DateTime.Parse(news.Published_utc).ToString("yyyy-MM-dd"));
            }
        }
    }
}
