using Goodtocode.Subjects.Domain;
using System.ComponentModel.DataAnnotations;

namespace Goodtocode.Subjects.Models;

public class BusinessModel : IBusinessEntity
{    
    public Guid BusinessKey { get; set; } = default;
    [Required]
    public string BusinessName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsDeleting { get; set; }
}
