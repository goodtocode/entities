﻿using GoodToCode.Shared.Cqrs;
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
    public class EventGetQuery : IRequest<QueryResponse<List<Event>>>
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

    public class EventGetHandler : IRequestHandler<EventGetQuery, QueryResponse<List<Event>>>
    {

        private readonly EventGetQueryValidator _validator;
        private readonly List<KeyValuePair<string, string>> _errors;
        private readonly OccurrencesDbContext _dbContext;

        public EventGetHandler(OccurrencesDbContext dbContext)
        {

            _dbContext = dbContext;
            _validator = new EventGetQueryValidator();
            _errors = new List<KeyValuePair<string, string>>();
        }

        public async Task<QueryResponse<List<Event>>> Handle(EventGetQuery request, CancellationToken cancellationToken)
        {
            var response = new QueryResponse<List<Event>>() { Errors = ValidateRequest(request) };

            if (!response.Errors.Any())
            {
                try
                {
                    response.Result = _dbContext.Event.Where(request.QueryPredicate).ToList();

                }
                catch
                {
                    response.ErrorInfo.UserErrorMessage = "An unknown error has occurred.";
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