//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class ItemConfig : IEntityTypeConfiguration<Item>
//{
//    public void Configure(EntityTypeBuilder<Item> builder)
//    {
//        builder.ToTable("Item", "Subjects");

//        builder.HasIndex(e => e.ItemKey)
//            .IsUnique();

//        builder.Property(e => e.ItemDescription)
//            .IsRequired()
//            .HasMaxLength(2000);

//        builder.Property(e => e.ItemName)
//            .IsRequired()
//            .HasMaxLength(50);
//    }
//}