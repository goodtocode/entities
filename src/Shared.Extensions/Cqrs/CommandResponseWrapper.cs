using System.Collections.Generic;
using GoodToCode.Shared.Validation;
using MediatR;

namespace GoodToCode.Shared.Cqrs
{
    public class CommandResponseWrapper<T> : IRequest<Unit>
    {
        public CommandResponseWrapper()
        {
            Errors = new List<KeyValuePair<string, string>>(); 
            Warnings = new List<KeyValuePair<string, string>>();
            ErrorInfo = new ErrorInfo();
        }

        public T Result { get; set; }

        public ICollection<KeyValuePair<string, string>> Errors { get; set; }

        public ICollection<KeyValuePair<string, string>> Warnings { get; set; }

        public ErrorInfo ErrorInfo { get; set; }
    }
}

