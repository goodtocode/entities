using Goodtocode.Common.Extensions;
using Goodtocode.Subjects.Models;
using Goodtocode.Subjects.Domain;
using System.Net;
using System.Text.Json;

namespace Goodtocode.Subjects.Data;

public class BusinessService : IBusinessService
{
    private readonly IHttpClientFactory _clientFactory;
    private const int apiVersion = 1;

    public BusinessService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<BusinessModel> GetBusinessAsync(Guid businessKey)
    {
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.GetAsync($"{httpClient.BaseAddress}Business?key={businessKey}&api-version={apiVersion}");
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

    public async Task<PagedResult<BusinessModel>> GetBusinessesAsync(SearchModel search, int page)
    {
        var business = new PagedResult<BusinessModel>();
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.GetAsync($"{httpClient.BaseAddress}Businesses?name={search.Name}&pageNumber={page}&pageSize=20&api-version={apiVersion}");
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
        var businessDto = business.CopyPropertiesSafe<BusinessObject>();
        var response = await httpClient.PutAsJsonAsync<BusinessObject>($"{httpClient.BaseAddress}Business?api-version=1", businessDto);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateBusinessAsync(BusinessModel business)
    {
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var businessDto = business.CopyPropertiesSafe<BusinessObject>();
        var response = await httpClient.PostAsJsonAsync<BusinessObject>($"{httpClient.BaseAddress}Business?key={business.BusinessKey}api-version={apiVersion}", businessDto);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteBusinessAsync(Guid businessKey)
    {
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.DeleteAsync($"{httpClient.BaseAddress}Business?key={businessKey}api-version={apiVersion}");
        response.EnsureSuccessStatusCode();
    }
}