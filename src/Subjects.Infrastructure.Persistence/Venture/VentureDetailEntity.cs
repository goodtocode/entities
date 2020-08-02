
namespace GoodToCode.Subjects.Models
{
    public class VentureDetailEntity : VentureDetail, IVentureDetail
    {
        public virtual DetailEntity DetailKeyNavigation { get; set; }
        public virtual VentureEntity VentureKeyNavigation { get; set; }
    }
}
