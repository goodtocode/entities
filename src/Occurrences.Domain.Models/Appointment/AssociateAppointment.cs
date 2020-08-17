using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;

namespace GoodToCode.Occurrences.Models
{
    public class AssociateAppointment : DomainModel<IAssociateAppointment>, IAssociateAppointment
    {
        public Guid AppointmentAssociateKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
