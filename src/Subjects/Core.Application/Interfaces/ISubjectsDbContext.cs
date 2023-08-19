using Goodtocode.Subjects.Domain;
using Microsoft.EntityFrameworkCore;

namespace Goodtocode.Subjects.Application;

public interface ISubjectsDbContext
{
    DbSet<BusinessEntity> Business { get; }
    //DbSet<Detail> Detail { get; }
    //DbSet<DetailType> DetailType { get; }
    //DbSet<Associate> Associate { get; }
    //DbSet<AssociateDetail> AssociateDetail { get; }
    //DbSet<AssociateOption> AssociateOption { get; }
    //DbSet<Gender> Gender { get; }
    //DbSet<Government> Government { get; }
    //DbSet<Item> Item { get; }
    //DbSet<ItemGroup> ItemGroup { get; }
    //DbSet<ItemType> ItemType { get; }
    //DbSet<Option> Option { get; }
    //DbSet<OptionGroup> OptionGroup { get; }
    //DbSet<Person> Person { get; }
    //DbSet<Resource> Resource { get; }
    //DbSet<ResourceItem> ResourceItem { get; }
    //DbSet<ResourcePerson> ResourcePerson { get; }
    //DbSet<ResourceType> ResourceType { get; }
    //DbSet<Venture> Venture { get; }
    //DbSet<VentureDetail> VentureDetail { get; }
    //DbSet<VentureAssociateOption> VentureAssociateOption { get; }
    //DbSet<VentureOption> VentureOption { get; }
    //DbSet<VentureResource> VentureResource { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}