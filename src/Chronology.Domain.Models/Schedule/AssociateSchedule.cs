using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class AssociateSchedule : DomainModel<IAssociateSchedule>, IAssociateSchedule
    {
        
        public Guid AssociateScheduleKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public override Guid RowKey { get { return ScheduleKey; } set { ScheduleKey = value; } }
        public Guid? ScheduleTypeKey { get; set; }
        
        
    }
}
