using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Domain;

namespace GoodToCode.Chronology.Domain
{
    public sealed class ScheduleCreatedEvent : IDomainEvent<ISchedule>
    {
        public ISchedule Item { get; }

        public ScheduleCreatedEvent(ISchedule item)
        {
            Item = item;
        }
    }
}
