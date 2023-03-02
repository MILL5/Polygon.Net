using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polygon.Net.Models;
using static Pineapple.Common.Preconditions;

namespace Polygon.Net;

public partial class PolygonClient
{
    private const string NEWS_ENDPOINT = "/v2/reference/news";

    public async Task<NewsResponse> GetNewsAsync(
        DateTime? startTime, 
        DateTime? endTime, 
        string ticker = null,
        string order = null,
        int? limit = null,
        string sort = null
    )
    {
        var queryParams = new Dictionary<string, string>
        {
            { nameof(ticker), ticker },
            { "published_utc.gte", startTime?.ToString() },
            { "published_utc.lte", endTime?.ToString() },
            { nameof(order), order },
            { nameof(limit), limit?.ToString() },
            { nameof(sort), sort },
        };

        var queryParamStr = GetQueryParameterString(queryParams);
        var requestUrl    = $"{_polygonSettings.ApiBaseUrl}{NEWS_ENDPOINT}{queryParamStr}";
        var contentStr    = await Get(requestUrl).ConfigureAwait(false);

        return JsonConvert.DeserializeObject<NewsResponse>(contentStr);
    }

    public async Task<NewsResponse> GetTodayNews(
        string ticker = null,
        string order = null,
        int? limit = null,
        string sort = null
    )
    {
        return await GetNewsAsync(DateTime.Now.Date, null, ticker, order, limit, sort);
    }
}
