using System.Web;
using Newtonsoft.Json;

namespace Polygon.Net.Models;

public class NewsResponse
{
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("request_id")]
    public string RequestId { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; } = 0;

    private string? _hashNextUrl;

    [JsonProperty("next_url")]
    public string? HashNextUrl
    {
        get { return _hashNextUrl; }
        set
        {
            string? hash = null;
            if (value != null)
            {
                Uri uri = new Uri(value);
                var query = HttpUtility.ParseQueryString(uri.Query);
                hash = query.Get("cursor");
            }

            _hashNextUrl = hash != null ? hash : value;
        }
    }

    [JsonProperty("results")]
    public List<NewsInfo> Results { get; set; } = new List<NewsInfo>() { };
}
