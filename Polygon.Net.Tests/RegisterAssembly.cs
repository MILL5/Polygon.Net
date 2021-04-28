using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Pineapple.Common.Preconditions;

namespace Polygon.Net.Tests
{
    public static class RegisterAssembly
    {
        public static void AddApplication(this IServiceCollection services,
                                          IConfiguration config)
        {
            CheckIsNotNull(nameof(services), services);
            CheckIsNotNull(nameof(config), config);

            Net.RegisterAssembly.AddServices(services, config);
        }
    }
}