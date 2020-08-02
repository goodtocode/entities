namespace GoodToCode.Subjects.Models
{
    public class EntityAppointmentEntity : EntityAppointment, IEntityAppointment
    {
        public virtual EntityEntity EntityKeyNavigation { get; set; }
        
    }
}
