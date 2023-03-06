using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    [JsonProperty("next_url")]
    public string NextUrl { get; set; }

    [JsonProperty("results")]
    public List<NewsInfo> Results { get; set; }  = new List<NewsInfo>() { };
}
