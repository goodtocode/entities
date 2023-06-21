using Goodtocode.Common.Extensions;
using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.BlazorServer.Pages.Business;
using Goodtocode.Subjects.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Text.Json;

namespace Goodtocode.Subjects.BlazorServer.Data;

public class BusinessService
{
    private readonly IHttpClientFactory _clientFactory;

    public BusinessService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<BusinessEntity> GetBusinessAsync(Guid businessKey)
    {
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.GetAsync($"{httpClient.BaseAddress}/Business?key={businessKey}&api-version=1");
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
        var business = new List<BusinessEntity>();
        if (string.IsNullOrEmpty(name)) return business;
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.GetAsync($"{httpClient.BaseAddress}/Businesses?name={name}&api-version=1");        
        if (response.StatusCode != HttpStatusCode.NotFound)
        {
            response.EnsureSuccessStatusCode();
            business = JsonSerializer.Deserialize<List<BusinessEntity>>(response.Content.ReadAsStream()) ?? throw new Exception("Deserialization failed.");
        }

        return business;
    }

    public async Task<BusinessEntity> CreateBusinessAsync(BusinessObject business)
    {
        BusinessEntity? businessCreated = new();
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.PutAsJsonAsync<BusinessObject>($"{httpClient.BaseAddress}/Business?api-version=1", business);        

        if (response.StatusCode == HttpStatusCode.Created)
            businessCreated = JsonSerializer.Deserialize<BusinessEntity>(await response.Content.ReadAsStreamAsync()) ?? throw new Exception("Deserialization failed.");
        
        response.EnsureSuccessStatusCode();

        return businessCreated;
    }

    public async Task<BusinessEntity> UpdateBusinessAsync(BusinessEntity business)
    {
        BusinessEntity? businessUpdated = null;
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.PostAsJsonAsync<BusinessObject>($"{httpClient.BaseAddress}/Business?key={business.BusinessKey}api-version=1", business.CopyPropertiesSafe<BusinessObject>());

        if (response.StatusCode == HttpStatusCode.OK)
            businessUpdated = JsonSerializer.Deserialize<BusinessEntity>(await response.Content.ReadAsStreamAsync());
        if (businessUpdated == null)
            throw new Exception();

        response.EnsureSuccessStatusCode();

        return businessUpdated;
    }

    public async Task<BusinessEntity> DeleteBusinessAsync(Guid businessKey)
    {
        BusinessEntity? businessUpdated = null;
        var httpClient = _clientFactory.CreateClient("SubjectsApiClient");
        var response = await httpClient.DeleteAsync($"{httpClient.BaseAddress}/Business?key={businessKey}api-version=1");

        response.EnsureSuccessStatusCode();

        return businessUpdated;
    }
}