using GoodToCode.Occurrences.Models;
using GoodToCode.Shared.Cqrs;
using GoodToCode.Shared.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoodToCode.Occurrences.Application
{
    public class EventSaveCommand : IRequest<CommandResponse<Event>>
    {
        public IEvent Item { get; set; }

        public EventSaveCommand() { }

        public EventSaveCommand(IEvent item)
        {
            Item = item;
        }
    }

    public class EventSaveHandler : IRequestHandler<EventSaveCommand, CommandResponse<Event>>
    {
        private readonly EventSaveValidator _validator;
        private readonly List<KeyValuePair<string, string>> _errors;
        private readonly IOccurrencesDbContext _dbContext;

        public EventSaveHandler(IOccurrencesDbContext context)
        {
            _dbContext = context;
            _validator = new EventSaveValidator();
            _errors = new List<KeyValuePair<string, string>>();
        }

        public async Task<CommandResponse<Event>> Handle(EventSaveCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResponse<Event>() { Errors = GetRequestErrors(request) };

            if (result.Errors.Count == 0)
            {
                try
                {
                    var aggregate = new EventAggregate(_dbContext);
                    await aggregate.EventSaveAsync(request.Item);
                    result.Result = (Event)request.Item;
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

        private List<KeyValuePair<string, string>> GetRequestErrors(EventSaveCommand request)
        {
            var issues = _validator.Validate((Event)request.Item).Errors;

            foreach (var issue in issues)
                _errors.Add(new KeyValuePair<string, string>(issue.PropertyName, issue.ErrorMessage));
            return _errors;
        }

    }
}
