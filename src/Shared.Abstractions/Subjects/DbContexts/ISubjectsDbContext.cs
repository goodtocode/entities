using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Models
{
    public interface ISubjectsDbContext
    {
        DbSet<IBusiness> Business { get; set; }
        DbSet<IDetail> Detail { get; set; }
        DbSet<IDetailType> DetailType { get; set; }
        DbSet<IEntity> Entity { get; set; }
        DbSet<IEntityAppointment> EntityAppointment { get; set; }
        DbSet<IEntityDetail> EntityDetail { get; set; }
        DbSet<IEntityLocation> EntityLocation { get; set; }
        DbSet<IEntityOption> EntityOption { get; set; }
        DbSet<IEntityTimeRecurring> EntityTimeRecurring { get; set; }
        DbSet<IGender> Gender { get; set; }
        DbSet<IGovernment> Government { get; set; }
        DbSet<IItem> Item { get; set; }
        DbSet<IItemGroup> ItemGroup { get; set; }
        DbSet<IItemType> ItemType { get; set; }
        DbSet<IOption> Option { get; set; }
        DbSet<IOptionGroup> OptionGroup { get; set; }
        DbSet<IPerson> Person { get; set; }
        DbSet<IRecordState> RecordState { get; set; }
        DbSet<IResource> Resource { get; set; }
        DbSet<IResourceItem> ResourceItem { get; set; }
        DbSet<IResourcePerson> ResourcePerson { get; set; }
        DbSet<IResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        DbSet<IResourceType> ResourceType { get; set; }
        DbSet<IVenture> Venture { get; set; }
        DbSet<IVentureAppointment> VentureAppointment { get; set; }
        DbSet<IVentureDetail> VentureDetail { get; set; }
        DbSet<IVentureEntityOption> VentureEntityOption { get; set; }
        DbSet<IVentureLocation> VentureLocation { get; set; }
        DbSet<IVentureOption> VentureOption { get; set; }
        DbSet<IVentureResource> VentureResource { get; set; }
        DbSet<IVentureSchedule> VentureSchedule { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}