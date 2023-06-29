namespace Goodtocode.Common.Extensions;

public class PagedResult<T> : PagedResultBase where T : class
{
    public IList<T> Results { get; set; }

    public PagedResult()
    {
        Results = new List<T>();
    }

    public PagedResult(List<T> list)
    {
        Results = list;
    }
}