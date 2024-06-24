using Common.ResultPattern;

using ResultPattern.WebApi.DTOs.Configurations;

namespace ResultPattern.WebApi.Services;

public interface IConfigurationService
{
    /// <summary>
    /// Retrieves all configurations asynchronously.
    /// </summary>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<ResultT<IEnumerable<ConfigurationResponse>>> GetAsync(CancellationToken ct);

    /// <summary>
    /// Retrieves a configuration by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the configuration to retrieve.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<ResultT<ConfigurationResponse>> GetByIdAsync(Guid id, CancellationToken ct);

    /// <summary>
    /// Adds a new configuration asynchronously.
    /// </summary>
    /// <param name="request">The request containing the configuration data.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<ResultT<ConfigurationResponse>> AddAsync(CreateConfigurationRequest request, CancellationToken ct);

    /// <summary>
    /// Updates a configuration asynchronously.
    /// </summary>
    /// <param name="id">The ID of the configuration to update.</param>
    /// <param name="request">The request containing the updated configuration data.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<Result> UpdateAsync(Guid id, UpdateConfigurationRequest request, CancellationToken ct);

    /// <summary>
    /// Deletes a configuration asynchronously.
    /// </summary>
    /// <param name="id">The ID of the configuration to delete.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<Result> DeleteAsync(Guid id, CancellationToken ct);
}
