
using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class RecordStateEntity : IRecordState
    {
        public RecordStateEntity()
        {
            Business = new HashSet<BusinessEntity>();
            EntityAppointment = new HashSet<EntityAppointmentEntity>();
            EntityLocation = new HashSet<EntityLocationEntity>();
            EntityTimeRecurring = new HashSet<EntityTimeRecurringEntity>();
            Government = new HashSet<GovernmentEntity>();
            Item = new HashSet<ItemEntity>();
            Person = new HashSet<PersonEntity>();
            Resource = new HashSet<ResourceEntity>();
            ResourceItem = new HashSet<ResourceItemEntity>();
            ResourcePerson = new HashSet<ResourcePersonEntity>();
            ResourceTimeRecurring = new HashSet<ResourceTimeRecurringEntity>();
            Venture = new HashSet<VentureEntity>();
            VentureAppointment = new HashSet<VentureAppointmentEntity>();
            VentureLocation = new HashSet<VentureLocationEntity>();
            VentureResource = new HashSet<VentureResourceEntity>();
            VentureSchedule = new HashSet<VentureScheduleEntity>();
        }

        public int RecordStateId { get; set; }
        public Guid RecordStateKey { get; set; }
        public string RecordStateName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BusinessEntity> Business { get; set; }
        public virtual ICollection<EntityAppointmentEntity> EntityAppointment { get; set; }
        public virtual ICollection<EntityLocationEntity> EntityLocation { get; set; }
        public virtual ICollection<EntityTimeRecurringEntity> EntityTimeRecurring { get; set; }
        public virtual ICollection<GovernmentEntity> Government { get; set; }
        public virtual ICollection<ItemEntity> Item { get; set; }
        public virtual ICollection<PersonEntity> Person { get; set; }
        public virtual ICollection<ResourceEntity> Resource { get; set; }
        public virtual ICollection<ResourceItemEntity> ResourceItem { get; set; }
        public virtual ICollection<ResourcePersonEntity> ResourcePerson { get; set; }
        public virtual ICollection<ResourceTimeRecurringEntity> ResourceTimeRecurring { get; set; }
        public virtual ICollection<VentureEntity> Venture { get; set; }
        public virtual ICollection<VentureAppointmentEntity> VentureAppointment { get; set; }
        public virtual ICollection<VentureLocationEntity> VentureLocation { get; set; }
        public virtual ICollection<VentureResourceEntity> VentureResource { get; set; }
        public virtual ICollection<VentureScheduleEntity> VentureSchedule { get; set; }
    }
}
