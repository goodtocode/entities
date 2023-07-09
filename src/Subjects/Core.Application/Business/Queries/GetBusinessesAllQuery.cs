using Goodtocode.Common.Extensions;
using Goodtocode.Subjects.Domain;
using MediatR;

namespace Goodtocode.Subjects.Application;

public class GetBusinessesAllQuery : IRequest<PagedResult<BusinessEntity>>
{
    public string BusinessName { get; set; } = string.Empty;
    public int Page { get; set; } = 1;
    public int Results { get; set; } = 20;
}

public class GetBusinessesAllQueryHandler : IRequestHandler<GetBusinessesAllQuery, PagedResult<BusinessEntity>>
{
    private readonly IBusinessRepo _userBusinessesRepo;

    public GetBusinessesAllQueryHandler(IBusinessRepo userBusinessesRepo)
    {
        _userBusinessesRepo = userBusinessesRepo;
    }

    public async Task<PagedResult<BusinessEntity>> Handle(GetBusinessesAllQuery request,
        CancellationToken cancellationToken)
    {
        var businesses =
            await _userBusinessesRepo.GetBusinessesAllAsync(request.BusinessName, request.Page, request.Results,
                cancellationToken);
        
        return businesses.GetValueOrDefault();
    }
}