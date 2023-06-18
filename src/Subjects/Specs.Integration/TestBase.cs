using AutoMapper;
using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Application.Common.Mappings;
using Goodtocode.Subjects.Integration.Common;
using Goodtocode.Subjects.Persistence;
using Goodtocode.Subjects.Persistence.Contexts;
using Goodtocode.Subjects.Persistence.Repositories;

namespace Goodtocode.Application.Integration;

[SetUpFixture]
public class TestBase
{
    protected string _def = string.Empty;
    private static IConfigurationRoot _configuration = null!;
    private static IServiceScopeFactory _scopeFactory = null!;

    public IMapper Mapper { get; }
    public IBusinessRepo BusinessRepo { get; private set; }

    public TestBase()
    {
        Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); })
            .CreateMapper();
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
            w.ApplicationName == "Courses.WebApi"));

        services.AddScoped<IContextSeeder, ContextSeeder>();

        services.AddLogging();

        _scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();
        var sp = services.BuildServiceProvider();
        BusinessRepo = sp.GetRequiredService<IBusinessRepo>() ?? new Mock<IBusinessRepo>().Object;

        SeedContext();
    }

    private static void SeedContext()
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SubjectsDbContext>();
        var seeder = scope.ServiceProvider.GetRequiredService<IContextSeeder>();
        seeder.SeedSampleDataAsync(context);
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

    //public static async Task<TEntity?> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
    //    where TEntity : class
    //{
    //    using var scope = _scopeFactory.CreateScope();

    //    var context = scope.ServiceProvider.GetRequiredService<CoursesContext>();        

    //    return await context.Set<TEntity>().FirstOrDefaultAsync(expression);
    //}
    //public static IEnumerable<TEntity?> Where<TEntity>(Expression<Func<TEntity, bool>> expression, int take = 100)
    //where TEntity : class
    //{
    //    using var scope = _scopeFactory.CreateScope();

    //    var context = scope.ServiceProvider.GetRequiredService<CoursesContext>();

    //    return context.Set<TEntity>().Where(expression).Take(take).ToList();
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