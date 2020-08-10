using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class VentureSchedule : IVentureSchedule
    {
        [Key]
        public Guid VentureScheduleKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid? ScheduleTypeKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
