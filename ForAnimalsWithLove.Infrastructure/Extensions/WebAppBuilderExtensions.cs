using Microsoft.Extensions.DependencyInjection;

using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.Data.Service.Services;

namespace ForAnimalsWithLove.Infrastructure.Extensions
{
    public static class WebAppBuilderExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IHomeService, HomeService>();
        }
    }
}
