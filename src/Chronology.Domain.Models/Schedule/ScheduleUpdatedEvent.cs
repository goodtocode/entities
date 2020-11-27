using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Domain;

namespace GoodToCode.Chronology.Domain
{
    public sealed class ScheduleUpdatedEvent : IDomainEvent<ISchedule>
    {
        public ISchedule Item { get; }

        public ScheduleUpdatedEvent(ISchedule item)
        {
            Item = item;
        }
    }
}
