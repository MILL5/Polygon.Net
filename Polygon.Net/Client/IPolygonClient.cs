using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polygon.Net
{
    public interface IPolygonClient
    {
        public Task<TickerDetailsInfo> GetTickerDetailsAsync(string ticker, string date);

        public Task<List<TickerInfo>> GetTickersAsync(
            string ticker = null,
            string tickerlt = null,
            string tickerlte = null,
            string tickergt = null,
            string tickergte = null,
            string type = null,
            string market = null,
            string exchange = null,
            string cusip = null,
            string date = null,
            bool? active = null,
            string sort = null,
            string order = null,
            int? limit = null);

        public Task<List<ExchangeInfo>> GetExchangesAsync();
    }
}