using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Goodtocode.Subjects.Persistence.Contexts;

public partial class SubjectsDbContext : DbContext, ISubjectsDbContext
{
    public SubjectsDbContext(DbContextOptions<SubjectsDbContext> options)
        : base(options)
    { }

    public virtual DbSet<BusinessEntity> Business => Set<BusinessEntity>();
    //public virtual DbSet<Detail> Detail => Set<Detail>();
    //public virtual DbSet<DetailType> DetailType => Set<DetailType>();
    //public virtual DbSet<Associate> Associate => Set<Associate>();
    //public virtual DbSet<AssociateDetail> AssociateDetail => Set<AssociateDetail>();
    //public virtual DbSet<AssociateOption> AssociateOption => Set<AssociateOption>();
    //public virtual DbSet<Gender> Gender => Set<Gender>();
    //public virtual DbSet<Government> Government => Set<Government>();
    //public virtual DbSet<Item> Item => Set<Item>();
    //public virtual DbSet<ItemGroup> ItemGroup => Set<ItemGroup>();
    //public virtual DbSet<ItemType> ItemType => Set<ItemType>();
    //public virtual DbSet<Option> Option => Set<Option>();
    //public virtual DbSet<OptionGroup> OptionGroup => Set<OptionGroup>();
    //public virtual DbSet<Person> Person => Set<Person>();
    //public virtual DbSet<Resource> Resource => Set<Resource>();
    //public virtual DbSet<ResourceItem> ResourceItem => Set<ResourceItem>();
    //public virtual DbSet<ResourcePerson> ResourcePerson => Set<ResourcePerson>();
    //public virtual DbSet<ResourceType> ResourceType => Set<ResourceType>();
    //public virtual DbSet<Venture> Venture => Set<Venture>();
    //public virtual DbSet<VentureDetail> VentureDetail => Set<VentureDetail>();
    //public virtual DbSet<VentureAssociateOption> VentureAssociateOption => Set<VentureAssociateOption>();
    //public virtual DbSet<VentureOption> VentureOption => Set<VentureOption>();
    //public virtual DbSet<VentureResource> VentureResource => Set<VentureResource>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
