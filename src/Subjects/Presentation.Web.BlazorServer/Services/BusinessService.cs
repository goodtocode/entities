using Goodtocode.Common.Extensions;
using Goodtocode.Subjects.BlazorServer.Models;
using Goodtocode.Subjects.Domain;
using Goodtocode.Subjects.Rcl;
using System.Net;
using System.Text.Json;

namespace Goodtocode.Subjects.BlazorServer.Data;

public class BusinessService : IBusinessService
{
    private readonly IHttpClientFactory _clientFactory;

    public BusinessService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<BusinessModel> GetBusinessAsync(Guid businessKey)
    {
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.GetAsync($"{httpClient.BaseAddress}/Business?key={businessKey}&api-version=1");
        var business = new BusinessModel();
        if (response.StatusCode != HttpStatusCode.NotFound)
        {
            response.EnsureSuccessStatusCode();
            business = JsonSerializer.Deserialize<BusinessModel>(response.Content.ReadAsStream());
            if (business == null)
                throw new Exception();
        }
        return business;
    }

    public async Task<PagedResult<BusinessModel>> GetBusinessesAsync(string name, int page)
    {
        var business = new PagedResult<BusinessModel>();
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.GetAsync($"{httpClient.BaseAddress}Businesses?name={name}&pageNumber=1&pageSize=20&api-version=1");        
        if (response.StatusCode != HttpStatusCode.NotFound)
        {
            response.EnsureSuccessStatusCode();
            business = JsonSerializer.Deserialize<PagedResult<BusinessModel>>(response.Content.ReadAsStream()) ?? throw new Exception("Deserialization failed.");
        }

        return business;
    }

    public async Task CreateBusinessAsync(BusinessModel business)
    {
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.PutAsJsonAsync<BusinessObject>($"{httpClient.BaseAddress}/Business?api-version=1", business.CopyPropertiesSafe<BusinessObject>());              
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateBusinessAsync(BusinessModel business)
    {
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.PostAsJsonAsync<BusinessObject>($"{httpClient.BaseAddress}/Business?key={business.BusinessKey}api-version=1", business.CopyPropertiesSafe<BusinessObject>());
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteBusinessAsync(Guid businessKey)
    {
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.DeleteAsync($"{httpClient.BaseAddress}/Business?key={businessKey}api-version=1");
        response.EnsureSuccessStatusCode();
    }
}