//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class VentureOptionConfig : IEntityTypeConfiguration<VentureOption>
//{
//    public void Configure(EntityTypeBuilder<VentureOption> builder)
//    {
//        builder.ToTable("VentureOption", "Subjects");

//        builder.HasIndex(e => new { e.VentureKey, e.OptionKey })
//            .HasDatabaseName("IX_VentureOption_All")
//            .IsUnique();
//    }
//}