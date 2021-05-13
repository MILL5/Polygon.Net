using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Pineapple.Common.Preconditions;

namespace Polygon.Net
{
    public partial class PolygonClient
    {
        // TODO Catch format date exception
       //v2/aggs/ticker/{stocksTicker}/range/{multiplier}/{timespan}/{from}/{to}
       private readonly string STOCKS_AGGREGATES_BARS_ENDPOINT =
           "/v2/aggs/ticker/{0}/range/{1}/{2}/{3}/{4}";

       public async Task<AggregatesBars> GetAggregatesAsync(
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
               $"{ string.Format(STOCKS_AGGREGATES_BARS_ENDPOINT, stocksTicker.ToUpper(), multiplier.ToString(), timespan.ToLower(), formattedFrom, formattedTo) }" +
               $"{ GetQueryParameterString(queryParams) }";

           var contentStr = await Get(requestUrl);

           return JsonConvert.DeserializeObject<AggregatesBars>(contentStr);
       }
    }
}