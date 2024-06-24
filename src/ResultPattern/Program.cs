using System.Text.Json;

using Common.ResultPattern;

using ResultPattern.Configurations;

// Get By Id with success
var getByIdResult = GetByIdWithSuccess(Guid.NewGuid());
Console.WriteLine($"GetByIdWithSuccess: {getByIdResult.IsSuccess}, {(getByIdResult.IsSuccess ? getByIdResult.Value : JsonSerializer.Serialize(getByIdResult.Error))}");

// Get By Id with failure
var getByIdWihFailureResult = GetByIdWithFailure(Guid.NewGuid());
Console.WriteLine($"GetByIdWithFailure: {getByIdWihFailureResult.IsSuccess}, {(getByIdWihFailureResult.IsSuccess ? getByIdWihFailureResult.Value : JsonSerializer.Serialize(getByIdWihFailureResult.Error))}");

// Create with success
var createdResult = CreateWithSuccess();
Console.WriteLine($"CreateWithSuccess: {createdResult.IsSuccess}, {(createdResult.IsSuccess ? createdResult.Value : JsonSerializer.Serialize(createdResult.Error))}");

// Create with failure
var createdWithFailureResult = CreateWithFailure();
Console.WriteLine($"CreateWithFailure: {createdWithFailureResult.IsSuccess}, {(createdWithFailureResult.IsSuccess ? createdWithFailureResult.Value : JsonSerializer.Serialize(createdWithFailureResult.Error))}");

// Create with conflict failure
var createdWithConflictFailureResult = CreateWithConflictFailure();
Console.WriteLine($"createdWithConflictFailureResult: {createdWithConflictFailureResult.IsSuccess}, {(createdWithConflictFailureResult.IsSuccess ? createdWithConflictFailureResult.Value : JsonSerializer.Serialize(createdWithConflictFailureResult.Error))}");

// Update with success
var updatedResult = UpdateWithSuccess();
Console.WriteLine($"UpdateWithSuccess: {updatedResult.IsSuccess}, {(updatedResult.IsSuccess ? "No Content" : JsonSerializer.Serialize(updatedResult.Error))}");

// Update with failure
var updatedWithFailureResult = UpdateWithFailure();
Console.WriteLine($"UpdateWithFailure: {updatedWithFailureResult.IsSuccess}, {(updatedWithFailureResult.IsSuccess ? "No Content" : JsonSerializer.Serialize(updatedWithFailureResult.Error))}");

// Dummy method to mock to Get By Id with success response
static ResultT<ConfigurationResponse> GetByIdWithSuccess(
    Guid id
)
{
    // Configuration found from data source
    var configuration = new Configuration
    {
        Id = id,
        Key = "Key",
        Value = "Value",
        Description = "Description"
    };

    // Map the entity to Dto
    return configuration.ToDto();
}

// Dummy method to mock to Get By Id with failure response - NotFound
static ResultT<ConfigurationResponse> GetByIdWithFailure(
    Guid id
)
{
    // Configuration not found from data source
    return ConfigurationErrors.NotFound(id.ToString());
}

// Dummy method to mock to create with success response
static ResultT<ConfigurationResponse> CreateWithSuccess()
{
    // Configuration created successfully
    var configuration = new Configuration
    {
        Id = Guid.NewGuid(),
        Key = "Key",
        Value = "Value",
        Description = "Description"
    };

    // Map the entity to Dto
    return configuration.ToDto();
}

// Dummy method to mock to create with failure response - CreateFailure
static ResultT<ConfigurationResponse> CreateWithFailure()
{
    // Error in creating configuration
    return ConfigurationErrors.CreateFailure;
}

// Dummy method to mock to create with failure response - Conflict
static ResultT<ConfigurationResponse> CreateWithConflictFailure()
{
    // Error in creating configuration as configuration with same key already exists
    return ConfigurationErrors.Conflict("Key");
}

// Dummy method to mock to update with success response
static Result UpdateWithSuccess()
{
    // Configuration updated successfully
    return Result.Success();
}

// Dummy method to mock to update with failure response - UpdateFailure
static Result UpdateWithFailure()
{
    // Error in updating configuration
    return ConfigurationErrors.UpdateFailure;
}
