using Goodtocode.Subjects.Domain;
using System.Net;
using System.Text.Json;

namespace Goodtocode.Subjects.BlazorServer.Data;

public class BusinessService
{
    private IHttpClientFactory _clientFactory;

    public BusinessService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<BusinessEntity> GetBusinessAsync(Guid key)
    {
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.GetAsync($"{httpClient.BaseAddress}/Business?key={key}&api-version=1");
        var business = new BusinessEntity();
        if (response.StatusCode != HttpStatusCode.NotFound)
        {
            response.EnsureSuccessStatusCode();
            business = JsonSerializer.Deserialize<BusinessEntity>(response.Content.ReadAsStream());
        }
        return business;
    }

    public async Task<IEnumerable<BusinessEntity>> GetBusinessesAsync(string name)
    {
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.GetAsync($"{httpClient.BaseAddress}/Businesses?name={name}&api-version=1");
        var business = new List<BusinessEntity>();
        if (response.StatusCode != HttpStatusCode.NotFound)
        {
            response.EnsureSuccessStatusCode();
            business = JsonSerializer.Deserialize<List<BusinessEntity>>(response.Content.ReadAsStream());
        }
        return business;
    }
}