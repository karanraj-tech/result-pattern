using Common.ResultPattern;

using ResultPattern.WebApi.DTOs.Configurations;
using ResultPattern.WebApi.Entities;
using ResultPattern.WebApi.Errors;

namespace ResultPattern.WebApi.Services;

public class ConfigurationService : IConfigurationService
{

    public async Task<ResultT<IEnumerable<ConfigurationResponse>>> GetAsync(CancellationToken ct)
    {
        List<Configuration> configurations = [
            new Configuration
            {
                Id = Guid.NewGuid(),
                Key = "Key1",
                Value = "Value1",
                Description = "Description1"
            },
            new Configuration
            {
                Id = Guid.NewGuid(),
                Key = "Key2",
                Value = "Value2",
                Description = "Description2"
            },
        ];

        // To mock the computation delay
        await Task.Delay(1000, ct);

        return configurations.ToDto();
    }

    public async Task<ResultT<ConfigurationResponse>> GetByIdAsync(Guid id, CancellationToken ct)
    {
        Configuration? configuration = null;

        // To mock the 50% success response, and 50% failure response
        if (new Random().Next(2) == 0)
        {
            configuration = new Configuration
            {
                Id = Guid.NewGuid(),
                Key = "Key1",
                Value = "Value1",
                Description = "Description1"
            };
        }

        // To mock the computation delay
        await Task.Delay(1000, ct);

        if (configuration is null)
        {
            return ConfigurationErrors.NotFound(id.ToString());
        }
        return configuration.ToDto();
    }

    public async Task<ResultT<ConfigurationResponse>> AddAsync(CreateConfigurationRequest request, CancellationToken ct)
    {
        var configurationExist = await IsConfigurationExistsAsync(request, ct);

        if (configurationExist)
        {
            return ConfigurationErrors.Conflict(request.Key.ToString());
        }

        var resultOfCreateConfiguration = await SaveChangesAsync(request.ToEntity(), ct);

        if (!resultOfCreateConfiguration)
        {
            return ConfigurationErrors.CreateFailure;
        }

        var configuration = new Configuration
        {
            Id = Guid.NewGuid(),
            Key = "Key1",
            Value = "Value1",
            Description = "Description1"
        };

        return configuration.ToDto();

    }

    public async Task<Result> UpdateAsync(Guid id, UpdateConfigurationRequest request, CancellationToken ct)
    {
        Configuration? configuration = null;

        // To mock the 25% success response, and 25% failure response
        if (new Random().Next(4) > 0)
        {
            configuration = new Configuration
            {
                Id = Guid.NewGuid(),
                Key = "Key1",
                Value = "Value1",
                Description = "Description1"
            };
        }

        // To mock the computation delay
        await Task.Delay(1000, ct);

        if (configuration is null)
        {
            return ConfigurationErrors.NotFound(id.ToString());
        }

        var resultOfUpdateConfiguration = await SaveChangesAsync(request.ToEntity(id), ct);

        if (!resultOfUpdateConfiguration)
        {
            return ConfigurationErrors.UpdateFailure;
        }

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(Guid id, CancellationToken ct)
    {
        Configuration? configuration = null;

        // To mock the 50% success response, and 50% failure response
        if (new Random().Next(2) == 0)
        {
            configuration = new Configuration
            {
                Id = Guid.NewGuid(),
                Key = "Key1",
                Value = "Value1",
                Description = "Description1"
            };
        }

        // To mock the computation delay
        await Task.Delay(1000, ct);

        if (configuration is null)
        {
            return ConfigurationErrors.NotFound(id.ToString());
        }

        var resultOfDeleteConfiguration = await SaveChangesAsync(configuration, ct);

        if (!resultOfDeleteConfiguration)
        {
            return ConfigurationErrors.DeleteFailure;
        }

        return Result.Success();
    }


    /// <summary>
    /// Dummy method to check if a configuration exists or not. if key is Test it will return true.
    /// </summary>
    /// <param name="request">The request containing the configuration key.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the configuration exists.</returns>
    private static async Task<bool> IsConfigurationExistsAsync(
        CreateConfigurationRequest request,
        CancellationToken ct)
    {
        // To mock the computation delay
        await Task.Delay(1000, ct);

        return request.Key == "Test";
    }


    /// <summary>
    /// Dummy method Saves the changes. If the key is Test1 it will save it successfully. 
    /// </summary>
    /// <param name="configuration">The configuration to save.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the changes was saved successfully.</returns>
    private static async Task<bool> SaveChangesAsync(
        Configuration configuration,
        CancellationToken ct)
    {
        // To mock the computation delay
        await Task.Delay(1000, ct);

        return configuration.Key == "Test1";
    }
}
