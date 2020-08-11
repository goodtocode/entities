using System;
using System.Collections.Generic;
using GoodToCode.Shared.Validation;
using MediatR;

namespace GoodToCode.Shared.Cqrs
{
    [Serializable]
    public class QueryResponseWrapper<T> : IRequest<T>
    {
        public QueryResponseWrapper()
        {
            Errors = new List<KeyValuePair<string, string>>();
            ErrorInfo = new ErrorInfo();
        }

        public T Result { get; set; }

        public ErrorInfo ErrorInfo { get; set; }

        public ICollection<KeyValuePair<string, string>> Errors { get; set; } = new List<KeyValuePair<string, string>>();

    }
}
