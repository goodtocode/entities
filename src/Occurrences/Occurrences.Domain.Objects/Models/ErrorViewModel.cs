using System;

namespace GoodToCode.Subjects.Models
{
    public class ErrorViewModel : IErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
