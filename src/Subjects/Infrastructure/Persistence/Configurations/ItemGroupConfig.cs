//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class ItemGroupConfig : IEntityTypeConfiguration<ItemGroup>
//{
//    public void Configure(EntityTypeBuilder<ItemGroup> builder)
//    {
//        builder.ToTable("ItemGroup", "Subjects");

//        builder.HasIndex(e => e.ItemGroupKey)
//            .HasDatabaseName("IX_ItemGroup_Key")
//            .IsUnique();

//        builder.Property(e => e.ItemGroupDescription)
//            .HasMaxLength(250);

//        builder.Property(e => e.ItemGroupName)
//            .IsRequired()
//            .HasMaxLength(50);
//    }
//}