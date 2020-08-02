namespace GoodToCode.Subjects.Models
{
    public class EntityOptionEntity : EntityOption, IEntityOption
    {
        public virtual OptionEntity OptionKeyNavigation { get; set; }
    }
}
