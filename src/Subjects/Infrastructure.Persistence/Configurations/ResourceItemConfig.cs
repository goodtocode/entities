//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class ResourceItemConfig : IEntityTypeConfiguration<ResourceItem>
//{
//    public void Configure(EntityTypeBuilder<ResourceItem> builder)
//    {
//        builder.ToTable("ResourceItem", "Subjects");

//        builder.HasIndex(e => e.ItemKey)
//            .HasDatabaseName("IX_ResourceItem_Item");

//        builder.HasIndex(e => e.ResourceItemKey)
//            .HasDatabaseName("IX_ResourceItem_Key")
//            .IsUnique();

//        builder.HasIndex(e => e.ResourceKey)
//            .HasDatabaseName("IX_ResourceItem_Resource");

//        builder.HasIndex(e => new { e.ResourceKey, e.ItemKey })
//            .HasDatabaseName("IX_ResourceItem_All")
//            .IsUnique();
//    }
//}