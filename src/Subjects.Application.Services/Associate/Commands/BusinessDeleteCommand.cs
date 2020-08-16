using GoodToCode.Shared.Cqrs;
using GoodToCode.Shared.Extensions;
using GoodToCode.Shared.Validation;
using GoodToCode.Subjects.Aggregates;
using GoodToCode.Subjects.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Application
{
    public class BusinessDeleteCommand : IRequest<CommandResponseWrapper<bool>>
    {
        public IBusiness Item { get; set; }

        public BusinessDeleteCommand() { }

        public BusinessDeleteCommand(IBusiness item)
        {
            Item = item;
        }

        public class Handler : IRequestHandler<BusinessDeleteCommand, CommandResponseWrapper<bool>>
        {
            private readonly BusinessDeleteValidator _validator;
            private readonly List<KeyValuePair<string, string>> _errors;
            private readonly ISubjectsDbContext _context;

            public Handler(ISubjectsDbContext context)
            {
                _context = context;
                _validator = new BusinessDeleteValidator();
                _errors = new List<KeyValuePair<string, string>>();
            }

            public async Task<CommandResponseWrapper<bool>> Handle(BusinessDeleteCommand request, CancellationToken cancellationToken)
            {
                var result = new CommandResponseWrapper<bool>() { Errors = GetRequestErrors(request) };

                if (result.Errors.Count == 0)
                {
                    try
                    {
                        var aggregate = new AssociateAggregate(_context);
                        await aggregate.BusinessDeleteAsync(request.Item);
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

            private List<KeyValuePair<string, string>> GetRequestErrors(BusinessDeleteCommand request)
            {
                var issues = _validator.Validate((Business)request.Item).Errors;

                foreach (var issue in issues)
                    _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));
                return _errors;
            }

        }
    }
}
