using GoodToCode.Shared.Models;
using GoodToCode.Subjects.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Models
{
    public class AssociateAggregate : DomainAggregate<AssociateAggregate>
    {
        private readonly ISubjectsDbContext _dbContext;
        private int _recordsAffected;

        public AssociateAggregate(int recordsAffected)
        {
            _recordsAffected = recordsAffected;
        }

        public AssociateAggregate(ISubjectsDbContext context)
        {
            _dbContext = context;
        }

        // Business
        public async Task<int> BusinessSaveAsync(IBusiness business)
        {
            // Record in local storage

            IDomainEvent<IBusiness> eventRaise;

            if (business.BusinessKey == Guid.Empty)
            {
                _dbContext.Entry((Business)business).State = EntityState.Modified;
                eventRaise = new BusinessUpdatedEvent(business);
            }
            else
            {
                _dbContext.Business.Add((Business)business);
                eventRaise = new BusinessCreatedEvent(business);
            }
            _recordsAffected = await _dbContext.SaveChangesAsync();            
            business.RaiseDomainEvent(eventRaise);

            return _recordsAffected;
        }
        public async Task<Business> BusinessDeleteAsync(IBusiness business)
        {
            // Record in local storage

            IDomainEvent<IBusiness> eventRaise;

            if (business.BusinessKey == Guid.Empty)
            {
                _dbContext.Entry((Business)business).State = EntityState.Deleted;
                eventRaise = new BusinessUpdatedEvent(business);
            }
            else
            {
                _dbContext.Business.Add((Business)business);
                eventRaise = new BusinessCreatedEvent(business);
            }
            _recordsAffected = await _dbContext.SaveChangesAsync();
            business.RaiseDomainEvent(eventRaise);

            return (Business)business;
        }

        // Person
        public async Task<int> PersonSaveAsync(IPerson person)
        {
            // Record locally
            // raise event with data to persistence

            if (person.PersonKey == Guid.Empty)
                _dbContext.Entry(person).State = EntityState.Modified;
            else
                _dbContext.Person.Add((Person)person);
            _recordsAffected = await _dbContext.SaveChangesAsync();

            return _recordsAffected;
        }

        // Government
        public async Task<int> GovernmentSaveAsync(IGovernment government)
        {
            // Record locally
            // raise event with data to persistence

            if (government.GovernmentKey == Guid.Empty)
                _dbContext.Entry(government).State = EntityState.Modified;
            else
                _dbContext.Government.Add((Government)government);
            _recordsAffected = await _dbContext.SaveChangesAsync();

            return _recordsAffected;
        }
    }
}
