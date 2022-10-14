
using GetandTake.Models.BaseModels;

namespace GetandTake.Models
{
    public class Category : IBaseEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        //public byte? Picture { get; set; }
    }
}
