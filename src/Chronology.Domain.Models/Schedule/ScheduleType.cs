using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class ScheduleType : DomainModel<IScheduleType>, IScheduleType
    {
        
        public Guid ScheduleTypeKey { get; set; }
        public override Guid RowKey { get { return ScheduleTypeKey; } protected set { ScheduleTypeKey = value; } }
        public string ScheduleTypeName { get; set; }
        public string ScheduleTypeDescription { get; set; }
    }
}
