namespace GoodToCode.Subjects.Models
{
    public class VentureScheduleEntity : VentureSchedule, IVentureSchedule
    {
        public virtual RecordStateEntity RecordStateKeyNavigation { get; set; }
        public virtual VentureEntity VentureKeyNavigation { get; set; }
    }
}
