﻿using GetandTake.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GetandTake.Models;

public class Category : BaseEntity
{
    public int CategoryID { get; set; }

    [Required]
    public string CategoryName { get; set; }

    public string? Description { get; set; }

    [JsonIgnore]
    public byte[]? Picture { get; set; }

    public string? ImagePath { get; set; }

    [JsonIgnore]
    public ICollection<Product> Products { get; set; }
}
