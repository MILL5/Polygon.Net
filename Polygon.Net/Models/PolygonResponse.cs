using System.Collections.Generic;
using Newtonsoft.Json;

namespace Polygon.Net.Models;

public class PolygonResponse<TReturnType> where TReturnType : class
{
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("results")]
    public List<TReturnType> Results { get; set; }
}
