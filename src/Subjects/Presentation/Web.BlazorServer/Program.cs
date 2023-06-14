using Azure.Identity;
using Goodtocode.Common.Infrastructure.ApiClient;
using Goodtocode.Subjects.BlazorServer.Data;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName ?? "Development"}.json", true, true)
    .AddEnvironmentVariables();

if (builder.Configuration.GetValue<bool>("Azure:UseKeyVault"))
    builder.Configuration.AddAzureKeyVault(new Uri(builder.Configuration["Azure:KeyVaultUri"]), new DefaultAzureCredential());

// Add services to the container.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();

builder.Services.AddApplicationInsightsTelemetry(options =>
{
    options.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];
});

builder.Services.AddApiClientServices("SubjectsApiClient", builder.Configuration["Subjects:Url"],
    new ClientCredentialSetting(
    builder.Configuration["Subjects:ClientId"],
    builder.Configuration["SubjectsClientSecret"],
    builder.Configuration["Subjects:TokenUrl"],
    builder.Configuration["Subjects:Scope"])
);

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<BusinessService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
