using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IAssociateAppointment : IDomainEntity<IAssociateAppointment>
    {
        Guid AppointmentKey { get; set; }        
        Guid AssociateAppointmentKey { get; set; }
        Guid AssociateKey { get; set; }
    }
}