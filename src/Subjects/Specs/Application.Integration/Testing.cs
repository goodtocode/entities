using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Persistence;
using Goodtocode.Subjects.Persistence.Contexts;
using Microsoft.AspNetCore.Http;

namespace Goodtocode.Application.Integration;

[SetUpFixture]
public class Testing
{
    private static IConfigurationRoot _configuration = null!;
    private static IServiceScopeFactory _scopeFactory = null!;
    protected IBusinessRepo? _businessRepo;

    public Testing()
    {
        RunBeforeAnyTests();
    }

    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.test.json", true, true)
            .AddEnvironmentVariables();

        _configuration = builder.Build();

        var services = new ServiceCollection();
        services.AddApplicationServices();
        services.AddInfrastructureServices(_configuration);

        services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
            w.EnvironmentName == "Development" &&
            w.ApplicationName == "WebApi"));

        services.AddLogging();

        _scopeFactory = services
            .BuildServiceProvider()
            .GetRequiredService<IServiceScopeFactory>();
        var sp = services.BuildServiceProvider();
        _businessRepo = sp.GetService<IBusinessRepo>();
    }

    private static void SeedContext()
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SubjectsDbContext>();
        //var seeder = scope.ServiceProvider.GetRequiredService<IContextSeeder>();
        //seeder.SeeSampleDataAsync(context);
    }

    //public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    //{
    //    using var scope = _scopeFactory.CreateScope();

    //    var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

    //    return await mediator.Send(request);
    //}
    
    //public static async Task<TEntity?> FindAsync<TEntity>(params object[] keyValues)
    //    where TEntity : class
    //{
    //    using var scope = _scopeFactory.CreateScope();

    //    var context = scope.ServiceProvider.GetRequiredService<CoursesContext>();

    //    return await context.FindAsync<TEntity>(keyValues);
    //}

    //public static async Task AddAsync<TEntity>(TEntity entity)
    //    where TEntity : class
    //{
    //    using var scope = _scopeFactory.CreateScope();

    //    var context = scope.ServiceProvider.GetRequiredService<CoursesContext>();

    //    context.Add(entity);

    //    await context.SaveChangesAsync();
    //}

    //public static async Task<int> CountAsync<TEntity>() where TEntity : class
    //{
    //    using var scope = _scopeFactory.CreateScope();

    //    var context = scope.ServiceProvider.GetRequiredService<CoursesContext>();

    //    return await context.Set<TEntity>().CountAsync();
    //}

    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
    }
}