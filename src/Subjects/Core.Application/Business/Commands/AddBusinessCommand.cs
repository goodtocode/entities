using CSharpFunctionalExtensions;
using Goodtocode.Subjects.Application.Common.Exceptions;
using Goodtocode.Subjects.Domain;
using MediatR;

namespace Goodtocode.Subjects.Application;

public class AddBusinessCommand : IRequest<BusinessEntity>, IBusinessObject
{
    public string BusinessName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
}

public class AddBusinessCommandHandler : IRequestHandler<AddBusinessCommand, BusinessEntity>
{
    private readonly IBusinessRepo _userBusinessRepo;

    public AddBusinessCommandHandler(IBusinessRepo BusinessRepo)
    {
        _userBusinessRepo = BusinessRepo;
    }

    public async Task<BusinessEntity> Handle(AddBusinessCommand request, CancellationToken cancellationToken)
    {
        var business =
            await _userBusinessRepo.AddBusinessAsync(request, cancellationToken);

        return business.Match(
            value => business.Value,
            failure => throw new ConflictException(business.Error)
            );
    }
}