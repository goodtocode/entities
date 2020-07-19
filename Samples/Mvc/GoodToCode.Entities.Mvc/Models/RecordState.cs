using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.Web.Models
{
    public partial class RecordState
    {
        public RecordState()
        {
            Appointment = new HashSet<Appointment>();
            Business = new HashSet<Business>();
            EntityAppointment = new HashSet<EntityAppointment>();
            EntityLocation = new HashSet<EntityLocation>();
            EntityTimeRecurring = new HashSet<EntityTimeRecurring>();
            Event = new HashSet<Event>();
            EventAppointment = new HashSet<EventAppointment>();
            EventLocation = new HashSet<EventLocation>();
            EventResource = new HashSet<EventResource>();
            EventSchedule = new HashSet<EventSchedule>();
            Government = new HashSet<Government>();
            Item = new HashSet<Item>();
            Location = new HashSet<Location>();
            LocationTimeRecurring = new HashSet<LocationTimeRecurring>();
            Person = new HashSet<Person>();
            Resource = new HashSet<Resource>();
            ResourceItem = new HashSet<ResourceItem>();
            ResourcePerson = new HashSet<ResourcePerson>();
            ResourceTimeRecurring = new HashSet<ResourceTimeRecurring>();
            Schedule = new HashSet<Schedule>();
            Slot = new HashSet<Slot>();
            SlotLocation = new HashSet<SlotLocation>();
            SlotResource = new HashSet<SlotResource>();
            SlotTimeRange = new HashSet<SlotTimeRange>();
            SlotTimeRecurring = new HashSet<SlotTimeRecurring>();
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

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Business> Business { get; set; }
        public virtual ICollection<EntityAppointment> EntityAppointment { get; set; }
        public virtual ICollection<EntityLocation> EntityLocation { get; set; }
        public virtual ICollection<EntityTimeRecurring> EntityTimeRecurring { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<EventAppointment> EventAppointment { get; set; }
        public virtual ICollection<EventLocation> EventLocation { get; set; }
        public virtual ICollection<EventResource> EventResource { get; set; }
        public virtual ICollection<EventSchedule> EventSchedule { get; set; }
        public virtual ICollection<Government> Government { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<LocationTimeRecurring> LocationTimeRecurring { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<Resource> Resource { get; set; }
        public virtual ICollection<ResourceItem> ResourceItem { get; set; }
        public virtual ICollection<ResourcePerson> ResourcePerson { get; set; }
        public virtual ICollection<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
        public virtual ICollection<Slot> Slot { get; set; }
        public virtual ICollection<SlotLocation> SlotLocation { get; set; }
        public virtual ICollection<SlotResource> SlotResource { get; set; }
        public virtual ICollection<SlotTimeRange> SlotTimeRange { get; set; }
        public virtual ICollection<SlotTimeRecurring> SlotTimeRecurring { get; set; }
        public virtual ICollection<Venture> Venture { get; set; }
        public virtual ICollection<VentureAppointment> VentureAppointment { get; set; }
        public virtual ICollection<VentureLocation> VentureLocation { get; set; }
        public virtual ICollection<VentureResource> VentureResource { get; set; }
        public virtual ICollection<VentureSchedule> VentureSchedule { get; set; }
    }
}
