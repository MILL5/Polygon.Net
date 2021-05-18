using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Pineapple.Common.Preconditions;

namespace Polygon.Net
{
    public partial class PolygonClient
    {
        private const string AGGREGATES_BARS_ENDPOINT =
           "/v2/aggs/ticker/{0}/range/{1}/{2}/{3}/{4}";

        private const string DAILY_OPEN_CLOSE_ENDPOINT =
           "/v1/open-close/{0}/{1}";

        public async Task<AggregatesBarsResponse> GetAggregatesAsync(
           string stocksTicker, 
           int multiplier, 
           string timespan,
           string from, 
           string to,
           bool? unadjusted = null,
           string sort = null,
           int? limit = null)
       {
           CheckIsNotNullOrWhitespace(nameof(stocksTicker), stocksTicker);
           CheckIsNotNullOrWhitespace(nameof(timespan), timespan);
           CheckIsNotNullOrWhitespace(nameof(from), from);
           CheckIsNotNullOrWhitespace(nameof(to), to);
           CheckIsNotLessThan(nameof(multiplier), multiplier, 1);

           var formattedFrom = FormatDateString(from);
           var formattedTo = FormatDateString(to);
           CheckIsValidDateRange(nameof(from), DateTime.Parse(formattedFrom), DateTime.Parse(formattedFrom), DateTime.Parse(formattedTo));

           var queryParams = new Dictionary<string, string>
           {
               {nameof(unadjusted), unadjusted?.ToString()},
               {nameof(sort), sort},
               {nameof(limit), limit?.ToString()}
           };
           
           var requestUrl = 
               $"{ _polygonSettings.ApiBaseUrl }" +
               $"{ string.Format(AGGREGATES_BARS_ENDPOINT, stocksTicker, multiplier.ToString(), timespan.ToLower(), formattedFrom, formattedTo) }" +
               $"{ GetQueryParameterString(queryParams) }";

           var contentStr = await Get(requestUrl);

           return JsonConvert.DeserializeObject<AggregatesBarsResponse>(contentStr);
        }

        public async Task<DailyOpenCloseResponse> GetDailyOpenCloseAsync(
           string stocksTicker,
           string date,
           bool? unadjusted = null)
        {
            CheckIsNotNullOrWhitespace(nameof(stocksTicker), stocksTicker);
            CheckIsNotNullOrWhitespace(nameof(date), date);

            var formattedDate = FormatDateString(date);

            var queryParams = new Dictionary<string, string>
            {
                {nameof(unadjusted), unadjusted?.ToString()},
            };

            var requestUrl =
                $"{ _polygonSettings.ApiBaseUrl }" +
                $"{ string.Format(DAILY_OPEN_CLOSE_ENDPOINT, stocksTicker, formattedDate) }" +
                $"{ GetQueryParameterString(queryParams) }";

            var contentStr = await Get(requestUrl);

            return JsonConvert.DeserializeObject<DailyOpenCloseResponse>(contentStr);
       }
    }
}