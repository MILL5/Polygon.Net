using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public string Published_utc { get; set; }

    [JsonProperty("keywords")]
    public List<string> Keywords { get; set; } = new List<string>() { };

    [JsonProperty("tickers")]
    public List<string> Tickers { get; set; } = new List<string>() { };
}
