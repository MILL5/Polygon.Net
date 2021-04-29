using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Pineapple.Common.Preconditions;

namespace Polygon.Net
{
    public partial class PolygonClient : IPolygonClient
    {
        private const string TICKERS_ENDPOINT = "/vX/reference/tickers";

        private const string EXCHANGES_ENDPOINT = "/v1/meta/exchanges";

        public async Task<PolygonResponse<List<TickerInfo>>> GetTickersAsync(
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
            string nextUrl = null)
        {
            var queryParams = new Dictionary<string, string>
            {
                { nameof(ticker), ticker },
                { "ticker.lt", tickerlt },
                { "ticker.lte", tickerlte },
                { "ticker.gt", tickergt },
                { "ticker.gte", tickergte },
                { nameof(type), type },
                { nameof(market), market },
                { nameof(exchange), exchange },
                { nameof(cusip), cusip },
                { nameof(date), date },
                { nameof(active), active?.ToString() },
                { nameof(sort), sort },
                { nameof(order), order },
                { nameof(limit), limit?.ToString() },
            };

            string requestUrl;
            if(nextUrl != null)
            {
                requestUrl = nextUrl;
            }
            else
            {
                var queryParamStr = GetQueryParameterString(queryParams);
                requestUrl = $"{ _polygonSettings.ApiBaseUrl }{ TICKERS_ENDPOINT }{ queryParamStr }";
            }
            
            var contentStr = await Get(requestUrl);

            return JsonConvert.DeserializeObject<PolygonResponse<List<TickerInfo>>>(contentStr);
        }

        public async Task<PolygonResponse<TickerDetailsInfo>> GetTickerDetailsAsync(string ticker, string date)
        {
            CheckIsNotNullOrWhitespace(nameof(ticker), ticker);

            var requestUrl = $"{ _polygonSettings.ApiBaseUrl }{ TICKERS_ENDPOINT }/{ ticker }";

            if (date != null)
            {
                requestUrl += $"?date={ date }";
            }

            var contentStr = await Get(requestUrl);

            return JsonConvert.DeserializeObject<PolygonResponse<TickerDetailsInfo>>(contentStr);
        }

        public async Task<List<ExchangeInfo>> GetStockExchangesAsync()
        {
            var requestUrl = $"{ _polygonSettings.ApiBaseUrl }{ EXCHANGES_ENDPOINT }";

            var contentStr = await Get(requestUrl);

            return JsonConvert.DeserializeObject<List<ExchangeInfo>>(contentStr);
        }
    }
}