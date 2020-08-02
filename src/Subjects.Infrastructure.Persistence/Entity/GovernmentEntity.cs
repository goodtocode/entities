namespace GoodToCode.Subjects.Models
{
    public class GovernmentEntity : Government, IGovernment
    {
        public virtual EntityEntity GovernmentKeyNavigation { get; set; }
        
    }
}
