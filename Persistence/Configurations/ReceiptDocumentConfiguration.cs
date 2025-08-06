using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ReceiptDocumentConfiguration : BaseEntityTypeConfiguration<ReceiptDocument>
{
    public override void Configure(EntityTypeBuilder<ReceiptDocument> builder)
    {
        base.Configure(builder);

        builder.HasIndex(rd => rd.Number).IsUnique();

        builder.Property(rd => rd.Number)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(rd => rd.Date)
            .IsRequired();

        builder.HasMany(rd => rd.ReceiptResources)
            .WithOne(rr => rr.ReceiptDocument)
            .HasForeignKey(rr => rr.ReceiptDocumentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}