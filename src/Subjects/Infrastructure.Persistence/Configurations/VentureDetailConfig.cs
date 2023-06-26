//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class VentureDetailConfig : IEntityTypeConfiguration<VentureDetail>
//{
//    public void Configure(EntityTypeBuilder<VentureDetail> builder)
//    {
//        builder.ToTable("VentureDetail", "Subjects");

//        builder.HasIndex(e => e.VentureDetailKey)
//            .HasDatabaseName("IX_VentureDetail_Key")
//            .IsUnique();

//        builder.HasIndex(e => new { e.VentureKey, e.VentureDetailKey })
//            .HasDatabaseName("IX_VentureDetail_All")
//            .IsUnique();
//    }
//}