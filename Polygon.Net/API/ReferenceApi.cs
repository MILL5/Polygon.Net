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

        // TODO: Handle pagination and other query parameters
        public async Task<List<TickerInfo>> GetTickersAsync(string ticker)
        {
            var requestUrl = $"{ _polygonSettings.ApiBaseUrl }{ TICKERS_ENDPOINT }";
            
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