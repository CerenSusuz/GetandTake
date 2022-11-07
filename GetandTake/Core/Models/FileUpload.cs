using System.ComponentModel.DataAnnotations;

namespace GetandTake.Core.Models;

public class FileUpload
{
    [Required]
    [Display(Name = "File")]
    public IFormFile FormFile { get; set; }
}
