using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Subjects.Models
{
    public interface ISubjectsDbContext
    {
        DbSet<Business> Business { get; set; }
        DbSet<Detail> Detail { get; set; }
        DbSet<DetailType> DetailType { get; set; }
        DbSet<Entity> Entity { get; set; }
        DbSet<EntityAppointment> EntityAppointment { get; set; }
        DbSet<EntityDetail> EntityDetail { get; set; }
        DbSet<EntityLocation> EntityLocation { get; set; }
        DbSet<EntityOption> EntityOption { get; set; }
        DbSet<EntityTimeRecurring> EntityTimeRecurring { get; set; }
        DbSet<Gender> Gender { get; set; }
        DbSet<Government> Government { get; set; }
        DbSet<Item> Item { get; set; }
        DbSet<ItemGroup> ItemGroup { get; set; }
        DbSet<ItemType> ItemType { get; set; }
        DbSet<MigrationHistory> MigrationHistory { get; set; }
        DbSet<Option> Option { get; set; }
        DbSet<OptionGroup> OptionGroup { get; set; }
        DbSet<Person> Person { get; set; }
        DbSet<RecordState> RecordState { get; set; }
        DbSet<Resource> Resource { get; set; }
        DbSet<ResourceItem> ResourceItem { get; set; }
        DbSet<ResourcePerson> ResourcePerson { get; set; }
        DbSet<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        DbSet<ResourceType> ResourceType { get; set; }
        DbSet<Venture> Venture { get; set; }
        DbSet<VentureAppointment> VentureAppointment { get; set; }
        DbSet<VentureDetail> VentureDetail { get; set; }
        DbSet<VentureEntityOption> VentureEntityOption { get; set; }
        DbSet<VentureLocation> VentureLocation { get; set; }
        DbSet<VentureOption> VentureOption { get; set; }
        DbSet<VentureResource> VentureResource { get; set; }
        DbSet<VentureSchedule> VentureSchedule { get; set; }
    }
}