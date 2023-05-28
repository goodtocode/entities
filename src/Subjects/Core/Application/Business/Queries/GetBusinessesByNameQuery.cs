using Goodtocode.Subjects.Domain;
using MediatR;

namespace Goodtocode.Subjects.Application;

public class GetBusinessesByNameQuery : IRequest<List<BusinessEntity>>
{
    public string BusinessName { get; set; } = string.Empty;
}

public class GetBusinessesByNameQueryHandler : IRequestHandler<GetBusinessesByNameQuery, List<BusinessEntity>>
{
    private readonly IBusinessRepo _userBusinessesRepo;

    public GetBusinessesByNameQueryHandler(IBusinessRepo userBusinessesRepo)
    {
        _userBusinessesRepo = userBusinessesRepo;
    }

    public async Task<List<BusinessEntity>> Handle(GetBusinessesByNameQuery request,
        CancellationToken cancellationToken)
    {
        var businesses =
            await _userBusinessesRepo.GetBusinessesByNameAsync(request.BusinessName,
                cancellationToken);

        return businesses.Value ?? new List<BusinessEntity>();
    }
}