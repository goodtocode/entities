using AutoMapper;
using CSharpFunctionalExtensions;
using Goodtocode.Subjects.Application.Common.Exceptions;
using Goodtocode.Subjects.Domain;
using MediatR;

namespace Goodtocode.Subjects.Application;

public class GetBusinessQuery : IRequest<BusinessEntity>, IBusinessEntity
{
    public Guid BusinessKey { get; set; }
    public string BusinessName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
}

public class GetBusinessQueryHandler : IRequestHandler<GetBusinessQuery, BusinessEntity?>
{
    private readonly IMapper _mapper;
    private readonly IBusinessRepo _userBusinessRepo;

    public GetBusinessQueryHandler(IBusinessRepo userBusinessRepo, IMapper mapper)
    {
        _userBusinessRepo = userBusinessRepo;
        _mapper = mapper;
    }

    public async Task<BusinessEntity?> Handle(GetBusinessQuery request,
        CancellationToken cancellationToken)
    {
        var business =
            await _userBusinessRepo.GetBusinessAsync(request.BusinessKey,
                cancellationToken);

        return business.Match(
            value => business.Value,
            failure => throw new NotFoundException(business.Error)
            );
    }
}