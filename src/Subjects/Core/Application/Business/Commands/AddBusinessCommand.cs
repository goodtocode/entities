using Goodtocode.Subjects.Domain;
using MediatR;

namespace Goodtocode.Subjects.Application;

public class AddBusinessCommand : IRequest, IBusinessEntity
{
    public Guid BusinessKey { get; set; }
    public string BusinessName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
}

public class AddBusinessCommandHandler : IRequestHandler<AddBusinessCommand>
{
    private readonly IBusinessRepo _userBusinessRepo;

    public AddBusinessCommandHandler(IBusinessRepo BusinessRepo)
    {
        _userBusinessRepo = BusinessRepo;
    }

    public async Task Handle(AddBusinessCommand request, CancellationToken cancellationToken)
    {
        var AddResult =
            await _userBusinessRepo.AddBusinessAsync(request, cancellationToken);

        if (AddResult.IsFailure)
            throw new Exception(AddResult.Error);
    }
}