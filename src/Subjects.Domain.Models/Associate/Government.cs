using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Government : DomainModel<IGovernment>, IGovernment
    {
        public override Guid RowKey { get { return GovernmentKey; } set { GovernmentKey = value; } }
        public Guid GovernmentKey { get; set; }
        public string GovernmentName { get; set; }
        
        
    }
}
