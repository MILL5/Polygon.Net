using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polygon.Net
{
    public interface IPolygonClient
    {
        Task<TickersResponse> GetTickersAsync(
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

        Task<TickerDetailsInfoV1> GetTickerDetailsV1Async(string stocksTicker);

        Task<TickerDetailsResponse> GetTickerDetailsAsync(string ticker, string date = null);

        Task<List<ExchangeInfo>> GetStockExchangesAsync();

        Task<StockFinancialsResponse> GetStockFinancialsAsync(
            string stocksTicker,
            string type = null,
            string sort = null,
            int? limit = null,
            string nextUrl = null);

        Task<AggregatesBarsResponse> GetAggregatesAsync(
            string stocksTicker,
            int multiplier,
            string timespan,
            string from,
            string to,
            bool? unadjusted = null,
            string sort = null,
            int? limit = null);


        Task<DailyOpenCloseResponse> GetDailyOpenCloseAsync(string stocksTicker, string date, bool? unadjusted = null);
    }
}