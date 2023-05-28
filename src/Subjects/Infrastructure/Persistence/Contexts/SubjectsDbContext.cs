using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace Goodtocode.Subjects.Persistence.Contexts;

public partial class SubjectsDbContext : DbContext, ISubjectsDbContext
{
    public SubjectsDbContext(DbContextOptions<SubjectsDbContext> options)
        : base(options)
    { }

    public virtual DbSet<BusinessEntity> Business { get; set; }
    //public virtual DbSet<Detail> Detail { get; set; }
    //public virtual DbSet<DetailType> DetailType { get; set; }
    //public virtual DbSet<Associate> Associate { get; set; }
    //public virtual DbSet<AssociateDetail> AssociateDetail { get; set; }
    //public virtual DbSet<AssociateOption> AssociateOption { get; set; }
    //public virtual DbSet<Gender> Gender { get; set; }
    //public virtual DbSet<Government> Government { get; set; }
    //public virtual DbSet<Item> Item { get; set; }
    //public virtual DbSet<ItemGroup> ItemGroup { get; set; }
    //public virtual DbSet<ItemType> ItemType { get; set; }
    //public virtual DbSet<Option> Option { get; set; }
    //public virtual DbSet<OptionGroup> OptionGroup { get; set; }
    //public virtual DbSet<Person> Person { get; set; }
    //public virtual DbSet<Resource> Resource { get; set; }
    //public virtual DbSet<ResourceItem> ResourceItem { get; set; }
    //public virtual DbSet<ResourcePerson> ResourcePerson { get; set; }
    //public virtual DbSet<ResourceType> ResourceType { get; set; }
    //public virtual DbSet<Venture> Venture { get; set; }
    //public virtual DbSet<VentureDetail> VentureDetail { get; set; }
    //public virtual DbSet<VentureAssociateOption> VentureAssociateOption { get; set; }
    //public virtual DbSet<VentureOption> VentureOption { get; set; }
    //public virtual DbSet<VentureResource> VentureResource { get; set; }

    public DatabaseFacade Database { get; set; }

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
