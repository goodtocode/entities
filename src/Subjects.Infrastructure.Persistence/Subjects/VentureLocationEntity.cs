namespace GoodToCode.Subjects.Models
{
    public class VentureLocationEntity : VentureLocation, IVentureLocation
    {
        public virtual RecordStateEntity RecordStateKeyNavigation { get; set; }
        public virtual VentureEntity VentureKeyNavigation { get; set; }
    }
}
