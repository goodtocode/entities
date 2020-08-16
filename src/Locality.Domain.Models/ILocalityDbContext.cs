using GoodToCode.Locality.Domain.Models;
using GoodToCode.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Locality.Models
{
    public interface ILocalityDbContext : IDbContext
    {
        DbSet<Location> Location { get; set; }
        DbSet<LocationArea> LocationArea { get; set; }
        DbSet<LocationTimeRecurring> LocationTimeRecurring { get; set; }
        DbSet<LocationType> LocationType { get; set; }
    }
}