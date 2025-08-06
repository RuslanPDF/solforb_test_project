using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ResourceConfiguration : BaseEntityTypeConfiguration<Resource>
{
    public override void Configure(EntityTypeBuilder<Resource> builder)
    {
        base.Configure(builder);
        builder.HasIndex(r => r.Name).IsUnique();

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(r => r.Status)
            .HasDefaultValue(true);
        
        builder.HasMany(r => r.ReceiptResources)
            .WithOne(rr => rr.Resource)
            .HasForeignKey(rr => rr.ResourceId);
    }
}