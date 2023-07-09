using AutoMapper;
using CSharpFunctionalExtensions;
using Goodtocode.Subjects.Application.Common.Exceptions;
using Goodtocode.Subjects.Domain;
using MediatR;

namespace Goodtocode.Subjects.Application;

public class GetBusinessByKeyQuery : IRequest<BusinessEntity>
{
    public Guid BusinessKey { get; set; }
}

public class GetBusinessByKeyQueryHandler : IRequestHandler<GetBusinessByKeyQuery, BusinessEntity?>
{
    private readonly IMapper _mapper;
    private readonly IBusinessRepo _userBusinessRepo;

    public GetBusinessByKeyQueryHandler(IBusinessRepo userBusinessRepo, IMapper mapper)
    {
        _userBusinessRepo = userBusinessRepo;
        _mapper = mapper;
    }

    public async Task<BusinessEntity?> Handle(GetBusinessByKeyQuery request,
        CancellationToken cancellationToken)
    {
        var business =
            await _userBusinessRepo.GetBusinessByKeyAsync(request.BusinessKey,
                cancellationToken);

        return business.Match(
            value => business.Value,
            failure => throw new NotFoundException(business.Error)
            );
    }
}