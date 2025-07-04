using Domain.Features.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Products.EntityConfigurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(Tables.Categories, Schemas.Product);
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

        builder.HasMany(a => a.Children).WithOne(a => a.Parent).HasForeignKey(c => c.ParentId);
        builder.HasMany(a => a.Products).WithOne(a => a.Category).HasForeignKey(c => c.CategoryId);
    }
}
