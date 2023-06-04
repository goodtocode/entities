using CSharpFunctionalExtensions;
using Goodtocode.Subjects.Domain;

namespace Goodtocode.Subjects.Application;

public interface IBusinessRepo
{
    Task<Result<BusinessEntity?>> GetBusinessAsync(Guid businessKey,
        CancellationToken cancellationToken);

    Task<Result<List<BusinessEntity>>> GetBusinessesByNameAsync(string businessName,
        CancellationToken cancellationToken);

    Task<Result> AddBusinessAsync(IBusinessObject businessInfo,
        CancellationToken cancellationToken);

    Task<Result> UpdateBusinessAsync(IBusinessEntity businessInfo,
        CancellationToken cancellationToken);
}