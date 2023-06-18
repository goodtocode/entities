//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class AssociateOptionConfig : IEntityTypeConfiguration<AssociateOption>
//{
//    public void Configure(EntityTypeBuilder<AssociateOption> builder)
//    {
//        builder.ToTable("AssociateOption", "Subjects");

//        builder.HasIndex(e => new { e.AssociateKey, e.OptionKey })
//            .HasDatabaseName("IX_AssociateOption_All")
//            .IsUnique();
//    }
//}