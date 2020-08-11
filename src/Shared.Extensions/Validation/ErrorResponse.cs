using System.Collections.Generic;

namespace GoodToCode.Shared.Validation
{
    public class ErrorsResponse
    {
        public string ErrorMessage { get; set; } = "Some Error Occured";
        public string ErrorCode { get; set; } = string.Empty;
        public Dictionary<string, string[]> Failures { get; set; }
    }
}
