using Goodtocode.Subjects.Domain;
using System.ComponentModel.DataAnnotations;

namespace Goodtocode.Subjects.BlazorServer.Models;

public class BusinessModel : IBusinessEntity
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public Guid BusinessKey { get; set; } = default;
    public string BusinessName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsDeleting { get; set; }
}
