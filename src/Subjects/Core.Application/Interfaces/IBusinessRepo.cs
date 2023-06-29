using CSharpFunctionalExtensions;
using Goodtocode.Common.Extensions;
using Goodtocode.Subjects.Domain;

namespace Goodtocode.Subjects.Application;

public interface IBusinessRepo
{
    Task<Result<BusinessEntity?>> GetBusinessAsync(Guid businessKey,
        CancellationToken cancellationToken);

    Task<Result<PagedResult<BusinessEntity>>> GetBusinessesByNameAsync(string businessName, int page,
        CancellationToken cancellationToken);

    Task<Result<BusinessEntity>> AddBusinessAsync(IBusinessObject businessInfo,
        CancellationToken cancellationToken);

    Task<Result> UpdateBusinessAsync(IBusinessEntity businessInfo,
        CancellationToken cancellationToken);

    Task<Result> DeleteBusinessAsync(Guid businessKey,
    CancellationToken cancellationToken);
}