using GoodToCode.Chronology.Infrastructure;
using GoodToCode.Chronology.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Chronology.Specs
{
    public class DbContextFactory
    {
        private readonly string _connectionString;

        public DbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ChronologyDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ChronologyDbContext>();
                options.UseSqlServer(_connectionString);
            return new ChronologyDbContext(options.Options);
        }
    }
}
