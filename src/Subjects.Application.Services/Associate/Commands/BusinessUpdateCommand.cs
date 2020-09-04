using GoodToCode.Shared.Cqrs;
using GoodToCode.Shared.Validation;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Application
{
    public class BusinessUpdateCommand : IRequest<CommandResponse<Business>>
    {
        public IBusiness Item { get; set; }

        public BusinessUpdateCommand() { }

        public BusinessUpdateCommand(IBusiness item)
        {
            Item = item;
        }
    }

    public class BusinessUpdateHandler : IRequestHandler<BusinessUpdateCommand, CommandResponse<Business>>
    {
        private readonly BusinessUpdateValidator _validator;
        private readonly List<KeyValuePair<string, string>> _errors;
        private readonly ISubjectsDbContext _dbContext;

        public BusinessUpdateHandler(ISubjectsDbContext context)
        {
            _dbContext = context;
            _validator = new BusinessUpdateValidator();
            _errors = new List<KeyValuePair<string, string>>();
        }

        public async Task<CommandResponse<Business>> Handle(BusinessUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResponse<Business>() { Errors = GetRequestErrors(request) };

            if (result.Errors.Count == 0)
            {
                try
                {
                    var aggregate = new AssociateAggregate(_dbContext);
                    await aggregate.BusinessUpdateAsync(request.Item);
                    result.Result = (Business)request.Item;
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

        private List<KeyValuePair<string, string>> GetRequestErrors(BusinessUpdateCommand request)
        {
            var issues = _validator.Validate((Business)request.Item).Errors;

            foreach (var issue in issues)
                _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));
            return _errors;
        }

    }
}
