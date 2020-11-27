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
    public class LocationSaveCommand : IRequest<CommandResponse<Location>>
    {
        public ILocation Item { get; set; }

        public LocationSaveCommand() { }

        public LocationSaveCommand(ILocation item)
        {
            Item = item;
        }
    }

    public class LocationSaveHandler : IRequestHandler<LocationSaveCommand, CommandResponse<Location>>
    {
        private readonly LocationSaveValidator _validator;
        private readonly List<KeyValuePair<string, string>> _errors;
        private readonly ILocalityDbContext _dbContext;

        public LocationSaveHandler(ILocalityDbContext context)
        {
            _dbContext = context;
            _validator = new LocationSaveValidator();
            _errors = new List<KeyValuePair<string, string>>();
        }

        public async Task<CommandResponse<Location>> Handle(LocationSaveCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResponse<Location>() { Errors = GetRequestErrors(request) };

            if (result.Errors.Count == 0)
            {
                try
                {
                    var aggregate = new LocationAggregate(_dbContext);
                    await aggregate.LocationSaveAsync(request.Item);
                    result.Result = (Location)request.Item;
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

        private List<KeyValuePair<string, string>> GetRequestErrors(LocationSaveCommand request)
        {
            var issues = _validator.Validate((Location)request.Item).Errors;

            foreach (var issue in issues)
                _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));
            return _errors;
        }

    }
}
