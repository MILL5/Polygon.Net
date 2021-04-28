namespace Polygon.Net
{
    public class PolygonSettings
    {
        private const string POLYGON_API_BASE_URL = "https://api.polygon.io";

        private const string POLYGON_HTTPCLIENT_NAME = "PolygonHttpClient";

        public string ApiBaseUrl 
        {   
            get
            {
                return POLYGON_API_BASE_URL;
            } 
        }

        public string ApiKey { get; set; }

        public bool UsePremiumOptions { get; set; }

        public string HttpClientName
        {
            get
            {
                return POLYGON_HTTPCLIENT_NAME;
            }
        }
    }
}