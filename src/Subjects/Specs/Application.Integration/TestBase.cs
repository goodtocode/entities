using AutoMapper;
using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Application.Common.Mappings;
using Goodtocode.Subjects.Persistence;

namespace Goodtocode.Application.Integration;

[SetUpFixture]
public class TestBase
{
    public enum ResponseType
    {
        Successful,
        BadRequest,
        NotFound,
        Error
    }

    private static IConfigurationRoot _configuration = null!;
    private static IServiceScopeFactory _scopeFactory = null!;

    public TestBase()
    {
        Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); })
            .CreateMapper();

        RunBeforeAnyTests();
    }

    public IMapper Mapper { get; }

    public IHttpClientFactory? HttpContextFactory { get; set; }

    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();

        _configuration = builder.Build();

        var services = new ServiceCollection();
        services.AddApplicationServices();
        services.AddInfrastructureServices(_configuration);

        services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
            w.EnvironmentName == "Development" &&
            w.ApplicationName == "Courses.WebApi"));

        services.AddLogging();

        _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        var sp = services.BuildServiceProvider();
        HttpContextFactory = sp.GetService<IHttpClientFactory>();
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