using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Aggregates
{
    public class EntityAggregate
    {
        private ISubjectsDbContext _context;
        private IConfiguration _configuration;
        private int _recordsAffected;

        public EntityAggregate(ISubjectsDbContext context)
        {
            _context = context;
        }

        public EntityAggregate(ISubjectsDbContext context, IConfiguration configuration) : this(context)
        {
            _configuration = configuration;
        }

        // Business
        public async Task<Business> BusinessSaveAsync(Business business)
        {
            // Record locally
            // raise event with data to persistence

            if (business.BusinessKey == Guid.Empty)
                _context.Entry(business).State = EntityState.Modified;
            else
                _context.Business.Add(business);
            _recordsAffected = await _context.SaveChangesAsync();
            

            return business;
        }

        // Person
        public async Task<Person> PersonSaveAsync(Person person)
        {
            // Record locally
            // raise event with data to persistence

            if (person.PersonKey == Guid.Empty)
                _context.Entry(person).State = EntityState.Modified;
            else
                _context.Person.Add(person);
            _recordsAffected = await _context.SaveChangesAsync();

            return person;
        }

        // Government
        public async Task<Government> GovernmentSaveAsync(Government government)
        {
            // Record locally
            // raise event with data to persistence

            var returnData = new Government();
            if (government.GovernmentKey == Guid.Empty)
                _context.Entry(government).State = EntityState.Modified;
            else
                _context.Government.Add(government);
            _recordsAffected = await _context.SaveChangesAsync();

            return government;
        }
    }
}
