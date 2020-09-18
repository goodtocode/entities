using System.Collections.Generic;
using GoodToCode.Shared.Validation;
using MediatR;

namespace GoodToCode.Shared.Cqrs
{
    public class CommandResponse<T> : IRequest<Unit> where T : new()
    {
        public CommandResponse()
        {
        }

        public T Result { get; set; } = new T();

        public ICollection<KeyValuePair<string, string>> Errors { get; set; } = new List<KeyValuePair<string, string>>();

        public ICollection<KeyValuePair<string, string>> Warnings { get; set; } = new List<KeyValuePair<string, string>>();

        public ErrorInfo ErrorInfo { get; set; } = new ErrorInfo();
    }
}

