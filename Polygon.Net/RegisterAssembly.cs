using System;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Pineapple.Common.Preconditions;

namespace Polygon.Net
{
    public static class RegisterAssembly
    {
        const string POLYGON_API_KEY_NAME = "PolygonApiKey";

        const string USE_PREM_OPTIONS_NAME = "UsePremiumOptions";

        public static void AddServices(IServiceCollection services, IConfiguration config)
        {
            CheckIsNotNull(nameof(services), services);
            CheckIsNotNull(nameof(config), config);

            CheckIsNotNull(POLYGON_API_KEY_NAME, config[POLYGON_API_KEY_NAME]);

            var settings = new PolygonSettings
            {
                ApiKey = config[POLYGON_API_KEY_NAME],
                UsePremiumOptions = config[USE_PREM_OPTIONS_NAME] != null && bool.Parse(config[USE_PREM_OPTIONS_NAME])
            };

            services.AddSingleton(settings);
            services.AddTransient<IPolygonDependencies, PolygonDependencies>();
            services.AddTransient<IPolygonClient, PolygonClient>();

            services.AddAutoMapper(typeof(RegisterAssembly));

            AddHttpClient(services, settings);
        }

        private static void AddHttpClient(IServiceCollection services, PolygonSettings settings)
        {
            services.AddTransient<BrotliCompressionHandler>();
            services.AddHttpClient(settings.HttpClientName, client =>
            {
                client.BaseAddress = new Uri(settings.ApiBaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                AllowAutoRedirect = false,
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip

            }).AddHttpMessageHandler<BrotliCompressionHandler>();
        }
    }
}