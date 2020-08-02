namespace GoodToCode.Subjects.Models
{
    public class VentureOptionEntity : VentureOption, IVentureOption
    {
        public virtual OptionEntity OptionKeyNavigation { get; set; }
        public virtual VentureEntity VentureKeyNavigation { get; set; }
    }
}
