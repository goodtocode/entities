//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class DetailConfig : IEntityTypeConfiguration<Detail>
//{
//    public void Configure(EntityTypeBuilder<Detail> builder)
//    {
//        builder.ToTable("Detail", "Subjects");

//        builder.HasIndex(e => e.DetailKey)
//            .HasDatabaseName("IX_Detail_Key")
//            .IsUnique();

//        builder.Property(e => e.DetailData)
//            .IsRequired()
//            .HasMaxLength(2000);
//    }
//}