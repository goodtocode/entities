namespace GoodToCode.Subjects.Models
{
    public interface IErrorViewModel
    {
        string RequestId { get; set; }
        bool ShowRequestId { get; }
    }
}