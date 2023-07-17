using Goodtocode.Subjects.Domain;
using System.ComponentModel.DataAnnotations;

namespace Goodtocode.Subjects.Models;

public class SearchModel
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
