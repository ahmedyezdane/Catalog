using Domain.Features.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Products.EntityConfigurations;

internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable(Tables.Brands, Schemas.Product);
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Name).IsRequired(false).HasMaxLength(250);

        builder.HasMany(a => a.Products).WithOne(a => a.Brand).HasForeignKey(c => c.BrandId);
    }
}