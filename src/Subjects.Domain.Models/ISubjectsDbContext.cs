using GoodToCode.Shared.EntityFramework;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Subjects.Infrastructure
{
    public interface ISubjectsDbContext : IDbContext
    {
        DbSet<Business> Business { get; set; }
        DbSet<Detail> Detail { get; set; }
        DbSet<DetailType> DetailType { get; set; }
        DbSet<Associate> Associate { get; set; }
        DbSet<AssociateDetail> AssociateDetail { get; set; }        
        DbSet<AssociateOption> AssociateOption { get; set; }        
        DbSet<Gender> Gender { get; set; }
        DbSet<Government> Government { get; set; }
        DbSet<Item> Item { get; set; }
        DbSet<ItemGroup> ItemGroup { get; set; }
        DbSet<ItemType> ItemType { get; set; }
        DbSet<Option> Option { get; set; }
        DbSet<OptionGroup> OptionGroup { get; set; }
        DbSet<Person> Person { get; set; }
        DbSet<Resource> Resource { get; set; }
        DbSet<ResourceItem> ResourceItem { get; set; }
        DbSet<ResourcePerson> ResourcePerson { get; set; }
        DbSet<ResourceType> ResourceType { get; set; }
        DbSet<Venture> Venture { get; set; }
        DbSet<VentureDetail> VentureDetail { get; set; }
        DbSet<VentureAssociateOption> VentureAssociateOption { get; set; }
        DbSet<VentureOption> VentureOption { get; set; }
        DbSet<VentureResource> VentureResource { get; set; }        
    }
}