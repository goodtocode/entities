using GoodToCode.Occurrences.Infrastructure;
using GoodToCode.Occurrences.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Occurrences.Specs
{
    public class DbContextFactory
    {
        private readonly string _connectionString;

        public DbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public OccurrencesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<OccurrencesDbContext>();
                options.UseSqlServer(_connectionString);
            return new OccurrencesDbContext(options.Options);
        }
    }
}
