using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Domain;

namespace GoodToCode.Chronology.Domain
{
    public sealed class ScheduleDeletedEvent : IDomainEvent<ISchedule>
    {
        public ISchedule Item { get; }

        public ScheduleDeletedEvent(ISchedule item)
        {
            Item = item;
        }
    }
}
