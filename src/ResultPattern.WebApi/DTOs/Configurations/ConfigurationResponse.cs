namespace ResultPattern.WebApi.DTOs.Configurations;

public record ConfigurationResponse(
    string Id,
    string Key,
    string Value,
    string Description
);
