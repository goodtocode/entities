using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Cqrs;
using GoodToCode.Shared.Validation;
using GoodToCode.Subjects.Aggregates;
using GoodToCode.Subjects.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoodToCode.Chronology.Application
{
    public class ScheduleDeleteCommand : IRequest<CommandResponseWrapper<bool>>
    {
        public ISchedule Item { get; set; }

        public ScheduleDeleteCommand() { }

        public ScheduleDeleteCommand(ISchedule item)
        {
            Item = item;
        }

        public class Handler : IRequestHandler<ScheduleDeleteCommand, CommandResponseWrapper<bool>>
        {
            private readonly ScheduleDeleteValidator _validator;
            private readonly List<KeyValuePair<string, string>> _errors;
            private readonly IChronologyDbContext _dbContext;

            public Handler(IChronologyDbContext context)
            {
                _dbContext = context;
                _validator = new ScheduleDeleteValidator();
                _errors = new List<KeyValuePair<string, string>>();
            }

            public async Task<CommandResponseWrapper<bool>> Handle(ScheduleDeleteCommand request, CancellationToken cancellationToken)
            {
                var result = new CommandResponseWrapper<bool>() { Errors = GetRequestErrors(request) };

                if (result.Errors.Count == 0)
                {
                    try
                    {
                        var aggregate = new ScheduleAggregate(_dbContext);
                        await aggregate.ScheduleDeleteAsync(request.Item);
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

            private List<KeyValuePair<string, string>> GetRequestErrors(ScheduleDeleteCommand request)
            {
                var issues = _validator.Validate((Schedule)request.Item).Errors;

                foreach (var issue in issues)
                    _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));
                return _errors;
            }

        }
    }
}
