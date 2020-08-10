using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Aggregates
{
    public class EntityAggregate
    {
        private readonly ISubjectsDbContext _context;
        private readonly IConfiguration _configuration;
        private int _recordsAffected;

        public EntityAggregate(int recordsAffected)
        {
            _recordsAffected = recordsAffected;
        }

        public EntityAggregate(ISubjectsDbContext context)
        {
            _context = context;
        }

        public EntityAggregate(ISubjectsDbContext context, IConfiguration configuration) : this(context)
        {
            _configuration = configuration;
        }

        // Business
        public async Task<Business> BusinessSaveAsync(IBusiness business)
        {
            // Record locally
            // raise event with data to persistence

            if (business.BusinessKey == Guid.Empty)
                _context.Entry((Business)business).State = EntityState.Modified;
            else
                _context.Business.Add((Business)business);
            _recordsAffected = await _context.SaveChangesAsync();
            
            return (Business)business;
        }

        // Person
        public async Task<Person> PersonSaveAsync(IPerson person)
        {
            // Record locally
            // raise event with data to persistence

            if (person.PersonKey == Guid.Empty)
                _context.Entry(person).State = EntityState.Modified;
            else
                _context.Person.Add((Person)person);
            _recordsAffected = await _context.SaveChangesAsync();

            return (Person)person;
        }

        // Government
        public async Task<Government> GovernmentSaveAsync(IGovernment government)
        {
            // Record locally
            // raise event with data to persistence

            if (government.GovernmentKey == Guid.Empty)
                _context.Entry(government).State = EntityState.Modified;
            else
                _context.Government.Add((Government)government);
            _recordsAffected = await _context.SaveChangesAsync();

            return (Government)government;
        }
    }
}
