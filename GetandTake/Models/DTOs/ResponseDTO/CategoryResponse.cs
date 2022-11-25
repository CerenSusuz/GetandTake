using System.Text.Json.Serialization;

namespace GetandTake.Models.DTOs.ResponseDTO;

public class CategoryResponse
{
    public int CategoryID { get; set; }

    public string CategoryName { get; set; }

    [JsonIgnore]
    public byte[]? Picture { get; set; }

    public string? Description { get; set; }

    public string? ImagePath { get; set; }
}