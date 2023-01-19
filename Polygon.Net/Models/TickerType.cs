using System;
using Newtonsoft.Json;
using HashCode = Pineapple.Common.HashCode;

namespace Polygon.Net;

public sealed class TickerType : IEquatable<TickerType>
{
    [JsonProperty("asset_class")]
    public string AssetClass { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("locale")]
    public string Locale { get; set; }

    public override bool Equals(object obj)
    {
        return Equals(obj as TickerType);
    }

    public bool Equals(TickerType other)
    {
        if (other == null)
            return false;
        return
            (
                AssetClass == other.AssetClass ||
                (AssetClass != null &&
                AssetClass.Equals(other.AssetClass))
            ) &&
            (
                Code == other.Code ||
                (Code != null &&
                Code.Equals(other.Code))
            ) &&
            (
                Description == other.Description ||
                (Description != null &&
                Description.Equals(other.Description))
            ) &&
            (
                Locale == other.Locale ||
                (Locale != null &&
                Locale.Equals(other.Locale))
            );
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        ComputeHash(hash);
        return hash.ToHashCode();
    }

    private void ComputeHash(HashCode hash)
    {
        hash.Add(AssetClass);
        hash.Add(Code);
        hash.Add(Description);
        hash.Add(Locale);
    }
}
