using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class AssociateTimeRecurring : DomainModel<IAssociateTimeRecurring>, IAssociateTimeRecurring
    {
        [Key]
        public Guid AssociateTimeRecurringKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public string DayName { get; set; }
        public string TimeName { get; set; }
        public Guid? TimeTypeKey { get; set; }
        
        
    }
}
