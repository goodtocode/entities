namespace GoodToCode.Subjects.Models
{
    public class VentureResourceEntity : VentureResource, IVentureResource
    {
        
        public virtual ResourceEntity ResourceKeyNavigation { get; set; }
        public virtual ResourceTypeEntity ResourceTypeKeyNavigation { get; set; }
        public virtual VentureEntity VentureKeyNavigation { get; set; }
    }
}
