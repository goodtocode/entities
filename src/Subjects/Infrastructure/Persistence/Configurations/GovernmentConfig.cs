//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class GovernmentConfig : IEntityTypeConfiguration<Government>
//{
//    public void Configure(EntityTypeBuilder<Government> builder)
//    {
//        builder.ToTable("Government", "Subjects");

//        builder.HasIndex(e => e.GovernmentKey)
//            .HasDatabaseName("IX_Government_Associate")
//            .IsUnique();

//        builder.Property(e => e.GovernmentName)
//            .IsRequired()
//            .HasMaxLength(50);
//    }
//}