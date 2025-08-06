using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UnitOfMeasurementConfiguration : BaseEntityTypeConfiguration<UnitOfMeasurement>
{
    public override void Configure(EntityTypeBuilder<UnitOfMeasurement> builder)
    {
        base.Configure(builder);
        
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(u => u.Status)
            .HasDefaultValue(true);
        
        builder.HasMany(u => u.ReceiptResources)
            .WithOne(rr => rr.UnitOfMeasurement)
            .HasForeignKey(rr => rr.UnitOfMeasurementId);
    }
}