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
            var NewsResponse = await PolygonTestClient.GetNewsAsync();

            Assert.IsInstanceOfType(NewsResponse.Results, typeof(List<NewsInfo>));
            Assert.IsNotNull(NewsResponse);
            Assert.AreEqual(STATUS_OK, NewsResponse.Status);
        }


        [TestMethod]
        public async Task GetTodayNewsSucceedsAsync()
        {
            string currentDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            var newsResponse   = await PolygonTestClient.GetTodayNews();

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
