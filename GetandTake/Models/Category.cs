using GetandTake.Core.Models;

namespace GetandTake.Models;

public class Category : BaseEntity
{
    public int CategoryID { get; set; }

    public string CategoryName { get; set; }

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public ICollection<Product>? Products { get; set; }

    public ICollection<CategoryImage>? Images { get; set; }
}
