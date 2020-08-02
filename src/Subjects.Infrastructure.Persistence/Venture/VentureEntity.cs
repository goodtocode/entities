using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class VentureEntity : Venture, IVenture
    {
        public VentureEntity() : base()
        {
            VentureAppointment = new HashSet<VentureAppointmentEntity>();
            VentureDetail = new HashSet<VentureDetailEntity>();
            VentureEntityOption = new HashSet<VentureEntityOptionEntity>();
            VentureLocation = new HashSet<VentureLocationEntity>();
            VentureOption = new HashSet<VentureOptionEntity>();
            VentureResource = new HashSet<VentureResourceEntity>();
            VentureSchedule = new HashSet<VentureScheduleEntity>();
        }

        
        public virtual ICollection<VentureAppointmentEntity> VentureAppointment { get; set; }
        public virtual ICollection<VentureDetailEntity> VentureDetail { get; set; }
        public virtual ICollection<VentureEntityOptionEntity> VentureEntityOption { get; set; }
        public virtual ICollection<VentureLocationEntity> VentureLocation { get; set; }
        public virtual ICollection<VentureOptionEntity> VentureOption { get; set; }
        public virtual ICollection<VentureResourceEntity> VentureResource { get; set; }
        public virtual ICollection<VentureScheduleEntity> VentureSchedule { get; set; }
    }
}
