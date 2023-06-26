using Goodtocode.Subjects.Domain;
using System.ComponentModel.DataAnnotations;

namespace Goodtocode.Subjects.BlazorServer.Models;

public class BusinessCreateModel : BusinessObject
{
    [Required]
    public string BusinessName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
}
