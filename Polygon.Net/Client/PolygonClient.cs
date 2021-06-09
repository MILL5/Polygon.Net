using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using static Pineapple.Common.Preconditions;

namespace Polygon.Net
{
    public partial class PolygonClient : IPolygonClient
    {
        private readonly IPolygonDependencies _dependencies;
        public readonly PolygonSettings _polygonSettings;
        public readonly IMapper _mapper;

        public PolygonClient(IPolygonDependencies dependencies)
        {
            CheckIsNotNull(nameof(dependencies), dependencies);
            _dependencies = dependencies;
            _polygonSettings = dependencies.Settings;
            _mapper = dependencies.Mapper;
        }

        private async Task<string> Get(string requestUrl)
        {
            var client = _dependencies.HttpClientFactory.CreateClient(_polygonSettings.HttpClientName);

            requestUrl = $"{ requestUrl }{ (requestUrl.Contains("?") ? "&" : "?") }apikey={ _polygonSettings.ApiKey }";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            var response = await client.SendAsync(request);

            if(!response.IsSuccessStatusCode)
            {
                throw new PolygonHttpException(response.ReasonPhrase);
            }
            
            return await response.Content.ReadAsStringAsync();
        }

        private string GetQueryParameterString(Dictionary<string, string> queryParams)
        {
            var sb = new StringBuilder();

            foreach(var qp in queryParams)
            {
                if(qp.Value != null)
                {
                    sb.Append($"&{ qp.Key }={ qp.Value }");
                }
            }

            if(sb.Length == 0)
            {
                return string.Empty;
            }

            sb.Remove(0, 1);
            sb.Insert(0, "?");

            return sb.ToString();
        }

        private string FormatDateString(string inputDateString)
        {
            if (inputDateString == null)
                return null;

            var dateIsParsed = DateTime.TryParse(inputDateString, out DateTime outTime);

            if (!dateIsParsed)
            {
                try
                {
                    outTime = DateTimeOffset.FromUnixTimeMilliseconds(Int64.Parse(inputDateString)).UtcDateTime;
                }
                catch
                {
                    throw new Exception("Invalid date input.");
                }
            }

            return outTime.ToString("yyyy-MM-dd");
        }
    }
}