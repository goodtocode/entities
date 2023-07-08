namespace Goodtocode.Subjects.Rcl;

public class AlertModel
{
    public string Id { get; set; }
    public AlertTypes Type { get; set; }
    public string Message { get; set; }
    public bool AutoClose { get; set; }
    public bool KeepAfterRouteChange { get; set; }
    public bool Fade { get; set; }
}