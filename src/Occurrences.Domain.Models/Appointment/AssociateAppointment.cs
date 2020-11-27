using GoodToCode.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class AssociateAppointment : DomainEntity<IAssociateAppointment>, IAssociateAppointment
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return AssociateAppointmentKey; } set { AssociateAppointmentKey = value; } }
        public Guid AssociateAppointmentKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
