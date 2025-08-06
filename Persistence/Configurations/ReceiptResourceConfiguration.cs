using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ReceiptResourceConfiguration : BaseEntityTypeConfiguration<ReceiptResource>
{
    public override void Configure(EntityTypeBuilder<ReceiptResource> builder)
    {
        base.Configure(builder);

        builder.HasOne(rr => rr.ReceiptDocument)
            .WithMany(rd => rd.ReceiptResources)
            .HasForeignKey(rr => rr.ReceiptDocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rr => rr.Resource)
            .WithMany(r => r.ReceiptResources)
            .HasForeignKey(rr => rr.ResourceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(rr => rr.UnitOfMeasurement)
            .WithMany(u => u.ReceiptResources)
            .HasForeignKey(rr => rr.UnitOfMeasurementId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(rr => rr.Quantity)
            .IsRequired()
            .HasColumnType("decimal(18, 3)");

        builder.HasIndex(rr => new { rr.ReceiptDocumentId, rr.ResourceId, rr.UnitOfMeasurementId })
            .IsUnique(false);
    }
}