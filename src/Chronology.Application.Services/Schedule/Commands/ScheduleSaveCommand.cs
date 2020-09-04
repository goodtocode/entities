using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Cqrs;
using GoodToCode.Shared.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoodToCode.Chronology.Application
{
    public class ScheduleSaveCommand : IRequest<CommandResponse<Schedule>>
    {
        public ISchedule Item { get; set; }

        public ScheduleSaveCommand() { }

        public ScheduleSaveCommand(ISchedule item)
        {
            Item = item;
        }
    }

    public class ScheduleSaveHandler : IRequestHandler<ScheduleSaveCommand, CommandResponse<Schedule>>
    {
        private readonly ScheduleSaveValidator _validator;
        private readonly List<KeyValuePair<string, string>> _errors;
        private readonly IChronologyDbContext _dbContext;

        public ScheduleSaveHandler(IChronologyDbContext context)
        {
            _dbContext = context;
            _validator = new ScheduleSaveValidator();
            _errors = new List<KeyValuePair<string, string>>();
        }

        public async Task<CommandResponse<Schedule>> Handle(ScheduleSaveCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResponse<Schedule>() { Errors = GetRequestErrors(request) };

            if (result.Errors.Count == 0)
            {
                try
                {
                    var aggregate = new ScheduleAggregate(_dbContext);
                    await aggregate.ScheduleSaveAsync(request.Item);
                    result.Result = (Schedule)request.Item;
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

        private List<KeyValuePair<string, string>> GetRequestErrors(ScheduleSaveCommand request)
        {
            var issues = _validator.Validate((Schedule)request.Item).Errors;

            foreach (var issue in issues)
                _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));
            return _errors;
        }

    }
}
