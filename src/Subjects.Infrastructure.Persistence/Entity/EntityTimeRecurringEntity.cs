namespace GoodToCode.Subjects.Models
{
    public class EntityTimeRecurringEntity : EntityTimeRecurring, IEntityTimeRecurring
    {
        public virtual EntityEntity EntityKeyNavigation { get; set; }
        
    }
}
