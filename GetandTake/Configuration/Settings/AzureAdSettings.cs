using NetEscapades.Configuration.Validation;
using System.ComponentModel.DataAnnotations;

namespace GetandTake.Configuration.Settings;

public class AzureAdSettings : IValidatable
{
    public string Instance { get; set; }

    public string Domain { get; set; }

    public string ClientId { get; set; }

    public string TenantId { get; set; }

    public string SecretId { get; set; }

    public string CallbackPath { get; set; }

    public void Validate()
    {
        Validator.ValidateObject(instance: this,
            new ValidationContext(this),
            validateAllProperties: true);
    }
}