using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Government : DomainModel<IGovernment>, IGovernment
    {
        [Key]
        public Guid GovernmentKey { get; set; }
        public string GovernmentName { get; set; }
        
        
    }
}
