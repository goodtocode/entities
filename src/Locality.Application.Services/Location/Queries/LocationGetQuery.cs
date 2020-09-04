using GoodToCode.Shared.Cqrs;
using GoodToCode.Locality.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoodToCode.Locality.Infrastructure;

namespace GoodToCode.Locality.Application
{
    public class LocationGetQuery : IRequest<QueryResponse<List<Location>>>
    {
        public Func<Location, bool> QueryPredicate { get; }


        public LocationGetQuery(Guid LocationKey)
        {
            QueryPredicate = (x => x.LocationKey == LocationKey);
        }

        public LocationGetQuery(Func<Location, bool> predicateExpression)
        {
            QueryPredicate = predicateExpression;
        }

        public Guid LocationKey { get; set; }
    }

    public class LocationGetHandler : IRequestHandler<LocationGetQuery, QueryResponse<List<Location>>>
    {

        private readonly LocationGetValidator _validator;
        private readonly List<KeyValuePair<string, string>> _errors;
        private readonly ILogger<LocationGetHandler> _logger;
        private readonly LocalityDbContext _dbContext;

        public LocationGetHandler(LocalityDbContext dbContext)
        {

            _dbContext = dbContext;
            _validator = new LocationGetValidator();
            _errors = new List<KeyValuePair<string, string>>();
        }

        public async Task<QueryResponse<List<Location>>> Handle(LocationGetQuery request, CancellationToken cancellationToken)
        {
            var response = new QueryResponse<List<Location>>() { Errors = ValidateRequest(request) };

            if (!response.Errors.Any())
            {
                try
                {
                    response.Result = _dbContext.Location.Where(request.QueryPredicate).ToList();

                }
                catch (Exception e)
                {
                    _logger.LogCritical(e.ToString());
                    response.ErrorInfo.UserErrorMessage = "Some Error Has Occured";
                    response.ErrorInfo.HasException = true;
                }
            }

            return response;
        }

        private List<KeyValuePair<string, string>> ValidateRequest(LocationGetQuery request)
        {
            var issues = _validator.Validate(request).Errors;

            foreach (var issue in issues)
                _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));

            return _errors;
        }
    }
}