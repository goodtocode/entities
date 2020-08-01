
using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class RecordState : IRecordState
    {
        public RecordState()
        {
            Business = new HashSet<Business>();
            EntityAppointment = new HashSet<EntityAppointment>();
            EntityLocation = new HashSet<EntityLocation>();
            EntityTimeRecurring = new HashSet<EntityTimeRecurring>();
            Government = new HashSet<Government>();
            Item = new HashSet<Item>();
            Person = new HashSet<Person>();
            Resource = new HashSet<Resource>();
            ResourceItem = new HashSet<ResourceItem>();
            ResourcePerson = new HashSet<ResourcePerson>();
            ResourceTimeRecurring = new HashSet<ResourceTimeRecurring>();
            Venture = new HashSet<Venture>();
            VentureAppointment = new HashSet<VentureAppointment>();
            VentureLocation = new HashSet<VentureLocation>();
            VentureResource = new HashSet<VentureResource>();
            VentureSchedule = new HashSet<VentureSchedule>();
        }

        public int RecordStateId { get; set; }
        public Guid RecordStateKey { get; set; }
        public string RecordStateName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Business> Business { get; set; }
        public virtual ICollection<EntityAppointment> EntityAppointment { get; set; }
        public virtual ICollection<EntityLocation> EntityLocation { get; set; }
        public virtual ICollection<EntityTimeRecurring> EntityTimeRecurring { get; set; }
        public virtual ICollection<Government> Government { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<Resource> Resource { get; set; }
        public virtual ICollection<ResourceItem> ResourceItem { get; set; }
        public virtual ICollection<ResourcePerson> ResourcePerson { get; set; }
        public virtual ICollection<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        public virtual ICollection<Venture> Venture { get; set; }
        public virtual ICollection<VentureAppointment> VentureAppointment { get; set; }
        public virtual ICollection<VentureLocation> VentureLocation { get; set; }
        public virtual ICollection<VentureResource> VentureResource { get; set; }
        public virtual ICollection<VentureSchedule> VentureSchedule { get; set; }
    }
}
