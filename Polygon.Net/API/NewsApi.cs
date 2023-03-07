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
    /// Get the Polygon news.
    /// </summary>
    /// <param name="startTime">Return results published after this date</param>
    /// <param name="endTime">Return results published before this date</param>
    /// <param name="ticker">The polygon API ticker by default is desc</param>
    /// <param name="order">Order results based on the sort field</param>
    /// <param name="limit">Limit the number of results returned, default is 10 and max is 1000</param>
    /// <param name="sort">Sort field used for ordering</param>
    /// <returns>NewsResponse</returns>
    public async Task<NewsResponse> GetNewsAsync(
        DateTime? startTime = default,
        DateTime? endTime = default,
        string ticker   = null,
        string order    = null,
        int? limit      = null,
        string sort     = null,
        string nextPage = null
    )
    {
        var queryParams = new Dictionary<string, string>();

        if(nextPage != null) {
            queryParams.Add("cursor", nextPage);
        }else {
            if(ticker != null) queryParams.Add(nameof(ticker), ticker);
            if (order != null) queryParams.Add(nameof(order), order);
            if (limit != null) queryParams.Add(nameof(limit), limit + "");
            if (sort != null) queryParams.Add(nameof(sort), sort);

            queryParams.Add("published_utc.gte", startTime?.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            queryParams.Add("published_utc.lte", endTime?.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
        }

        string queryParamStr = GetQueryParameterString(queryParams);
        string requestUrl = $"{_polygonSettings.ApiBaseUrl}{NEWS_ENDPOINT}{queryParamStr}";
        string contentStr = await Get(requestUrl).ConfigureAwait(false);
        NewsResponse newsResponse = JsonConvert.DeserializeObject<NewsResponse>(contentStr);

        return newsResponse.Results.Count == 0 ? new NewsResponse() : newsResponse;
    }

    /// <summary>
    /// Get the today's Polygon news.
    /// </summary>
    /// <param name="ticker">The polygon API ticker by default is desc</param>
    /// <param name="order">Order results based on the sort field</param>
    /// <param name="limit">Limit the number of results returned, default is 10 and max is 1000</param>
    /// <param name="sort">Sort field used for ordering</param>
    /// <returns>NewsResponse</returns>
    public async Task<NewsResponse> GetTodayNewsAsync(
        string ticker   = null,
        string order    = null,
        int? limit      = null,
        string sort     = null,
        string nextPage = null
    )
    {
        return await GetNewsAsync(DateTime.Now.Date, null, ticker, order, limit, sort, nextPage);
    }

    /// <summary>
    /// Get the next page of Polygon news.
    /// </summary>
    /// <param name="nextPage">hash of the next page</param>
    public async Task<NewsResponse> GetNextPageNewsAsync(string nextPage = null){
        return await GetNewsAsync(null, null, null, null, null, null, nextPage);
    }
}
