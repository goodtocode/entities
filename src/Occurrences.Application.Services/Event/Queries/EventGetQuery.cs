using GoodToCode.Shared.Cqrs;
using GoodToCode.Occurrences.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoodToCode.Occurrences.Infrastructure;

namespace GoodToCode.Occurrences.Application
{
    public class EventGetQuery : IRequest<QueryResponseWrapper<List<Event>>>
    {
        public Func<Event, bool> QueryPredicate { get; }


        public EventGetQuery(Guid EventKey)
        {
            QueryPredicate = (x => x.EventKey == EventKey);
        }

        public EventGetQuery(Func<Event, bool> predicateExpression)
        {
            QueryPredicate = predicateExpression;
        }

        public Guid EventKey { get; set; }
    }

    public class EventGetHandler : IRequestHandler<EventGetQuery, QueryResponseWrapper<List<Event>>>
    {

        private readonly EventGetQueryValidator _validator;
        private readonly List<KeyValuePair<string, string>> _errors;
        private readonly ILogger<EventGetHandler> _logger;
        private readonly OccurrencesDbContext _dbContext;

        public EventGetHandler(OccurrencesDbContext dbContext)
        {

            _dbContext = dbContext;
            _validator = new EventGetQueryValidator();
            _errors = new List<KeyValuePair<string, string>>();
        }

        public async Task<QueryResponseWrapper<List<Event>>> Handle(EventGetQuery request, CancellationToken cancellationToken)
        {
            var response = new QueryResponseWrapper<List<Event>>() { Errors = ValidateRequest(request) };

            if (!response.Errors.Any())
            {
                try
                {
                    response.Result = _dbContext.Event.Where(request.QueryPredicate).ToList();

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

        private List<KeyValuePair<string, string>> ValidateRequest(EventGetQuery request)
        {
            var issues = _validator.Validate(request).Errors;

            foreach (var issue in issues)
                _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));

            return _errors;
        }
    }
}