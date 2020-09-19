using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class AssociateAppointment : DomainModel<IAssociateAppointment>, IAssociateAppointment
    {
        public override Guid RowKey { get { return AssociateAppointmentKey; } set { AssociateAppointmentKey = value; } }
        public Guid AssociateAppointmentKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
