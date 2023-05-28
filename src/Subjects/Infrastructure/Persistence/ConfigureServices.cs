using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Persistence.Contexts;
using Goodtocode.Subjects.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Goodtocode.Subjects.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            services.AddDbContext<SubjectsDbContext>(options =>
                options.UseInMemoryDatabase("SubjectsConnection"));
        else
            services.AddDbContext<SubjectsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SubjectsConnection"),
                    builder => builder.MigrationsAssembly(typeof(SubjectsDbContext).Assembly.FullName)));

        services.AddScoped<ISubjectsDbContext, SubjectsDbContext>();
        services.AddScoped<IBusinessRepo, BusinessRepo>();

        return services;
    }
}