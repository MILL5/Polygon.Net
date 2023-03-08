using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Polygon.Net.Http;
using Polygon.Net.Models;

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
    /// <param name="nextPage">next page </param>
    /// <returns>NewsResponse</returns>
    /// 
    public async Task<NewsResponse> GetNewsAsync(DateTime? startTime = null, DateTime? endTime = null, string? ticker = null, string? order = null, string? sort = null, int limit = 0, string? nextPage = null)
    {
        var qb = new QueryBuilder();
        qb.AddIf(nextPage != null, "cursor", nextPage);
        qb.AddIf(ticker != null, nameof(ticker), ticker);
        qb.AddIf(order != null, nameof(order), order);
        qb.AddIf(limit != 0, nameof(limit), limit + "");
        qb.AddIf(sort != null, nameof(sort), sort);
        qb.AddIf(startTime != null, "published_utc.gte", startTime?.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
        qb.AddIf(endTime != null, "published_utc.lte", endTime?.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));

        string requestUrl = $"{_polygonSettings.ApiBaseUrl}{NEWS_ENDPOINT}{qb.ToString()}";
        string contentStr = await Get(requestUrl).ConfigureAwait(false);

        return String.IsNullOrEmpty(contentStr) ? new NewsResponse() : JsonConvert.DeserializeObject<NewsResponse>(contentStr);
    }
}
