using Goodtocode.Subjects.Application.Common.Exceptions;
using Goodtocode.Subjects.Domain;
using MediatR;

namespace Goodtocode.Subjects.Application;

public class DeleteBusinessCommand : IRequest
{
    public Guid BusinessKey { get; set; }
}

public class DeleteBusinessCommandHandler : IRequestHandler<DeleteBusinessCommand>
{
    private readonly IBusinessRepo _userBusinessRepo;

    public DeleteBusinessCommandHandler(IBusinessRepo BusinessRepo)
    {
        _userBusinessRepo = BusinessRepo;
    }

    public async Task Handle(DeleteBusinessCommand request, CancellationToken cancellationToken)
    {
        var DeleteResult =
            await _userBusinessRepo.DeleteBusinessAsync(request.BusinessKey, cancellationToken);

        if (DeleteResult.IsFailure)
            throw new NotFoundException(DeleteResult.Error);
    }
}