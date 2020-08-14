using GoodToCode.Shared.Domain;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Aggregates
{
    public class AssociateAggregate : DomainAggregate<AssociateAggregate>
    {
        private readonly ISubjectsDbContext _context;
        private readonly IConfiguration _configuration;
        private int _recordsAffected;

        public AssociateAggregate(int recordsAffected)
        {
            _recordsAffected = recordsAffected;
        }

        public AssociateAggregate(ISubjectsDbContext context)
        {
            _context = context;
        }

        public AssociateAggregate(ISubjectsDbContext context, IConfiguration configuration) : this(context)
        {
            _configuration = configuration;
        }

        // Business
        public async Task<int> BusinessSaveAsync(IBusiness business)
        {
            // Record in local storage

            IDomainEvent<IBusiness> eventRaise;

            if (business.BusinessKey == Guid.Empty)
            {
                _context.Entry((Business)business).State = EntityState.Modified;
                eventRaise = new BusinessUpdatedEvent(business);
            }
            else
            {
                _context.Business.Add((Business)business);
                eventRaise = new BusinessCreatedEvent(business);
            }
            _recordsAffected = await _context.SaveChangesAsync();            
            business.RaiseDomainEvent(eventRaise);

            return _recordsAffected;
        }
        public async Task<Business> BusinessDeleteAsync(IBusiness business)
        {
            // Record in local storage

            IDomainEvent<IBusiness> eventRaise;

            if (business.BusinessKey == Guid.Empty)
            {
                _context.Entry((Business)business).State = EntityState.Deleted;
                eventRaise = new BusinessUpdatedEvent(business);
            }
            else
            {
                _context.Business.Add((Business)business);
                eventRaise = new BusinessCreatedEvent(business);
            }
            _recordsAffected = await _context.SaveChangesAsync();
            business.RaiseDomainEvent(eventRaise);

            return (Business)business;
        }

        // Person
        public async Task<int> PersonSaveAsync(IPerson person)
        {
            // Record locally
            // raise event with data to persistence

            if (person.PersonKey == Guid.Empty)
                _context.Entry(person).State = EntityState.Modified;
            else
                _context.Person.Add((Person)person);
            _recordsAffected = await _context.SaveChangesAsync();

            return _recordsAffected;
        }

        // Government
        public async Task<int> GovernmentSaveAsync(IGovernment government)
        {
            // Record locally
            // raise event with data to persistence

            if (government.GovernmentKey == Guid.Empty)
                _context.Entry(government).State = EntityState.Modified;
            else
                _context.Government.Add((Government)government);
            _recordsAffected = await _context.SaveChangesAsync();

            return _recordsAffected;
        }
    }
}
