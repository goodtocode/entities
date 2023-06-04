//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class VentureConfig : IEntityTypeConfiguration<Venture>
//{
//    public void Configure(EntityTypeBuilder<Venture> builder)
//    {
//        builder.ToTable("Venture", "Subjects");

//        builder.HasIndex(e => e.VentureKey)
//            .IsUnique();

//        builder.Property(e => e.VentureDescription)
//            .HasMaxLength(250);

//        builder.Property(e => e.VentureName)
//            .IsRequired()
//            .HasMaxLength(50);

//        builder.Property(e => e.VentureSlogan)
//            .IsRequired()
//            .HasMaxLength(50);
//    }
//}