using Goodtocode.Subjects.BlazorServer.Models;
using Goodtocode.Subjects.Domain;
using Goodtocode.Subjects.Rcl;
using System;

namespace Goodtocode.Subjects.BlazorServer.Data
{
    public interface IBusinessService
    {
        Task<PagedResult<BusinessModel>> GetBusinessesAsync(string name, int page);
        
        Task<BusinessModel> GetBusinessAsync(Guid businessKey);

        Task CreateBusinessAsync(BusinessModel business);

        Task UpdateBusinessAsync(BusinessModel business);

        Task DeleteBusinessAsync(Guid businessKey);

    }
}