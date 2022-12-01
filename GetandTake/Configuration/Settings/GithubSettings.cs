using NetEscapades.Configuration.Validation;
using System.ComponentModel.DataAnnotations;

namespace GetandTake.Configuration.Settings;

public class GithubSettings : IValidatable
{
    public string ClientId { get; set; }

    public string ClientSecret { get; set; }

    public string CallbackPath { get; set; }

    public void Validate()
    {
        Validator.ValidateObject(this, new ValidationContext(this), true);
    }
}
