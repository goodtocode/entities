//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class GenderConfig : IEntityTypeConfiguration<Gender>
//{
//    public void Configure(EntityTypeBuilder<Gender> builder)
//    {
//        builder.ToTable("Gender", "Subjects", t =>
//            t.HasCheckConstraint("CC_Gender_GenderCode", "GenderCode in ('M', 'F', 'N/A', 'U/K')"));

//        builder.HasIndex(e => e.GenderCode)
//            .HasDatabaseName("IX_Gender_Code")
//            .IsUnique();

//        builder.HasIndex(e => e.GenderKey)
//            .HasDatabaseName("IX_Gender_Key")
//            .IsUnique();

//        builder.Property(e => e.GenderCode).ValueGeneratedNever();

//        builder.Property(e => e.GenderCode)
//            .IsRequired()
//            .HasMaxLength(10);

//        builder.Property(e => e.GenderName)
//            .IsRequired()
//            .HasMaxLength(50);
//    }
//}