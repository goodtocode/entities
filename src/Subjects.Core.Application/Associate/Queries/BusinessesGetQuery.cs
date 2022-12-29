﻿using GoodToCode.Shared.Cqrs;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Application
{
    public class BusinessesGetQuery : IRequest<QueryResponse<List<Business>>>
    {
        public Func<Business, bool> QueryPredicate { get; } = x => x.RowKey != Guid.Empty;


        public BusinessesGetQuery()
        {
        }

        public BusinessesGetQuery(Func<Business, bool> predicateExpression)
        {
            QueryPredicate = predicateExpression;
        }
    }

    public class BusinessesGetHandler : IRequestHandler<BusinessesGetQuery, QueryResponse<List<Business>>>
    {

        private readonly BusinessesGetValidator _validator;
        private readonly List<KeyValuePair<string, string>> _errors;
        private readonly SubjectsDbContext _dbContext;

        public BusinessesGetHandler(SubjectsDbContext dbContext)
        {

            _dbContext = dbContext;
            _validator = new BusinessesGetValidator();
            _errors = new List<KeyValuePair<string, string>>();
        }

        public async Task<QueryResponse<List<Business>>> Handle(BusinessesGetQuery request, CancellationToken cancellationToken)
        {
            var response = new QueryResponse<List<Business>>() { Errors = ValidateRequest(request) };

            if (!response.Errors.Any())
            {
                try
                {
                    response.Result = _dbContext.Business.Where(request.QueryPredicate).ToList();

                }
                catch
                {
                    response.ErrorInfo.UserErrorMessage = "An unknown error has occurred.";
                    response.ErrorInfo.HasException = true;
                }
            }

            return response;
        }

        private List<KeyValuePair<string, string>> ValidateRequest(BusinessesGetQuery request)
        {
            var issues = _validator.Validate(request).Errors;

            foreach (var issue in issues)
                _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));

            return _errors;
        }
    }
}