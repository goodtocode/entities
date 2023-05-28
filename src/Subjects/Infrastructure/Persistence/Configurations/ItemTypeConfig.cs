//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class ItemTypeConfig : IEntityTypeConfiguration<ItemType>
//{
//    public void Configure(EntityTypeBuilder<ItemType> builder)
//    {
//        builder.ToTable("ItemType", "Subjects");

//        builder.HasIndex(e => e.ItemTypeKey)
//            .HasDatabaseName("IX_ItemType_Key")
//            .IsUnique();

//        builder.Property(e => e.ItemTypeDescription)
//            .HasMaxLength(250);

//        builder.Property(e => e.ItemTypeName)
//            .IsRequired()
//            .HasMaxLength(50);
//    }
//}