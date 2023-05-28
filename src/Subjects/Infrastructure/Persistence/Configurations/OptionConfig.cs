//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class OptionConfig : IEntityTypeConfiguration<Option>
//{
//    public void Configure(EntityTypeBuilder<Option> builder)
//    {
//        builder.ToTable("Option", "Subjects");

//        builder.HasIndex(e => e.OptionKey)
//            .IsUnique();

//        builder.HasIndex(e => new { e.OptionGroupKey, e.OptionCode })
//            .HasDatabaseName("IX_Option_OptionCode")
//            .IsUnique();

//        builder.Property(e => e.OptionCode)
//            .IsRequired()
//            .HasMaxLength(10);

//        builder.Property(e => e.OptionDescription)
//            .HasMaxLength(250);

//        builder.Property(e => e.OptionName)
//            .IsRequired()
//            .HasMaxLength(50);
//    }
//}