//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class ResourcePersonConfig : IEntityTypeConfiguration<ResourcePerson>
//{
//    public void Configure(EntityTypeBuilder<ResourcePerson> builder)
//    {
//        builder.ToTable("ResourcePerson", "Subjects");

//        builder.HasIndex(e => e.PersonKey)
//            .HasDatabaseName("IX_ResourcePerson_Person");

//        builder.HasIndex(e => e.ResourceKey)
//            .HasDatabaseName("IX_ResourcePerson_Resource");

//        builder.HasIndex(e => e.ResourcePersonKey)
//            .HasDatabaseName("IX_ResourcePerson_Key")
//            .IsUnique();

//        builder.HasIndex(e => new { e.ResourceKey, e.PersonKey })
//            .HasDatabaseName("IX_ResourcePerson_All")
//            .IsUnique();
//    }
//}