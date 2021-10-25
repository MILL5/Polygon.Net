using AutoMapper;
using System.Net.Http;
using static Pineapple.Common.Preconditions;

namespace Polygon.Net
{
    public interface IPolygonDependencies
    {
        PolygonSettings Settings { get; set; }
        IHttpClientFactory HttpClientFactory { get; set; }
        IMapper Mapper { get; set; }
    }

    internal class PolygonDependencies : IPolygonDependencies
    {
        public PolygonSettings Settings { get; set; }
        public IHttpClientFactory HttpClientFactory { get; set; }
        public IMapper Mapper { get; set; }


        public PolygonDependencies(PolygonSettings settings, IHttpClientFactory clientFactory, IMapper mapper)
        {
            CheckIsNotNull(nameof(settings), settings);
            CheckIsNotNull(nameof(clientFactory), clientFactory);

            Settings = settings;
            HttpClientFactory = clientFactory;
            Mapper = mapper;
        }
    }
}