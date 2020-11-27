using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodToCode.Subjects.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<SubjectsDbContext>(options =>
            {
                options.UseSqlServer(configuration["Stack:Shared:SqlConnection"]);
            });

            services.AddScoped<ISubjectsDbContext, SubjectsDbContext>();

            return services;
        }
    }
}