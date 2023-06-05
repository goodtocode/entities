using Azure.Identity;
using FluentValidation.AspNetCore;
using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Persistence;
using Goodtocode.Subjects.WebApi.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

var builder = WebApplication.CreateBuilder(args);

var requiredAuthUserPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

builder.Services.AddControllersWithViews(setupAction =>
    {
        setupAction.Filters.Add(
            new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
        setupAction.Filters.Add(
            new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
        setupAction.Filters.Add(
            new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
        setupAction.Filters.Add(
            new ProducesDefaultResponseTypeAttribute());
        setupAction.Filters.Add(
            new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
        setupAction.OutputFormatters.Add(new XmlSerializerOutputFormatter());
        setupAction.Filters.Add(new AuthorizeFilter(requiredAuthUserPolicy));
        setupAction.Filters.Add<ApiExceptionFilterAttribute>();
    })
    .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration);

builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin",
        options => options.AllowAnyOrigin());
});

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationInsightsTelemetry(options =>
{
    options.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];
});

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer"
        });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {Id = "Bearer", Type = ReferenceType.SecurityScheme}
            },
            new List<string>()
        }
    });

    setupAction.MapType<decimal>(() =>
        new OpenApiSchema
        {
            Type = "number",
            Format = "decimal"
        });
});

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddApplicationInsightsTelemetry(options =>
{
    options.ConnectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];
});

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName ?? "Development"}.json", true, true)
    .AddAzureKeyVault(new Uri(builder.Configuration["Azure:KeyVaultUri"]), new DefaultAzureCredential())
    .AddEnvironmentVariables();

BuildApiVerAndApiExplorer(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    UseSwaggarUiConfigs();
}

app.UseRouting();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();


void UseSwaggarUiConfigs()
{
    var providers = app.Services.GetService<IApiVersionDescriptionProvider>();

    app.UseSwaggerUI(options =>
    {
        if (providers == null) return;
        foreach (var description in providers.ApiVersionDescriptions)
            options.SwaggerEndpoint($"../swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
    });
}

void BuildApiVerAndApiExplorer(WebApplicationBuilder webApplicationBuilder)
{
    webApplicationBuilder.Services.AddApiVersioning(setup =>
    {
        setup.DefaultApiVersion = new ApiVersion(1, 0);
        setup.AssumeDefaultVersionWhenUnspecified = true;
        setup.ReportApiVersions = true;
    });

    webApplicationBuilder.Services.AddVersionedApiExplorer(setup =>
    {
        setup.GroupNameFormat = "'v'VVV";
        setup.SubstituteApiVersionInUrl = true;
    });
}