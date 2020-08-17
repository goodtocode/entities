using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IAssociateAppointment : IDomainModel<IAssociateAppointment>
    {
        Guid AppointmentKey { get; set; }        
        Guid AssociateAppointmentKey { get; set; }
        Guid AssociateKey { get; set; }
    }
}