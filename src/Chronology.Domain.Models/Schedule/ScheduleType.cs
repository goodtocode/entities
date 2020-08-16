using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public class ScheduleType : DomainModel<IScheduleType>, IScheduleType
    {
        public Guid ScheduleTypeKey { get; set; }
        public string ScheduleTypeName { get; set; }
        public string ScheduleTypeDescription { get; set; }
    }
}
