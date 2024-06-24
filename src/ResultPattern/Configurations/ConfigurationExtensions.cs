namespace ResultPattern.Configurations;

public static class ConfigurationExtensions
{
    public static ConfigurationResponse ToDto(
        this Configuration configuration
    )
    {
        return new ConfigurationResponse(
            configuration.Key,
            configuration.Value,
            configuration.Description
        );
    }
}
