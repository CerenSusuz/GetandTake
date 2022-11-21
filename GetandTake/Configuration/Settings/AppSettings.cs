namespace GetandTake.Configuration.Settings;

public class AppSettings
{
    public DatabaseSettings Database { get; set; }

    public ProductsSettings Products { get; set; }

    public HostSettings Host { get; set; }

    public LogFilterSettings LogFilter { get; set; }
}