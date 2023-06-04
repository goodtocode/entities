using Goodtocode.Subjects.Application.Common.Exceptions;
using Goodtocode.Subjects.Domain;
using MediatR;

namespace Goodtocode.Subjects.Application;

public class UpdateBusinessCommand : IRequest, IBusinessEntity
{
    public Guid BusinessKey { get; set; }
    public string BusinessName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
}

public class UpdateBusinessCommandHandler : IRequestHandler<UpdateBusinessCommand>
{
    private readonly IBusinessRepo _userBusinessRepo;

    public UpdateBusinessCommandHandler(IBusinessRepo BusinessRepo)
    {
        _userBusinessRepo = BusinessRepo;
    }

    public async Task Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
    {
        var updateResult =
            await _userBusinessRepo.UpdateBusinessAsync(request, cancellationToken);

        if (updateResult.IsFailure)
            throw new NotFoundException(updateResult.Error);
    }
}