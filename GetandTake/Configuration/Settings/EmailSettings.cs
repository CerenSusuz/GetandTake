using NetEscapades.Configuration.Validation;
using System.ComponentModel.DataAnnotations;

namespace GetandTake.Configuration.Settings;

public class EmailSettings : IValidatable
{
    [Required]
    public string From { get; set; }

    public string SmtpServer { get; set; }

    public int Port { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public void Validate()
    {
        Validator.ValidateObject(this, new ValidationContext(this), true);
    }
}
