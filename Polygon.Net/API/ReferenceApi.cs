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

        public async Task<TickerDetailsInfo> GetTickerDetailsAsync(string ticker, string date)
        {
            CheckIsNotNullOrWhitespace(nameof(ticker), ticker);

            var requestUrl = $"{ _polygonSettings.ApiBaseUrl }{ TICKERS_ENDPOINT }/{ ticker }";

            if(date != null)
            {
                requestUrl += $"?date={ date }";
            }

            var contentStr = await Get(requestUrl);

            var responseObj = JsonConvert.DeserializeObject<ResponseObject<TickerDetailsInfo>>(contentStr);

            return responseObj.Results;
        }

        // TODO: Handle pagination
        public async Task<List<TickerInfo>> GetTickersAsync(
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
            int? limit = null)
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

            var queryParamStr = GetQueryParameterString(queryParams);

            var requestUrl = $"{ _polygonSettings.ApiBaseUrl }{ TICKERS_ENDPOINT }{ queryParamStr }";
            
            var contentStr = await Get(requestUrl);

            var responseObj = JsonConvert.DeserializeObject<ResponseObject<List<TickerInfo>>>(contentStr);

            return responseObj.Results;
        }

        public async Task<List<ExchangeInfo>> GetExchangesAsync()
        {
            var requestUrl = $"{ _polygonSettings.ApiBaseUrl }{ EXCHANGES_ENDPOINT }";

            var contentStr = await Get(requestUrl);

            return JsonConvert.DeserializeObject<List<ExchangeInfo>>(contentStr);
        }
    }
}