using Domain.Shadred;

namespace Domain.Features.Products.Entities;

public sealed class Category : BaseEntity
{
    #region Fileds

    public string Name { get; private set; } = null!;

    public int? ParentId { get; private set; }
    public Category Parent { get; private set; } = null!;

    public ICollection<Category> Children { get; private set; } = null!;
    #endregion

    #region Behaviors

    public string? Path => GetPath(this);

    private string? GetPath(Category category)
    {
        if (category.Parent is not null)
            return $"{GetPath(category.Parent)}/{category.Name}";

        if (category.Id == Id)
            return null;

        return category.Name;
    }

    public void Update(string name)
    {
        Name = name;
    }

    #endregion

    #region Factory

    public static Category Create(string name, int? parentId)
    => new Category
    {
        Name = name,
        ParentId = parentId
    };

    #endregion
}
