using GoodToCode.Shared.Models;
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
            private ISubjectsDbContext _context;
            private IConfiguration _configuration;

            public Handler(ISubjectsDbContext context, IConfiguration configuration)
            {
                _configuration = configuration;
                _context = context;
                _validator = new BusinessSaveCommandValidator();
                _errors = new List<KeyValuePair<string, string>>();
            }

            public async Task<CommandResponseWrapper<bool>> Handle(BusinessSaveCommand request, CancellationToken cancellationToken)
            {
                var result = new CommandResponseWrapper<bool>() { Errors = getRequestParamErrors(request) };
                int rowsAffected;

                if (result.Errors.Count == 0)
                {
                    try
                    {
                        var aggregate = new EntityAggregate(_context, _configuration);

                        if (request.Item.BusinessId > 0) // Update
                        {
                            request.Item.BusinessKey = request.Item.BusinessKey == Guid.Empty ? new Guid() : request.Item.BusinessKey;
                            _context.Entry(request.Item).State = EntityState.Modified;
                        }

                        rowsAffected = await _context.SaveChangesAsync(cancellationToken);

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

            private List<KeyValuePair<string, string>> getRequestParamErrors(BusinessSaveCommand request)
            {
                //var issues = _validator.Validate(request).Errors;

                //if (request.QuestionsCorrect > request.QuestionsCount)
                //    _errors.Add(new KeyValuePair<string, string>("QuestionsCorrect", "Questions Correct Cannot be greater than Questions Count"));


                //if (request.Status != "Pass" && request.Status != "Fail")
                //    _errors.Add(new KeyValuePair<string, string>("Status", "Invalid Status"));

                //if (request.Vendor != "testrun")
                //    _errors.Add(new KeyValuePair<string, string>("Vendor", "Invalid Vendor"));

                //if (request.ExamType != "microcredential")
                //    _errors.Add(new KeyValuePair<string, string>("ExamType", "Invalid ExamType"));

                //foreach (var issue in issues)
                //    _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));
                return _errors;
            }

        }
    }
}
