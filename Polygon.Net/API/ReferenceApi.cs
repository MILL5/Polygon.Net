using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static Pineapple.Common.Preconditions;

namespace Polygon.Net
{
    public partial class PolygonClient : IPolygonClient
    {
        const string TICKERS_ENDPOINT = "/vX/reference/tickers";

        public async Task<TickerInfo> GetTickerDetailsAsync(string ticker, string date)
        {
            CheckIsNotNullOrWhitespace(nameof(ticker), ticker);

            var requestUrl = $"{ _polygonSettings.ApiBaseUrl }{ TICKERS_ENDPOINT }/{ ticker }";

            if(date != null)
            {
                requestUrl += $"?date={ date }";
            }

            var contentStr = await Get(requestUrl);

            var responseObj = JsonConvert.DeserializeObject<ResponseObject<TickerInfo>>(contentStr);

            return responseObj.Results;
        }

        public async Task<List<TickerInfo>> GetTickersAsync(string ticker)
        {
            var requestUrl = $"{ _polygonSettings.ApiBaseUrl }{ TICKERS_ENDPOINT }";
            
            var contentStr = await Get(requestUrl);

            var responseObj = JsonConvert.DeserializeObject<ResponseObject<List<TickerInfo>>>(contentStr);

            return responseObj.Results;
        }
    }
}