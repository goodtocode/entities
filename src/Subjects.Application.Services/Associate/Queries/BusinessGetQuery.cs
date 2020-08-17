using GoodToCode.Shared.Cqrs;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Application
{
    public class BusinessGetQuery : IRequest<QueryResponseWrapper<List<Business>>>
    {
        public Func<Business, bool> QueryPredicate { get; }


        public BusinessGetQuery(Guid businessKey)
        {
            QueryPredicate = (x => x.BusinessKey == businessKey);
        }

        public BusinessGetQuery(Func<Business, bool> predicateExpression)
        {
            QueryPredicate = predicateExpression;
        }

        public Guid BusinessKey { get; set; }
    }

    public class BusinessGetHandler : IRequestHandler<BusinessGetQuery, QueryResponseWrapper<List<Business>>>
    {

        private readonly BusinessGetValidator _validator;
        private readonly List<KeyValuePair<string, string>> _errors;
        private readonly ILogger<BusinessGetHandler> _logger;
        private readonly SubjectsDbContext _dbContext;

        public BusinessGetHandler(SubjectsDbContext dbContext)
        {

            _dbContext = dbContext;
            _validator = new BusinessGetValidator();
            _errors = new List<KeyValuePair<string, string>>();
        }

        public async Task<QueryResponseWrapper<List<Business>>> Handle(BusinessGetQuery request, CancellationToken cancellationToken)
        {
            var response = new QueryResponseWrapper<List<Business>>() { Errors = ValidateRequest(request) };

            if (!response.Errors.Any())
            {
                try
                {
                    response.Result = _dbContext.Business.Where(request.QueryPredicate).ToList();

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

        private List<KeyValuePair<string, string>> ValidateRequest(BusinessGetQuery request)
        {
            var issues = _validator.Validate(request).Errors;

            foreach (var issue in issues)
                _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));

            return _errors;
        }
    }
}