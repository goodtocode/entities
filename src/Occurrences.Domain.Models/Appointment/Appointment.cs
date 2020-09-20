using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class Appointment : DomainModel<IAppointment>, IAppointment
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return AppointmentKey; } set { AppointmentKey = value; } }
        public Guid AppointmentKey { get; set; }
        public string AppointmentName { get; set; }
        public string AppointmentDescription { get; set; }
        public Guid? SlotLocationKey { get; set; }
        public Guid? SlotResourceKey { get; set; }
        public Guid TimeRangeKey { get; set; }
    }
}
