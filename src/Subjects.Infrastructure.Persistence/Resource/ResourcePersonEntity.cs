namespace GoodToCode.Subjects.Models
{
    public class ResourcePersonEntity : ResourcePerson, IResourcePerson
    {
        public virtual PersonEntity PersonKeyNavigation { get; set; }
        
        public virtual ResourceEntity ResourceKeyNavigation { get; set; }
    }
}
