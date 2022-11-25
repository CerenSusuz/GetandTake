using NetEscapades.Configuration.Validation;

namespace GetandTake.Configuration.Settings;

public class AppSettings : IValidatable
{
    public DatabaseSettings Database { get; set; }

    public ProductsSettings Products { get; set; }

    public HostSettings Host { get; set; }

    public LogFilterSettings LoggingParameters { get; set; }

    public void Validate()
    {
        Database.Validate();
        Products.Validate();
        Host.Validate();
        LoggingParameters.Validate();
    }
}