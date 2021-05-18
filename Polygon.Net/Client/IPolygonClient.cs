using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polygon.Net
{
    public interface IPolygonClient
    {
        public Task<TickersResponse> GetTickersAsync(
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
            int? limit = null,
            string nextUrl = null);

        public Task<TickerDetailsInfoV1> GetTickerDetailsV1Async(string stocksTicker);

        public Task<TickerDetailsResponse> GetTickerDetailsAsync(string ticker, string date = null);

        public Task<List<ExchangeInfo>> GetStockExchangesAsync();

        public Task<StockFinancialsResponse> GetStockFinancialsAsync(
            string stocksTicker,
            string type = null,
            string sort = null,
            int? limit = null,
            string nextUrl = null);

        public Task<AggregatesBarsResponse> GetAggregatesAsync(
            string stocksTicker,
            int multiplier,
            string timespan,
            string from,
            string to,
            bool? unadjusted = null,
            string sort = null,
            int? limit = null);


        public Task<DailyOpenCloseResponse> GetDailyOpenCloseAsync(string stocksTicker, string date, bool? unadjusted = null);
    }
}