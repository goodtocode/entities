using CSharpFunctionalExtensions;
using Goodtocode.Common.Extensions;
using Goodtocode.Subjects.Domain;

namespace Goodtocode.Subjects.Application;

public interface IBusinessRepo : IDisposable
{
    Task<Result<BusinessEntity?>> GetBusinessByKeyAsync(Guid businessKey,
        CancellationToken cancellationToken);

    Task<Result<PagedResult<BusinessEntity>>> GetBusinessesAllAsync(string businessName, int page, int results,
        CancellationToken cancellationToken);

    Task<Result<PagedResult<BusinessEntity>>> GetBusinessesByNameAsync(string businessName, int page, int results,
        CancellationToken cancellationToken);

    Task<Result<BusinessEntity>> AddBusinessAsync(IBusinessObject businessInfo,
        CancellationToken cancellationToken);

    Task<Result> UpdateBusinessAsync(IBusinessEntity businessInfo,
        CancellationToken cancellationToken);

    Task<Result> DeleteBusinessAsync(Guid businessKey,
    CancellationToken cancellationToken);
}