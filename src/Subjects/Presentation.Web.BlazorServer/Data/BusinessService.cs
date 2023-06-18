using Goodtocode.Subjects.BlazorServer.Pages.Business;
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
            if (business == null)
                throw new Exception();
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
            if (business == null)
                throw new Exception();
        }
        return business;
    }

    public async Task<BusinessEntity> CreateBusinessAsync(BusinessObject business)
    {
        BusinessEntity? businessCreated = null;
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.PutAsJsonAsync<BusinessObject>($"{httpClient.BaseAddress}/Business?api-version=1", business);        

        if (response.StatusCode == HttpStatusCode.Created)
            businessCreated = JsonSerializer.Deserialize<BusinessEntity>(await response.Content.ReadAsStreamAsync());

        if (businessCreated == null)
            throw new Exception();
        
        response.EnsureSuccessStatusCode();

        return businessCreated;
    }
}