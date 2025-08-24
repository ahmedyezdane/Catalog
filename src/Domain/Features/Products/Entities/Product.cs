using Domain.Features.Products.Exceptions;
using Domain.Features.Products.ValueObjects;
using Domain.Shadred;
using Domain.Shadred.Helpers;

namespace Domain.Features.Products.Entities;

public sealed class Product : BaseEntity
{
    private Product() { }

    #region Fileds

    public string Name { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public decimal Price { get; private set; }

    public int AvailableStock { get; private set; } = 0;

    public string Slug { get; private set; } = null!;

    public ICollection<Media> Medias { get; private set; } = [];

    public Brand Brand { get; private set; } = null!;
    public int BrandId { get; private set; }

    public Category Category { get; private set; } = null!;
    public int CategoryId { get; private set; }

    #endregion

    #region Behaviors

    public void UpdateStock(int newQuantity)
    {
        if (newQuantity < 0)
            throw new ProductStockNegativeQuantityException(DomainErrors.ProductPriceLessThanOrEqualToZero);

        AvailableStock = newQuantity;
    }

    public void UpdatePrice(decimal price)
    {
        if (price <= 0)
            throw new ProductPriceLessThanOrEqualToZeroException(DomainErrors.ProductPriceLessThanOrEqualToZero);

        Price = price;
    }

    public void AddMedia(string name, string url)
    {
        Medias.Add(new Media(name, url));
    }

    #endregion

    #region Factory

    public static Product Create(string name, string description, int brandId, int categoryId, decimal price, int availableStock = default)
    {
        var newProduct = new Product()
        {
            Name = name,
            Description = description,
            BrandId = brandId,
            CategoryId = categoryId,
            Slug = name.ToSlug()
        };

        newProduct.UpdateStock(availableStock);
        newProduct.UpdatePrice(price);

        return newProduct;
    }

    #endregion
}
