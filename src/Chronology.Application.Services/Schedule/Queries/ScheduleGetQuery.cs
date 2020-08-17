using GoodToCode.Chronology.Infrastructure;
using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Cqrs;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoodToCode.Chronology.Application
{
    public class ScheduleGetQuery : IRequest<QueryResponseWrapper<List<Schedule>>>
    {
        public Func<Schedule, bool> QueryPredicate { get; }


        public ScheduleGetQuery(Guid ScheduleKey)
        {
            QueryPredicate = (x => x.ScheduleKey == ScheduleKey);
        }

        public ScheduleGetQuery(Func<Schedule, bool> predicateExpression)
        {
            QueryPredicate = predicateExpression;
        }

        public Guid ScheduleKey { get; set; }
    }

    public class ScheduleGetHandler : IRequestHandler<ScheduleGetQuery, QueryResponseWrapper<List<Schedule>>>
    {

        private readonly ScheduleGetValidator _validator;
        private readonly List<KeyValuePair<string, string>> _errors;
        private readonly ILogger<ScheduleGetHandler> _logger;
        private readonly ChronologyDbContext _dbContext;

        public ScheduleGetHandler(ChronologyDbContext dbContext)
        {

            _dbContext = dbContext;
            _validator = new ScheduleGetValidator();
            _errors = new List<KeyValuePair<string, string>>();
        }

        public async Task<QueryResponseWrapper<List<Schedule>>> Handle(ScheduleGetQuery request, CancellationToken cancellationToken)
        {
            var response = new QueryResponseWrapper<List<Schedule>>() { Errors = ValidateRequest(request) };

            if (!response.Errors.Any())
            {
                try
                {
                    response.Result = _dbContext.Schedule.Where(request.QueryPredicate).ToList();

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

        private List<KeyValuePair<string, string>> ValidateRequest(ScheduleGetQuery request)
        {
            var issues = _validator.Validate(request).Errors;

            foreach (var issue in issues)
                _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));

            return _errors;
        }
    }
}