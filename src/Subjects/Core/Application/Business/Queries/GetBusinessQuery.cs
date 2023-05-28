﻿using AutoMapper;
using Goodtocode.Subjects.Domain;
using Goodtocode.Subjects.Application;
using MediatR;

namespace Goodtocode.Subjects.Application;

public class GetBusinessQuery : IRequest<BusinessEntity>, IBusinessEntity
{
    public Guid BusinessKey { get; set; }
    public string BusinessName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
}

public class GetBusinessQueryHandler : IRequestHandler<GetBusinessQuery, IBusinessEntity>
{
    private readonly IMapper _mapper;
    private readonly IBusinessRepo _userBusinessRepo;

    public GetBusinessQueryHandler(IBusinessRepo userBusinessRepo, IMapper mapper)
    {
        _userBusinessRepo = userBusinessRepo;
        _mapper = mapper;
    }

    public async Task<IBusinessEntity> Handle(GetBusinessQuery request,
        CancellationToken cancellationToken)
    {
        var business =
            await _userBusinessRepo.GetBusinessAsync(request.BusinessKey,
                cancellationToken);

        return business.Value;
    }
}