using GoodToCode.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Occurrences.Models
{
    public interface IOccurrencesDbContext : IDbContext
    {
        DbSet<Appointment> Appointment { get; set; }
        DbSet<EntityAppointment> EntityAppointment { get; set; }
        DbSet<Event> Event { get; set; }
        DbSet<EventAppointment> EventAppointment { get; set; }
        DbSet<EventDetail> EventDetail { get; set; }
        DbSet<EventEntityOption> EventEntityOption { get; set; }
        DbSet<EventGroup> EventGroup { get; set; }
        DbSet<EventLocation> EventLocation { get; set; }
        DbSet<EventOption> EventOption { get; set; }
        DbSet<EventResource> EventResource { get; set; }
        DbSet<EventSchedule> EventSchedule { get; set; }
        DbSet<EventType> EventType { get; set; }
        DbSet<VentureAppointment> VentureAppointment { get; set; }
    }
}