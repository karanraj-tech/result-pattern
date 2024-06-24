using ResultPattern.WebApi.Entities;

namespace ResultPattern.WebApi.DTOs.Configurations;

public static class ConfigurationExtensions
{
    /// <summary>
    /// Converts a <see cref="Configuration"/> object to a <see cref="ConfigurationResponse"/> object.
    /// </summary>
    /// <param name="configuration">The <see cref="Configuration"/> object to convert.</param>
    /// <returns>A <see cref="ConfigurationResponse"/> object.</returns>
    public static ConfigurationResponse ToDto(
        this Configuration configuration
    )
    {
        return new ConfigurationResponse(
            Id: configuration.Id.ToString(),
            Key: configuration.Key,
            Value: configuration.Value,
            Description: configuration.Description
        );
    }

    /// <summary>
    /// Converts a list of <see cref="Configuration"/> objects to a list of <see cref="ConfigurationResponse"/> objects.
    /// </summary>
    /// <param name="configurations">The list of <see cref="Configuration"/> objects to convert.</param>
    /// <returns>A list of <see cref="ConfigurationResponse"/> objects.</returns>
    public static List<ConfigurationResponse> ToDto(
        this List<Configuration> configurations
    )
    {
        return configurations
            .Select(ToDto)
            .ToList();
    }

    /// <summary>
    /// Converts a <see cref="CreateConfigurationRequest"/> object to a <see cref="Configuration"/> object.
    /// </summary>
    /// <param name="request">The <see cref="CreateConfigurationRequest"/> object to convert.</param>
    /// <returns>A <see cref="Configuration"/> object.</returns>
    public static Configuration ToEntity(
        this CreateConfigurationRequest request
    )
    {
        return new Configuration
        {
            Id = Guid.NewGuid(),
            Key = request.Key,
            Value = request.Value,
            Description = request.Description
        };
    }

    /// <summary>
    /// Converts a <see cref="UpdateConfigurationRequest"/> object to a <see cref="Configuration"/> object.
    /// </summary>
    /// <param name="request">The <see cref="UpdateConfigurationRequest"/> object to convert.</param>
    /// <param name="id">The ID of the <see cref="Configuration"/> object.</param>
    /// <returns>A <see cref="Configuration"/> object.</returns>
    public static Configuration ToEntity(
        this UpdateConfigurationRequest request,
        Guid id
    )
    {
        return new Configuration
        {
            Id = id,
            Key = request.Key,
            Value = request.Value,
            Description = request.Description
        };
    }
}
