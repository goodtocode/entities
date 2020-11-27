using GoodToCode.Locality.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodToCode.Locality.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<LocalityDbContext>(options =>
            {
                options.UseSqlServer(configuration["Stack:Shared:SqlConnection"],
                    x => x.UseNetTopologySuite());
            });

            services.AddScoped<ILocalityDbContext, LocalityDbContext>();

            return services;
        }
    }
}