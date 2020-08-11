using System;

namespace GoodToCode.Subjects.Models
{
    public interface IAssociateAppointment
    {
        Guid AppointmentKey { get; set; }
        DateTime CreatedDate { get; set; }
        Guid AssociateAppointmentKey { get; set; }
        Guid AssociateKey { get; set; }
        DateTime ModifiedDate { get; set; }
        
    }
}