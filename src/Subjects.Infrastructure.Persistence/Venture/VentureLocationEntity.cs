namespace GoodToCode.Subjects.Models
{
    public class VentureLocationEntity : VentureLocation, IVentureLocation
    {
        
        public virtual VentureEntity VentureKeyNavigation { get; set; }
    }
}
