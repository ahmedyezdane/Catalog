using Domain.Features.Products.Exceptions;
using Domain.Features.Products.ValueObjects;
using Domain.Shadred;

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

    public void AddStock(int quantity)
    {
        if (quantity <= 0)
            throw new NegativeQuantityException();

        AvailableStock += quantity;
    }

    public void RemoveStock(int quantity)
    {
        if (AvailableStock - quantity < 0)
            throw new NegativeQuantityException();

        AvailableStock -= quantity;
    }

    public void UpdatePrice(int price)
    {
        if (price <= 0)
            throw new PriceGreaterThanZeroException();

        Price = price;
    }

    public void AddMedia(string name, string url)
    {
        Medias.Add(new Media(name, url));
    }

    #endregion

    #region Factory

    public static Product Create(string name, string description, int brandId, int categoryId, decimal price = default, int availableStock = default)
    {
        var newProduct = new Product()
        {
            Name = name,
            Description = description,
            BrandId = brandId,
            CategoryId = categoryId,
            Price = price,
            Slug = name.ToString() //TODO: replace with .ToSlug() 
        };

        newProduct.AddStock(availableStock);

        return newProduct;
    }

    #endregion
}
