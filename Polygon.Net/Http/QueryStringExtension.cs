using Microsoft.AspNetCore.Http.Extensions;

namespace Polygon.Net.Http;

internal static class QueryStringExtension
{
    public static void AddIf(this QueryBuilder query, bool conditional, string? name, string? value)
    {
        if (conditional)
        {
            query.Add(name, value);
        }
    }
}
