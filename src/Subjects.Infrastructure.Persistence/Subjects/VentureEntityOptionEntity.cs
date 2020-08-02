namespace GoodToCode.Subjects.Models
{
    public class VentureEntityOptionEntity : VentureEntityOption, IVentureEntityOption
    {
        public virtual EntityEntity EntityKeyNavigation { get; set; }
        public virtual OptionEntity OptionKeyNavigation { get; set; }
        public virtual VentureEntity VentureKeyNavigation { get; set; }
    }
}
