using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Subjects.Specs
{
    public class DbContextFactory
    {
        public SubjectsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
                options.UseSqlServer(new ConnectionStringFactory("Subjects.Specs").Create());
            return new SubjectsDbContext(options.Options);
        }
    }
}
