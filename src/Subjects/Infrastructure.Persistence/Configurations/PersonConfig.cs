//using Goodtocode.Subjects.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Goodtocode.Subjects.Persistence.Subjects.Configurations;

//internal class PersonConfig : IEntityTypeConfiguration<Person>
//{
//    public void Configure(EntityTypeBuilder<Person> builder)
//    {
//        builder.ToTable("Person", "Subjects");

//        builder.HasIndex(e => e.PersonKey)
//            .HasDatabaseName("IX_Person_Associate")
//            .IsUnique();

//        builder.HasIndex(e => new { e.FirstName, e.MiddleName, e.LastName, e.BirthDate })
//            .HasDatabaseName("IX_Person_All");

//        builder.Property(e => e.BirthDate).HasColumnType("datetime");

//        builder.Property(e => e.FirstName)
//            .IsRequired()
//            .HasMaxLength(50);

//        builder.Property(e => e.LastName)
//            .IsRequired()
//            .HasMaxLength(50);

//        builder.Property(e => e.MiddleName)
//            .IsRequired()
//            .HasMaxLength(50);

//        builder.Property(e => e.GenderCode).HasMaxLength(3);

//        builder.HasCheckConstraint("CC_Person_GenderCode", "GenderCode in ('M', 'F', 'N/A', 'U/K')");
//    }
//}