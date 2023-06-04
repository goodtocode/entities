//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class OptionGroupConfig : IEntityTypeConfiguration<OptionGroup>
//{
//    public void Configure(EntityTypeBuilder<OptionGroup> builder)
//    {
//        builder.ToTable("OptionGroup", "Subjects");

//        builder.HasIndex(e => e.OptionGroupCode)
//            .HasDatabaseName("IX_Option_OptionGroupCode")
//            .IsUnique();

//        builder.HasIndex(e => e.OptionGroupKey)
//            .HasDatabaseName("IX_Option_OptionGroupKey")
//            .IsUnique();

//        builder.Property(e => e.OptionGroupCode)
//            .IsRequired()
//            .HasMaxLength(10);

//        builder.Property(e => e.OptionGroupDescription)
//            .HasMaxLength(250);

//        builder.Property(e => e.OptionGroupName)
//            .IsRequired()
//            .HasMaxLength(50);
//    }
//}