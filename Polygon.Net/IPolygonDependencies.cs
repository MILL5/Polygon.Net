using System.Net.Http;
using static Pineapple.Common.Preconditions;

namespace Polygon.Net
{
    public interface IPolygonDependencies
    {
        PolygonSettings Settings { get; set; }
        IHttpClientFactory HttpClientFactory { get; set; }
    }

    internal class PolygonDependencies : IPolygonDependencies
    {
        public PolygonSettings Settings { get; set; }
        public IHttpClientFactory HttpClientFactory { get; set; }

        public PolygonDependencies(PolygonSettings settings, IHttpClientFactory clientFactory)
        {
            CheckIsNotNull(nameof(settings), settings);
            CheckIsNotNull(nameof(clientFactory), clientFactory);

            Settings = settings;
            HttpClientFactory = clientFactory;
        }
    }
}