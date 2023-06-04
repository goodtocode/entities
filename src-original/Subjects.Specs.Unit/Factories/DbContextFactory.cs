using GoodToCode.Subjects.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Subjects.Specs
{
    public class DbContextFactory
    {
        private readonly string _connectionString;

        public DbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SubjectsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
                options.UseSqlServer(_connectionString);
            return new SubjectsDbContext(options.Options);
        }
    }
}
