using GoodToCode.Subjects.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Aggregates
{
    public class EntityAggregate
    {

        public EntityAggregate(ISubjectsDbContext context, IConfiguration configuration)
        {
            
        }

        // Business
        public async Task<Business> BusinessSaveAsync(Business business)
        {
            // Record locally
            // raise event with data to persistence

            //var returnData = new Business();
            //string defaultConnection = Environment.GetEnvironmentVariable("DefaultConnection") ?? "Server=tcp:GoodToCode.database.windows.net,1433;Initial Catalog=EntityData;user id=TestUser; password=57595709-9E9C-47EA-ABBF-4F3BAA1B0D37;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Application Name=GoodToCodeEntities;";
            //var options = new DbContextOptionsBuilder<SubjectsDbContext>();
            //options.UseSqlServer(defaultConnection);
            //var context = new SubjectsDbContext(options.Options);
            //if (business.BusinessKey == Guid.Empty)
            //    context.Entry(business).State = EntityState.Modified;
            //else
            //    context.Add(business);
            //var recordsAffected = await context.SaveChangesAsync();

            return business;
        }

        // Person
        public async Task<Person> PersonSaveAsync(Person person)
        {
            // Record locally
            // raise event with data to persistence

            //var returnData = new Person();
            //string defaultConnection = Environment.GetEnvironmentVariable("DefaultConnection") ?? "Server=tcp:GoodToCode.database.windows.net,1433;Initial Catalog=EntityData;user id=TestUser; password=57595709-9E9C-47EA-ABBF-4F3BAA1B0D37;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Application Name=GoodToCodeEntities;";
            //var options = new DbContextOptionsBuilder<SubjectsDbContext>();
            //options.UseSqlServer(defaultConnection);
            //var context = new SubjectsDbContext(options.Options);
            //if (person.PersonKey == Guid.Empty)
            //    context.Entry(person).State = EntityState.Modified;
            //else
            //    context.Add(person);
            //var recordsAffected = await context.SaveChangesAsync();

            return person;
        }

        // Government
        public async Task<Government> GovernmentSaveAsync(Government government)
        {
            // Record locally
            // raise event with data to persistence

            //var returnData = new Government();
            //string defaultConnection = Environment.GetEnvironmentVariable("DefaultConnection") ?? "Server=tcp:GoodToCode.database.windows.net,1433;Initial Catalog=EntityData;user id=TestUser; password=57595709-9E9C-47EA-ABBF-4F3BAA1B0D37;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Application Name=GoodToCodeEntities;";
            //var options = new DbContextOptionsBuilder<SubjectsDbContext>();
            //options.UseSqlServer(defaultConnection);
            //var context = new SubjectsDbContext(options.Options);
            //if (government.GovernmentKey == Guid.Empty)
            //    context.Entry(government).State = EntityState.Modified;
            //else
            //    context.Add(government);
            //var recordsAffected = await context.SaveChangesAsync();

            return government;
        }
    }
}
