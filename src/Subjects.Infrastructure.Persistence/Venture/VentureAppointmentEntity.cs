namespace GoodToCode.Subjects.Models
{
    public class VentureAppointmentEntity : VentureAppointment, IVentureAppointment
    {
        
        public virtual VentureEntity VentureKeyNavigation { get; set; }
    }
}
