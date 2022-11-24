using NetEscapades.Configuration.Validation;
using System.ComponentModel.DataAnnotations;

namespace GetandTake.Configuration.Settings;

public class DatabaseSettings : IValidatable
{
    public string DefaultConnection { get; set; }

    public void Validate()
    {
        Validator.ValidateObject(this, new ValidationContext(this), true);
    }
}
