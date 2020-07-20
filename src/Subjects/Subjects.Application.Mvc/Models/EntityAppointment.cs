﻿using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class EntityAppointment
    {
        public int EntityAppointmentId { get; set; }
        public Guid EntityAppointmentKey { get; set; }
        public Guid EntityKey { get; set; }
        public Guid AppointmentKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Appointment AppointmentKeyNavigation { get; set; }
        public virtual Entity EntityKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
    }
}
