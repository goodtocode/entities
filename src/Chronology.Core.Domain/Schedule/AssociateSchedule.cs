using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class AssociateSchedule : DomainEntity<IAssociateSchedule>, IAssociateSchedule
    {

        public override Guid RowKey { get { return ScheduleKey; } set { ScheduleKey = value; } }
        public override string PartitionKey { get; set; } = "Default";
        public Guid AssociateScheduleKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid ScheduleKey { get; set; }        
        public Guid? ScheduleTypeKey { get; set; }
        
        
    }
}
