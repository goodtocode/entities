//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class VentureAssociateOptionConfig : IEntityTypeConfiguration<VentureAssociateOption>
//{
//    public void Configure(EntityTypeBuilder<VentureAssociateOption> builder)
//    {
//        builder.ToTable("VentureAssociateOption", "Subjects");

//        builder.HasIndex(e => e.VentureAssociateOptionKey)
//            .HasDatabaseName("IX_VentureAssociateOption_Key")
//            .IsUnique();
//    }
//}