
//https://www.syncfusion.com/blogs/post/build-crud-application-with-asp-net-core-entity-framework-visual-studio-2019.aspx
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace GoodToCode.Subjects.Models
{
    public partial class SubjectsDbContext : DbContext
    {
        public SubjectsDbContext()
        {
        }

        public SubjectsDbContext(DbContextOptions<SubjectsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<DetailType> DetailType { get; set; }
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<EntityAppointment> EntityAppointment { get; set; }
        public virtual DbSet<EntityDetail> EntityDetail { get; set; }
        public virtual DbSet<EntityLocation> EntityLocation { get; set; }
        public virtual DbSet<EntityOption> EntityOption { get; set; }
        public virtual DbSet<EntityTimeRecurring> EntityTimeRecurring { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Government> Government { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemGroup> ItemGroup { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<OptionGroup> OptionGroup { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<RecordState> RecordState { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<ResourceItem> ResourceItem { get; set; }
        public virtual DbSet<ResourcePerson> ResourcePerson { get; set; }
        public virtual DbSet<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        public virtual DbSet<ResourceType> ResourceType { get; set; }
        public virtual DbSet<Venture> Venture { get; set; }
        public virtual DbSet<VentureAppointment> VentureAppointment { get; set; }
        public virtual DbSet<VentureDetail> VentureDetail { get; set; }
        public virtual DbSet<VentureEntityOption> VentureEntityOption { get; set; }
        public virtual DbSet<VentureLocation> VentureLocation { get; set; }
        public virtual DbSet<VentureOption> VentureOption { get; set; }
        public virtual DbSet<VentureResource> VentureResource { get; set; }
        public virtual DbSet<VentureSchedule> VentureSchedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=tcp:GoodToCode.database.windows.net,1433;Initial Catalog=EntityData;user id=TestUser; password=57595709-9E9C-47EA-ABBF-4F3BAA1B0D37;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Application Name=GoodToCodeEntities;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("Business", "Entity");

                entity.HasIndex(e => e.BusinessKey)
                    .HasName("IX_BusinessEntity_Entity")
                    .IsUnique();

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TaxNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.BusinessKeyNavigation)
                    .WithOne(p => p.Business)
                    .HasPrincipalKey<Entity>(p => p.EntityKey)
                    .HasForeignKey<Business>(d => d.BusinessKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Business_Entity");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Business)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Business_RecordState");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.ToTable("Detail", "Entity");

                entity.HasIndex(e => e.DetailKey)
                    .HasName("IX_Detail_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DetailData)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DetailTypeKeyNavigation)
                    .WithMany(p => (System.Collections.Generic.IEnumerable<Detail>)p.Detail)
                    .HasPrincipalKey(p => p.DetailTypeKey)
                    .HasForeignKey(d => d.DetailTypeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detail_DetailType");
            });

            modelBuilder.Entity<DetailType>(entity =>
            {
                entity.ToTable("DetailType", "Entity");

                entity.HasIndex(e => e.DetailTypeKey)
                    .HasName("IX_DetailType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DetailTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.DetailTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.ToTable("Entity", "Entity");

                entity.HasIndex(e => e.EntityKey)
                    .HasName("IX_EntityLocation_Entity")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EntityAppointment>(entity =>
            {
                entity.ToTable("EntityAppointment", "Entity");

                entity.HasIndex(e => e.EntityAppointmentKey)
                    .HasName("IX_EntityAppointment_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntityKey, e.AppointmentKey })
                    .HasName("IX_EntityAppointment_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntityKeyNavigation)
                    .WithMany(p => p.EntityAppointment)
                    .HasPrincipalKey(p => p.EntityKey)
                    .HasForeignKey(d => d.EntityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityAppointment_Entity");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.EntityAppointment)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityAppointment_RecordState");
            });

            modelBuilder.Entity<EntityDetail>(entity =>
            {
                entity.ToTable("EntityDetail", "Entity");

                entity.HasIndex(e => e.EntityDetailKey)
                    .HasName("IX_EntityDetail_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntityKey, e.EntityDetailKey })
                    .HasName("IX_EntityDetail_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DetailKeyNavigation)
                    .WithMany(p => p.EntityDetail)
                    .HasPrincipalKey(p => p.DetailKey)
                    .HasForeignKey(d => d.DetailKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityDetail_Detail");

                entity.HasOne(d => d.EntityKeyNavigation)
                    .WithMany(p => p.EntityDetail)
                    .HasPrincipalKey(p => p.EntityKey)
                    .HasForeignKey(d => d.EntityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityDetail_Entity");
            });

            modelBuilder.Entity<EntityLocation>(entity =>
            {
                entity.ToTable("EntityLocation", "Entity");

                entity.HasIndex(e => new { e.EntityKey, e.LocationKey })
                    .HasName("IX_EntityLocation_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntityKeyNavigation)
                    .WithMany(p => p.EntityLocation)
                    .HasPrincipalKey(p => p.EntityKey)
                    .HasForeignKey(d => d.EntityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityLocation_Entity");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.EntityLocation)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityLocation_RecordState");
            });

            modelBuilder.Entity<EntityOption>(entity =>
            {
                entity.ToTable("EntityOption", "Entity");

                entity.HasIndex(e => new { e.EntityKey, e.OptionKey })
                    .HasName("IX_EntityOption_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.OptionKeyNavigation)
                    .WithMany(p => p.EntityOption)
                    .HasPrincipalKey(p => p.OptionKey)
                    .HasForeignKey(d => d.OptionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityOption_Option");
            });

            modelBuilder.Entity<EntityTimeRecurring>(entity =>
            {
                entity.ToTable("EntityTimeRecurring", "Entity");

                entity.HasIndex(e => e.EntityTimeRecurringKey)
                    .HasName("IX_EntityTimeRecurring_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntityKey, e.TimeRecurringKey })
                    .HasName("IX_EntityTimeRecurring_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TimeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.EntityKeyNavigation)
                    .WithMany(p => p.EntityTimeRecurring)
                    .HasPrincipalKey(p => p.EntityKey)
                    .HasForeignKey(d => d.EntityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityTimeRecurring_Entity");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.EntityTimeRecurring)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityTimeRecurring_RecordState");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender", "Entity");

                entity.HasIndex(e => e.GenderCode)
                    .HasName("IX_Gender_Code")
                    .IsUnique();

                entity.HasIndex(e => e.GenderKey)
                    .HasName("IX_Gender_Key")
                    .IsUnique();

                entity.Property(e => e.GenderId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GenderCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Government>(entity =>
            {
                entity.ToTable("Government", "Entity");

                entity.HasIndex(e => e.GovernmentKey)
                    .HasName("IX_Government_Entity")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GovernmentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.GovernmentKeyNavigation)
                    .WithOne(p => p.Government)
                    .HasPrincipalKey<Entity>(p => p.EntityKey)
                    .HasForeignKey<Government>(d => d.GovernmentKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Government_Entity");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Government)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Government_RecordState");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item", "Entity");

                entity.HasIndex(e => e.ItemKey)
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Item)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_RecordState");
            });

            modelBuilder.Entity<ItemGroup>(entity =>
            {
                entity.ToTable("ItemGroup", "Entity");

                entity.HasIndex(e => e.ItemGroupKey)
                    .HasName("IX_ItemGroup_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemGroupDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ItemGroupName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("ItemType", "Entity");

                entity.HasIndex(e => e.ItemTypeKey)
                    .HasName("IX_ItemType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ItemTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ItemGroupKeyNavigation)
                    .WithMany(p => p.ItemType)
                    .HasPrincipalKey(p => p.ItemGroupKey)
                    .HasForeignKey(d => d.ItemGroupKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemType_ItemGroup");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_MigrationHistory");

                entity.ToTable("__MigrationHistory", "Identity");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("Option", "Entity");

                entity.HasIndex(e => e.OptionKey)
                    .IsUnique();

                entity.HasIndex(e => new { e.OptionGroupKey, e.OptionCode })
                    .HasName("IX_Option_OptionCode")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OptionCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.OptionDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.OptionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.OptionGroupKeyNavigation)
                    .WithMany(p => p.Option)
                    .HasPrincipalKey(p => p.OptionGroupKey)
                    .HasForeignKey(d => d.OptionGroupKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Option_OptionGroup");
            });

            modelBuilder.Entity<OptionGroup>(entity =>
            {
                entity.ToTable("OptionGroup", "Entity");

                entity.HasIndex(e => e.OptionGroupCode)
                    .HasName("IX_Option_OptionGroupCode")
                    .IsUnique();

                entity.HasIndex(e => e.OptionGroupKey)
                    .HasName("IX_Option_OptionGroupKey")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OptionGroupCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.OptionGroupDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.OptionGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "Entity");

                entity.HasIndex(e => e.PersonKey)
                    .HasName("IX_Person_Entity")
                    .IsUnique();

                entity.HasIndex(e => new { e.FirstName, e.MiddleName, e.LastName, e.BirthDate })
                    .HasName("IX_Person_All");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Gender");

                entity.HasOne(d => d.PersonKeyNavigation)
                    .WithOne(p => p.Person)
                    .HasPrincipalKey<Entity>(p => p.EntityKey)
                    .HasForeignKey<Person>(d => d.PersonKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Entity");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Person)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_RecordState");
            });

            modelBuilder.Entity<RecordState>(entity =>
            {
                entity.ToTable("RecordState", "Entity");

                entity.HasIndex(e => e.RecordStateKey)
                    .HasName("IX_RecordState_Key")
                    .IsUnique();

                entity.Property(e => e.RecordStateId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RecordStateName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resource", "Entity");

                entity.HasIndex(e => e.ResourceKey)
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ResourceDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ResourceName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Resource)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resource_RecordState");
            });

            modelBuilder.Entity<ResourceItem>(entity =>
            {
                entity.ToTable("ResourceItem", "Entity");

                entity.HasIndex(e => e.ItemKey)
                    .HasName("IX_ResourceItem_Item");

                entity.HasIndex(e => e.ResourceItemKey)
                    .HasName("IX_ResourceItem_Key")
                    .IsUnique();

                entity.HasIndex(e => e.ResourceKey)
                    .HasName("IX_ResourceItem_Resource");

                entity.HasIndex(e => new { e.ResourceKey, e.ItemKey })
                    .HasName("IX_ResourceItem_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ItemKeyNavigation)
                    .WithMany(p => p.ResourceItem)
                    .HasPrincipalKey(p => p.ItemKey)
                    .HasForeignKey(d => d.ItemKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceItem_Item");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.ResourceItem)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceItem_RecordState");

                entity.HasOne(d => d.ResourceKeyNavigation)
                    .WithMany(p => p.ResourceItem)
                    .HasPrincipalKey(p => p.ResourceKey)
                    .HasForeignKey(d => d.ResourceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceItem_Resource");
            });

            modelBuilder.Entity<ResourcePerson>(entity =>
            {
                entity.ToTable("ResourcePerson", "Entity");

                entity.HasIndex(e => e.PersonKey)
                    .HasName("IX_ResourcePerson_Person");

                entity.HasIndex(e => e.ResourceKey)
                    .HasName("IX_ResourcePerson_Resource");

                entity.HasIndex(e => e.ResourcePersonKey)
                    .HasName("IX_ResourcePerson_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.ResourceKey, e.PersonKey })
                    .HasName("IX_ResourcePerson_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.PersonKeyNavigation)
                    .WithMany(p => p.ResourcePerson)
                    .HasPrincipalKey(p => p.PersonKey)
                    .HasForeignKey(d => d.PersonKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourcePerson_Person");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.ResourcePerson)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourcePerson_RecordState");

                entity.HasOne(d => d.ResourceKeyNavigation)
                    .WithMany(p => p.ResourcePerson)
                    .HasPrincipalKey(p => p.ResourceKey)
                    .HasForeignKey(d => d.ResourceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceResource_Resource");
            });

            modelBuilder.Entity<ResourceTimeRecurring>(entity =>
            {
                entity.ToTable("ResourceTimeRecurring", "Entity");

                entity.HasIndex(e => e.ResourceTimeRecurringKey)
                    .HasName("IX_ResourceTimeRecurring_Resource")
                    .IsUnique();

                entity.HasIndex(e => new { e.ResourceKey, e.TimeRecurringKey })
                    .HasName("IX_ResourceTimeRecurring_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TimeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.ResourceTimeRecurring)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceTimeRecurring_RecordState");

                entity.HasOne(d => d.ResourceKeyNavigation)
                    .WithMany(p => p.ResourceTimeRecurring)
                    .HasPrincipalKey(p => p.ResourceKey)
                    .HasForeignKey(d => d.ResourceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceTimeRecurring_Resource");
            });

            modelBuilder.Entity<ResourceType>(entity =>
            {
                entity.ToTable("ResourceType", "Entity");

                entity.HasIndex(e => e.ResourceTypeKey)
                    .HasName("IX_ResourceType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ResourceTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ResourceTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Venture>(entity =>
            {
                entity.ToTable("Venture", "Entity");

                entity.HasIndex(e => e.VentureKey)
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.VentureDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.VentureName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VentureSlogan)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Venture)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venture_RecordState");
            });

            modelBuilder.Entity<VentureAppointment>(entity =>
            {
                entity.ToTable("VentureAppointment", "Entity");

                entity.HasIndex(e => e.VentureAppointmentKey)
                    .HasName("IX_VentureAppointment_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.AppointmentKey })
                    .HasName("IX_VentureAppointment_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.VentureAppointment)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureAppointment_RecordState");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureAppointment)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureAppointment_Venture");
            });

            modelBuilder.Entity<VentureDetail>(entity =>
            {
                entity.ToTable("VentureDetail", "Entity");

                entity.HasIndex(e => e.VentureDetailKey)
                    .HasName("IX_VentureDetail_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.VentureDetailKey })
                    .HasName("IX_VentureDetail_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DetailKeyNavigation)
                    .WithMany(p => p.VentureDetail)
                    .HasPrincipalKey(p => p.DetailKey)
                    .HasForeignKey(d => d.DetailKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureDetail_Detail");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureDetail)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureDetail_Venture");
            });

            modelBuilder.Entity<VentureEntityOption>(entity =>
            {
                entity.ToTable("VentureEntityOption", "Entity");

                entity.HasIndex(e => e.VentureEntityOptionKey)
                    .HasName("IX_VentureEntityOption_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntityKeyNavigation)
                    .WithMany(p => p.VentureEntityOption)
                    .HasPrincipalKey(p => p.EntityKey)
                    .HasForeignKey(d => d.EntityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureEntityOption_Entity");

                entity.HasOne(d => d.OptionKeyNavigation)
                    .WithMany(p => p.VentureEntityOption)
                    .HasPrincipalKey(p => p.OptionKey)
                    .HasForeignKey(d => d.OptionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureEntityOption_Option");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureEntityOption)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureEntityOption_Venture");
            });

            modelBuilder.Entity<VentureLocation>(entity =>
            {
                entity.ToTable("VentureLocation", "Entity");

                entity.HasIndex(e => e.VentureLocationKey)
                    .HasName("IX_VentureLocation_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.LocationKey })
                    .HasName("IX_VentureLocation_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.VentureLocation)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureLocation_RecordState");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureLocation)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureLocation_Venture");
            });

            modelBuilder.Entity<VentureOption>(entity =>
            {
                entity.ToTable("VentureOption", "Entity");

                entity.HasIndex(e => new { e.VentureKey, e.OptionKey })
                    .HasName("IX_VentureOption_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.OptionKeyNavigation)
                    .WithMany(p => p.VentureOption)
                    .HasPrincipalKey(p => p.OptionKey)
                    .HasForeignKey(d => d.OptionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureOption_Option");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureOption)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureOption_Venture");
            });

            modelBuilder.Entity<VentureResource>(entity =>
            {
                entity.ToTable("VentureResource", "Entity");

                entity.HasIndex(e => e.VentureResourceKey)
                    .HasName("IX_VentureResource_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.ResourceKey })
                    .HasName("IX_VentureResource_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.VentureResource)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureResource_RecordState");

                entity.HasOne(d => d.ResourceKeyNavigation)
                    .WithMany(p => p.VentureResource)
                    .HasPrincipalKey(p => p.ResourceKey)
                    .HasForeignKey(d => d.ResourceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureResource_Resource");

                entity.HasOne(d => d.ResourceTypeKeyNavigation)
                    .WithMany(p => p.VentureResource)
                    .HasPrincipalKey(p => p.ResourceTypeKey)
                    .HasForeignKey(d => d.ResourceTypeKey)
                    .HasConstraintName("FK_VentureResource_ResourceType");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureResource)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureResource_Venture");
            });

            modelBuilder.Entity<VentureSchedule>(entity =>
            {
                entity.ToTable("VentureSchedule", "Entity");

                entity.HasIndex(e => e.VentureScheduleKey)
                    .HasName("IX_VentureSchedule_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.ScheduleKey })
                    .HasName("IX_VentureSchedule_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.VentureSchedule)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureSchedule_RecordState");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureSchedule)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureSchedule_Venture");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
