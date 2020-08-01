using System;

namespace GoodToCode.Shared.Models
{
    [Serializable]
    public class ErrorInfo
    {
        public ErrorInfo() { }

        public bool HasException = false;

        public string UserErrorMessage { get; set; } = string.Empty;
    }
}
