namespace GoodToCode.Subjects.Models
{
    public class EntityLocationEntity : EntityLocation, IEntityLocation
    {
        public virtual EntityEntity EntityKeyNavigation { get; set; }
        
    }
}
