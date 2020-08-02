namespace GoodToCode.Subjects.Models
{
    public class VentureScheduleEntity : VentureSchedule, IVentureSchedule
    {
        
        public virtual VentureEntity VentureKeyNavigation { get; set; }
    }
}
