using Common.ResultPattern;

using Microsoft.AspNetCore.Mvc;

using ResultPattern.WebApi.DTOs.Configurations;
using ResultPattern.WebApi.Services;

namespace ResultPattern.WebApi.Controllers;

/// <summary>
/// Represents a Configurations controller.
/// </summary>
[Route("configurations")]
public class ConfigurationsController(
    IConfigurationService configurationService)
    : BaseController
{
    /// <summary>
    /// Retrieves all configurations.
    /// </summary>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the operation.</returns>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var result = await configurationService.GetAsync(ct);

        return result.Match(
            onSuccess: Ok,
            onFailure: Problem
        );
    }

    /// <summary>
    /// Retrieves a configuration by its ID.
    /// </summary>
    /// <param name="id">The ID of the configuration to retrieve.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the operation.</returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var result = await configurationService.GetByIdAsync(id, ct);

        return result.Match(
            onSuccess: Ok,
            onFailure: Problem
        );
    }

    /// <summary>
    /// Deletes a configuration by its ID.
    /// </summary>
    /// <param name="id">The ID of the configuration to delete.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the operation.</returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await configurationService.DeleteAsync(id, ct);

        return result.Match(
            onSuccess: NoContent,
            onFailure: Problem
        );
    }

    /// <summary>
    /// Updates a configuration by its ID.
    /// </summary>
    /// <param name="id">The ID of the configuration to update.</param>
    /// <param name="request">The updated configuration data.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the operation.</returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateConfigurationRequest request, CancellationToken ct)
    {
        var result = await configurationService.UpdateAsync(id, request, ct);

        return result.Match(
            onSuccess: NoContent,
            onFailure: Problem
        );
    }

    /// <summary>
    /// Creates a new configuration.
    /// </summary>
    /// <param name="request">The configuration data to create.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the operation.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateConfigurationRequest request, CancellationToken ct)
    {
        var result = await configurationService.AddAsync(request, ct);

        return result.Match(
            onSuccess: () => CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { id = result.Value.Id },
                value: result.Value
            ),
            onFailure: Problem
        );
    }
}
