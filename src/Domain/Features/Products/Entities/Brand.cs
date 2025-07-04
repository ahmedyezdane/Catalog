using System.Xml.Linq;
using Domain.Shadred;

namespace Domain.Features.Products.Entities;

public sealed class Brand : BaseEntity
{
    public string Name { get; private set; } = null!;

    public string LogoUrl { get; private set; } = null!;

    public ICollection<Product>? Products { get; set; }

    public void Update(string name) => Name = name;

    public static Brand Create(string name,string logoUrl)
    => new Brand
    {
        Name = name,
        LogoUrl = logoUrl
    };
}