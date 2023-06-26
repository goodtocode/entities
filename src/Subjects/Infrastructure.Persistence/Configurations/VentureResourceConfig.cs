//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class VentureResourceConfig : IEntityTypeConfiguration<VentureResource>
//{
//    public void Configure(EntityTypeBuilder<VentureResource> builder)
//    {
//        builder.ToTable("VentureResource", "Subjects");

//        builder.HasIndex(e => e.VentureResourceKey)
//            .HasDatabaseName("IX_VentureResource_Key")
//            .IsUnique();

//        builder.HasIndex(e => new { e.VentureKey, e.ResourceKey })
//            .HasDatabaseName("IX_VentureResource_All")
//            .IsUnique();
//    }
//}