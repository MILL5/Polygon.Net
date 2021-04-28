using System.Net.Http;
using System.Threading.Tasks;
using static Pineapple.Common.Preconditions;

namespace Polygon.Net
{
    public partial class PolygonClient : IPolygonClient
    {
        private readonly IPolygonDependencies _dependencies;
        public readonly PolygonSettings _polygonSettings;

        public PolygonClient(IPolygonDependencies dependencies)
        {
            CheckIsNotNull(nameof(dependencies), dependencies);
            _dependencies = dependencies;
            _polygonSettings = dependencies.Settings;
        }

        private async Task<string> Get(string requestUrl)
        {
            using var client = _dependencies.HttpClientFactory.CreateClient(_polygonSettings.HttpClientName);

            requestUrl = $"{ requestUrl }{ (requestUrl.Contains("?") ? "&" : "?") }apikey={ _polygonSettings.ApiKey }";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            var response = await client.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}