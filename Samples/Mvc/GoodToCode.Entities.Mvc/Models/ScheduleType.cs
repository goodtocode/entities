using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.Web.Models
{
    public partial class ScheduleType
    {
        public ScheduleType()
        {
            EventSchedule = new HashSet<EventSchedule>();
            VentureSchedule = new HashSet<VentureSchedule>();
        }

        public int ScheduleTypeId { get; set; }
        public Guid ScheduleTypeKey { get; set; }
        public string ScheduleTypeName { get; set; }
        public string ScheduleTypeDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<EventSchedule> EventSchedule { get; set; }
        public virtual ICollection<VentureSchedule> VentureSchedule { get; set; }
    }
}
