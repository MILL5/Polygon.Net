using Newtonsoft.Json;

namespace Polygon.Net.Models;

public class NewsInfo
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("published_utc")]
    public string PublishedUtc { get; set; }

    [JsonProperty("article_url")]
    public string ArticleUrl { get; set; }

    [JsonProperty("keywords")]
    public List<string> Keywords { get; set; } = new List<string>() { };

    [JsonProperty("tickers")]
    public List<string> Tickers { get; set; } = new List<string>() { };
}
