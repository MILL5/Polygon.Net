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

    /// <summary>
    /// Get the news from Polygon.
    /// </summary>
    /// <param name="startTime">Return results published after this date</param>
    /// <param name="endTime">Return results published before this date</param>
    /// <param name="ticker">The polygon API ticker by default is desc</param>
    /// <param name="order">Order results based on the sort field</param>
    /// <param name="limit">Limit the number of results returned, default is 10 and max is 1000</param>
    /// <param name="sort">Sort field used for ordering</param>
    /// <returns>NewsResponse</returns>
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
            { "published_utc.gte", startTime?.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") },
            { "published_utc.lte", endTime?.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") },
            { nameof(order), order },
            { nameof(limit), limit?.ToString() },
            { nameof(sort), sort },
        };

        string queryParamStr = GetQueryParameterString(queryParams);
        string requestUrl = $"{_polygonSettings.ApiBaseUrl}{NEWS_ENDPOINT}{queryParamStr}";
        string contentStr = await Get(requestUrl).ConfigureAwait(false);
        NewsResponse newsResponse = JsonConvert.DeserializeObject<NewsResponse>(contentStr);

        return newsResponse.Results.Count == 0 ? new NewsResponse() : newsResponse;
    }

    /// <summary>
    /// Get the today's news from Polygon.
    /// </summary>
    /// <param name="ticker">The polygon API ticker by default is desc</param>
    /// <param name="order">Order results based on the sort field</param>
    /// <param name="limit">Limit the number of results returned, default is 10 and max is 1000</param>
    /// <param name="sort">Sort field used for ordering</param>
    /// <returns>NewsResponse</returns>
    public async Task<NewsResponse> GetTodayNewsAsync(
        string ticker = null,
        string order = null,
        int? limit = null,
        string sort = null
    )
    {
        return await GetNewsAsync(DateTime.Now.Date, null, ticker, order, limit, sort);
    }
}
