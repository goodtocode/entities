using Goodtocode.Common.Infrastructure.ApiClient;
using Goodtocode.Subjects.BlazorServer.Data;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Polly;
using static Azure.Core.HttpHeader;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddApiClientServices("SubjectsApiClient", builder.Configuration["Subjects:Url"], 
    new ClientCredentialSetting(
    builder.Configuration["Subjects:ClientId"],
    builder.Configuration["Subjects:ClientSecret"],
    builder.Configuration["Subjects:TokenUrl"],
    builder.Configuration["Subjects:Scope"])
);

//builder.Services.AddTransient<BearerTokenHandler>();
//builder.Services.AddSingleton<AccessToken>();
//builder.Services.AddSingleton(AccessTokenSetting => new ClientCredentialSetting(
//    builder.Configuration["Subjects:ClientId"],
//    builder.Configuration["Subjects:ClientSecret"],
//    builder.Configuration["Subjects:TokenUrl"],
//    builder.Configuration["Subjects:Scope"]));
//builder.Services.AddHttpClient("SubjectsApiClient", client =>
//{
//    client.DefaultRequestHeaders.Clear();
//    client.BaseAddress = new Uri(builder.Configuration["Subjects:Url"]);
//}
//    ).AddHttpMessageHandler<BearerTokenHandler>()
//    .AddPolicyHandler(
//        Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
//            .RetryAsync(3)
//    );

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName ?? "Development"}.json", true, true)
    .AddEnvironmentVariables();

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
