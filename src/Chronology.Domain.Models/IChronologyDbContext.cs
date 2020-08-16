using GoodToCode.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Chronology.Models
{
    public interface IChronologyDbContext : IDbContext
    {
        DbSet<Schedule> Schedule { get; set; }
        DbSet<ScheduleSlot> ScheduleSlot { get; set; }
        DbSet<ScheduleType> ScheduleType { get; set; }
        DbSet<Slot> Slot { get; set; }
        DbSet<SlotLocation> SlotLocation { get; set; }
        DbSet<SlotResource> SlotResource { get; set; }
        DbSet<SlotTimeRange> SlotTimeRange { get; set; }
        DbSet<SlotTimeRecurring> SlotTimeRecurring { get; set; }
        DbSet<TimeCycle> TimeCycle { get; set; }
        DbSet<TimeRange> TimeRange { get; set; }
        DbSet<TimeRecurring> TimeRecurring { get; set; }
        DbSet<TimeType> TimeType { get; set; }
    }
}