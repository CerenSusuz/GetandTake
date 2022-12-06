using NetEscapades.Configuration.Validation;
using System.ComponentModel.DataAnnotations;

namespace GetandTake.Configuration.Settings;

public class DatabaseSettings : IValidatable
{
    [Required]
    public string DefaultConnection { get; set; }

    public void Validate()
    {
        Validator.ValidateObject(instance: this,
            new ValidationContext(this),
            validateAllProperties: true);
    }
}