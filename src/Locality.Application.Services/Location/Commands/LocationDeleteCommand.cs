using GoodToCode.Locality.Models;
using GoodToCode.Shared.Cqrs;
using GoodToCode.Shared.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoodToCode.Locality.Application
{
    public class LocationDeleteCommand : IRequest<CommandResponseWrapper<bool>>
    {
        public ILocation Item { get; set; }

        public LocationDeleteCommand() { }

        public LocationDeleteCommand(ILocation item)
        {
            Item = item;
        }

        public class Handler : IRequestHandler<LocationDeleteCommand, CommandResponseWrapper<bool>>
        {
            private readonly LocationDeleteValidator _validator;
            private readonly List<KeyValuePair<string, string>> _errors;
            private readonly ILocalityDbContext _dbContext;

            public Handler(ILocalityDbContext context)
            {
                _dbContext = context;
                _validator = new LocationDeleteValidator();
                _errors = new List<KeyValuePair<string, string>>();
            }

            public async Task<CommandResponseWrapper<bool>> Handle(LocationDeleteCommand request, CancellationToken cancellationToken)
            {
                var result = new CommandResponseWrapper<bool>() { Errors = GetRequestErrors(request) };

                if (result.Errors.Count == 0)
                {
                    try
                    {
                        var aggregate = new LocationAggregate(_dbContext);
                        await aggregate.LocationDeleteAsync(request.Item);
                        result.Result = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                        result.ErrorInfo = new ErrorInfo()
                        {
                            UserErrorMessage = "An internal error has occured",
                            HasException = true
                        };
                    }
                }
                return result;
            }

            private List<KeyValuePair<string, string>> GetRequestErrors(LocationDeleteCommand request)
            {
                var issues = _validator.Validate((Location)request.Item).Errors;

                foreach (var issue in issues)
                    _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));
                return _errors;
            }

        }
    }
}
