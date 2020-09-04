using GoodToCode.Chronology.Domain;
using GoodToCode.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Chronology.Models
{
    public class ScheduleAggregate : DomainAggregate<ScheduleAggregate>
    {
        private readonly IChronologyDbContext _dbContext;
        private int _recordsAffected;

        public ScheduleAggregate(int recordsAffected)
        {
            _recordsAffected = recordsAffected;
        }

        public ScheduleAggregate(IChronologyDbContext context)
        {
            _dbContext = context;
        }

        // Schedule
        public async Task<int> ScheduleSaveAsync(ISchedule schedule)
        {
            // Record in local storage

            IDomainEvent<ISchedule> eventRaise;

            if (schedule.ScheduleKey != Guid.Empty)
            {
                _dbContext.Entry((Schedule)schedule).State = EntityState.Modified;
                eventRaise = new ScheduleUpdatedEvent(schedule);
            }
            else
            {
                _dbContext.Schedule.Add((Schedule)schedule);
                eventRaise = new ScheduleCreatedEvent(schedule);
            }
            _recordsAffected = await _dbContext.SaveChangesAsync();            
            schedule.RaiseDomainEvent(eventRaise);

            return _recordsAffected;
        }
        public async Task<Schedule> ScheduleDeleteAsync(ISchedule schedule)
        {
            // Record in local storage

            IDomainEvent<ISchedule> eventRaise;

            if (schedule.ScheduleKey != Guid.Empty)
            {
                _dbContext.Entry((Schedule)schedule).State = EntityState.Deleted;
                eventRaise = new ScheduleUpdatedEvent(schedule);
            }
            else
            {
                _dbContext.Schedule.Add((Schedule)schedule);
                eventRaise = new ScheduleCreatedEvent(schedule);
            }
            _recordsAffected = await _dbContext.SaveChangesAsync();
            schedule.RaiseDomainEvent(eventRaise);

            return (Schedule)schedule;
        }
    }
}
