namespace GoodToCode.Subjects.Models
{
    public class EntityDetailEntity : EntityDetail, IEntityDetail
    {
        public virtual DetailEntity DetailKeyNavigation { get; set; }
        public virtual EntityEntity EntityKeyNavigation { get; set; }
    }
}
