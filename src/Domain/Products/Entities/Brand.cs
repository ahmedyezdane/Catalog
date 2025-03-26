using System.Xml.Linq;
using Domain.Shadred;

namespace Domain.Products.Entities;

public sealed class Brand : BaseEntity
{
    public string Name { get; private set; } = null!;

    public void Update(string name) => Name = name;

    public static Brand Create(string name)
    => new Brand
    {
        Name = name
    };
}