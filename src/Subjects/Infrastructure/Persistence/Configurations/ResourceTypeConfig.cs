//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class ResourceTypeConfig : IEntityTypeConfiguration<ResourceType>
//{
//    public void Configure(EntityTypeBuilder<ResourceType> builder)
//    {
//        builder.ToTable("ResourceType", "Subjects");

//        builder.HasIndex(e => e.ResourceTypeKey)
//            .HasDatabaseName("IX_ResourceType_Key")
//            .IsUnique();

//        builder.Property(e => e.ResourceTypeDescription)
//            .HasMaxLength(250);

//        builder.Property(e => e.ResourceTypeName)
//            .IsRequired()
//            .HasMaxLength(50);
//    }
//}