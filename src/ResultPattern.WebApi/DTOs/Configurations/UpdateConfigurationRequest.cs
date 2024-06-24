namespace ResultPattern.WebApi.DTOs.Configurations;

public record UpdateConfigurationRequest(
    string Key,
    string Value,
    string Description
);
