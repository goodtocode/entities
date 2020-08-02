namespace GoodToCode.Subjects.Models
{
    public class VentureAppointmentEntity : VentureAppointment, IVentureAppointment
    {
        public virtual RecordStateEntity RecordStateKeyNavigation { get; set; }
        public virtual VentureEntity VentureKeyNavigation { get; set; }
    }
}
