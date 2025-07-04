using Domain.Features.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Products.EntityConfigurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(Tables.Products, Schemas.Product);
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Name).IsRequired(false).HasMaxLength(250);

        builder.OwnsMany(c => c.Medias, m =>
        {
            m.ToTable(Tables.Medias, Schemas.Product);
        });
    }
}
