namespace ResultPattern.WebApi.Entities;

public class Configuration
{
    public Guid Id { get; init; }
    public required string Key { get; init; }
    public required string Value { get; init; }
    public required string Description { get; init; }
}
