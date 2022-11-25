using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GetandTake.Models.DTOs.DetailDTO;

public class CategoryDetail
{
    [Required]
    [DisplayName("Category Name")]
    public string CategoryName { get; set; }

    [DisplayName("Description")]
    public string? Description { get; set; }

    [JsonIgnore]
    public byte[]? Picture { get; set; }

    [DisplayName("Image Path")]
    public string? ImagePath { get; set; }
}