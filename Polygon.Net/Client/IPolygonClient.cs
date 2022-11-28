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
            string nextUrl = null,
            bool expandAbbreviations = false);

        Task<TickerDetailsResponse> GetTickerDetailsAsync(string ticker, string date = null, bool expandAbbreviations = false);

        Task<List<ExchangeInfo>> GetStockExchangesAsync();

        Task<StockFinancialsResponse> GetStockFinancialsAsync(
            string stocksTicker,
            string type = null,
            string sort = null,
            int? limit = null,
            string nextUrl = null);

        Task<AggregatesBarsResponse> GetAggregatesBarsAsync(
            string stocksTicker,
            int multiplier,
            string timespan,
            string from,
            string to,
            bool? adjusted = null,
            string sort = null,
            int? limit = null);

        Task<GroupedDailyBarsResponse> GetGroupedDailyBarsAsync(string date, bool? adjusted = null);

        Task<DailyOpenCloseResponse> GetDailyOpenCloseAsync(string stocksTicker, string date, bool? adjusted = null);

        Task<StockDividendsResponse> GetStockDividendsAsync(string ticker);

        Task<StockSplitsResponse> GetStockSplitsAsync(string ticker);

        Task<List<MarketHoliday>> GetMarketHolidaysAsync();
    }
}
