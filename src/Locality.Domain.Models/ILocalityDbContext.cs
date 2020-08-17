using GoodToCode.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Locality.Models
{
    public interface ILocalityDbContext : IDbContext
    {
        DbSet<Location> Location { get; set; }
        DbSet<LocationArea> LocationArea { get; set; }
        DbSet<LocationTimeRecurring> LocationTimeRecurring { get; set; }
        DbSet<LocationType> LocationType { get; set; }
        DbSet<AssociateLocation> AssociateLocation { get; set; }
        DbSet<ResourceLocation> ResourceLocation { get; set; }
        DbSet<VentureLocation> VentureLocation { get; set; }

    }
}