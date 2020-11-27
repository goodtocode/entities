using GoodToCode.Locality.Infrastructure;
using GoodToCode.Locality.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Locality.Specs
{
    public class DbContextFactory
    {
        private readonly string _connectionString;

        public DbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LocalityDbContext Create()
        {
            var options = new DbContextOptionsBuilder<LocalityDbContext>();
                options.UseSqlServer(_connectionString);
            return new LocalityDbContext(options.Options);
        }
    }
}
