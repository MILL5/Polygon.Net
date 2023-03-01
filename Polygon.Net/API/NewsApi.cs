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

    public async Task<NewsResponse> GetNewsAsync()
    {
        var RequestUrl = $"{_polygonSettings.ApiBaseUrl}{NEWS_ENDPOINT}";
        var Request    = await Get(RequestUrl).ConfigureAwait(false);

        return JsonConvert.DeserializeObject<NewsResponse>(Request);
    }
}
