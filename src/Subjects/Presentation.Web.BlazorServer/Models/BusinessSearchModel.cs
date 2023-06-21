using System.ComponentModel.DataAnnotations;

namespace Goodtocode.Subjects.BlazorServer.Models
{
    public class BusinessSearchModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
