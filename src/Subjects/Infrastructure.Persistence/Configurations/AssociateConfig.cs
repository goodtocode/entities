//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class AssociateConfig : IEntityTypeConfiguration<Associate>
//{
//    public void Configure(EntityTypeBuilder<Associate> builder)
//    {
//        builder.ToTable("Associate", "Subjects");

//        builder.HasIndex(e => e.AssociateKey)
//            .HasDatabaseName("IX_AssociateLocation_Associate")
//            .IsUnique();
//    }
//}