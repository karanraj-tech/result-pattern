namespace ResultPattern.WebApi.DTOs.Configurations;

public record CreateConfigurationRequest(
    string Key,
    string Value,
    string Description
);
