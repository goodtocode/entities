using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class Venture
    {
        public Venture()
        {
            VentureAppointment = new HashSet<VentureAppointment>();
            VentureDetail = new HashSet<VentureDetail>();
            VentureEntityOption = new HashSet<VentureEntityOption>();
            VentureLocation = new HashSet<VentureLocation>();
            VentureOption = new HashSet<VentureOption>();
            VentureResource = new HashSet<VentureResource>();
            VentureSchedule = new HashSet<VentureSchedule>();
        }

        public int VentureId { get; set; }
        public Guid VentureKey { get; set; }
        public Guid? VentureGroupKey { get; set; }
        public Guid? VentureTypeKey { get; set; }
        public string VentureName { get; set; }
        public string VentureDescription { get; set; }
        public string VentureSlogan { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual ICollection<VentureAppointment> VentureAppointment { get; set; }
        public virtual ICollection<VentureDetail> VentureDetail { get; set; }
        public virtual ICollection<VentureEntityOption> VentureEntityOption { get; set; }
        public virtual ICollection<VentureLocation> VentureLocation { get; set; }
        public virtual ICollection<VentureOption> VentureOption { get; set; }
        public virtual ICollection<VentureResource> VentureResource { get; set; }
        public virtual ICollection<VentureSchedule> VentureSchedule { get; set; }
    }
}
