//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class DetailTypeConfig : IEntityTypeConfiguration<DetailType>
//{
//    public void Configure(EntityTypeBuilder<DetailType> builder)
//    {
//        builder.ToTable("DetailType", "Subjects");

//        builder.HasIndex(e => e.DetailTypeKey)
//            .HasDatabaseName("IX_DetailType_Key")
//            .IsUnique();

//        builder.Property(e => e.DetailTypeDescription)
//            .HasMaxLength(250);

//        builder.Property(e => e.DetailTypeName)
//            .IsRequired()
//            .HasMaxLength(50);
//    }
//}