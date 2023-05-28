using Goodtocode.Subjects.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Goodtocode.Subjects.Persistence.Configurations;

internal class BusinessConfig : IEntityTypeConfiguration<BusinessEntity>
{
    public void Configure(EntityTypeBuilder<BusinessEntity> builder)
    {
        builder.ToTable("Business", "Subjects");

        builder.HasIndex(e => e.BusinessKey)
                .HasDatabaseName("IX_Business_Key")
                .IsUnique();

        builder.Property(e => e.BusinessName)
                .IsRequired()
                .HasMaxLength(200);

        builder.Property(e => e.TaxNumber)
                .HasMaxLength(20);
    }
}