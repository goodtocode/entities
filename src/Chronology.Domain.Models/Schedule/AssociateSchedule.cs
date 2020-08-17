using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class AssociateSchedule : DomainModel<IAssociateSchedule>, IAssociateSchedule
    {
        [Key]
        public Guid AssociateScheduleKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid? ScheduleTypeKey { get; set; }
        
        
    }
}
