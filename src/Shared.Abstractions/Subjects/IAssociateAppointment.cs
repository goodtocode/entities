using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IAssociateAppointment : IDomainModel<IAssociateAppointment>
    {
        Guid AppointmentKey { get; set; }        
        Guid AssociateAppointmentKey { get; set; }
        Guid AssociateKey { get; set; }
    }
}