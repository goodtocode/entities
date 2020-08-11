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

namespace GoodToCode.Shared.Domain
{
    public class BusinessSaveCommand : IRequest<CommandResponseWrapper<bool>>
    {
        public IBusiness Item { get; set; }

        public BusinessSaveCommand() { }

        public BusinessSaveCommand(IBusiness item)
        {
            Item = item;
        }

        public class Handler : IRequestHandler<BusinessSaveCommand, CommandResponseWrapper<bool>>
        {
            private readonly BusinessSaveCommandValidator _validator;
            private readonly List<KeyValuePair<string, string>> _errors;
            private readonly ISubjectsDbContext _context;
            private readonly IConfiguration _configuration;

            public Handler(ISubjectsDbContext context, IConfiguration configuration)
            {
                _configuration = configuration;
                _context = context;
                _validator = new BusinessSaveCommandValidator();
                _errors = new List<KeyValuePair<string, string>>();
            }

            public async Task<CommandResponseWrapper<bool>> Handle(BusinessSaveCommand request, CancellationToken cancellationToken)
            {
                var result = new CommandResponseWrapper<bool>() { Errors = GetRequestErrors(request) };
                int rowsAffected;

                if (result.Errors.Count == 0)
                {
                    try
                    {
                        var aggregate = new AssociateAggregate(_context, _configuration);
                        await aggregate.BusinessSaveAsync(request.Item);
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

            private List<KeyValuePair<string, string>> GetRequestErrors(BusinessSaveCommand request)
            {
                var issues = _validator.Validate((Business)request.Item).Errors;

                foreach (var issue in issues)
                    _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));
                return _errors;
            }

        }
    }
}
