using Goodtocode.Common.Extensions;
using Goodtocode.Subjects.Models;

namespace Goodtocode.Subjects.Data
{
    public interface IBusinessService
    {
        Task<PagedResult<BusinessModel>> GetBusinessesAsync(SearchModel search, int page);
        
        Task<BusinessModel> GetBusinessAsync(Guid businessKey);

        Task CreateBusinessAsync(BusinessModel business);

        Task UpdateBusinessAsync(BusinessModel business);

        Task DeleteBusinessAsync(Guid businessKey);

    }
}