namespace GoodToCode.Subjects.Models
{
    public interface IMigrationHistory
    {
        string ContextKey { get; set; }
        string MigrationId { get; set; }
        byte[] Model { get; set; }
        string ProductVersion { get; set; }
    }
}