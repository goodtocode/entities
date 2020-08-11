using GoodToCode.Shared.Data;
using GoodToCode.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Models
{
    public interface ISubjectsDbContext : IDbContext
    {
        DbSet<Business> Business { get; set; }
        DbSet<Detail> Detail { get; set; }
        DbSet<DetailType> DetailType { get; set; }
        DbSet<Associate> Associate { get; set; }
        DbSet<AssociateAppointment> AssociateAppointment { get; set; }
        DbSet<AssociateDetail> AssociateDetail { get; set; }
        DbSet<AssociateLocation> AssociateLocation { get; set; }
        DbSet<AssociateOption> AssociateOption { get; set; }
        DbSet<AssociateTimeRecurring> AssociateTimeRecurring { get; set; }
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
        DbSet<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        DbSet<ResourceType> ResourceType { get; set; }
        DbSet<Venture> Venture { get; set; }
        DbSet<VentureAppointment> VentureAppointment { get; set; }
        DbSet<VentureDetail> VentureDetail { get; set; }
        DbSet<VentureAssociateOption> VentureAssociateOption { get; set; }
        DbSet<VentureLocation> VentureLocation { get; set; }
        DbSet<VentureOption> VentureOption { get; set; }
        DbSet<VentureResource> VentureResource { get; set; }
        DbSet<VentureSchedule> VentureSchedule { get; set; }        
    }
}