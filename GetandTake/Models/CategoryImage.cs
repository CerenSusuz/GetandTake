using GetandTake.Core.Models;

namespace GetandTake.Models;

public class CategoryImage : BaseEntity
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string ImagePath { get; set; }
}
