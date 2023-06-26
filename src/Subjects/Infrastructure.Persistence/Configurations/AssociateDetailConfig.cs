//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class AssociateDetailConfig : IEntityTypeConfiguration<AssociateDetail>
//{
//    public void Configure(EntityTypeBuilder<AssociateDetail> builder)
//    {
//        builder.ToTable("AssociateDetail", "Subjects");

//        builder.HasIndex(e => e.AssociateDetailKey)
//            .HasDatabaseName("IX_AssociateDetail_Key")
//            .IsUnique();

//        builder.HasIndex(e => new { e.AssociateKey, e.AssociateDetailKey })
//            .HasDatabaseName("IX_AssociateDetail_All")
//            .IsUnique();
//    }
//}