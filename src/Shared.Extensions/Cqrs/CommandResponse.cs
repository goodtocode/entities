using System.Collections.Generic;
using GoodToCode.Shared.Validation;
using MediatR;

namespace GoodToCode.Shared.Cqrs
{
    public class CommandResponse<T> : IRequest<Unit>
    {
        public CommandResponse()
        {
            Errors = new List<KeyValuePair<string, string>>(); 
            Warnings = new List<KeyValuePair<string, string>>();
        }

        public T Result { get; set; }

        public ICollection<KeyValuePair<string, string>> Errors { get; set; }

        public ICollection<KeyValuePair<string, string>> Warnings { get; set; }

        public ErrorInfo ErrorInfo { get; set; }
    }
}

