using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class ScheduleType : DomainModel<IScheduleType>, IScheduleType
    {
        [Key]
        public Guid ScheduleTypeKey { get; set; }
        public string ScheduleTypeName { get; set; }
        public string ScheduleTypeDescription { get; set; }
    }
}
