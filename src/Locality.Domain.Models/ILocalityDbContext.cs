using GoodToCode.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Locality.Models
{
    public interface ILocalityDbContext : IDbContext
    {
        //DbSet<GeoArea> GeoArea { get; set; }
        //DbSet<GeoDistance> GeoDistance { get; set; }
        //DbSet<GeoLocation> GeoLocation { get; set; }
        //DbSet<LatLong> LatLong { get; set; }
        //DbSet<Line> Line { get; set; }
        //DbSet<Coordinate> Coordinate { get; set; }
        //DbSet<Polygon> Polygon { get; set; }
        DbSet<Location> Location { get; set; }
        DbSet<LocationArea> LocationArea { get; set; }        
        DbSet<LocationType> LocationType { get; set; }
        DbSet<AssociateLocation> AssociateLocation { get; set; }
        DbSet<ResourceLocation> ResourceLocation { get; set; }
        DbSet<VentureLocation> VentureLocation { get; set; }

    }
}