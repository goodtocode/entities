//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class ResourceConfig : IEntityTypeConfiguration<Resource>
//{
//    public void Configure(EntityTypeBuilder<Resource> builder)
//    {
//        builder.ToTable("Resource", "Subjects");

//        builder.HasIndex(e => e.ResourceKey)
//            .IsUnique();

//        builder.Property(e => e.ResourceDescription)
//            .HasMaxLength(250);

//        builder.Property(e => e.ResourceName)
//            .IsRequired()
//            .HasMaxLength(50);
//    }
//}