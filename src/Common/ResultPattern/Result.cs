using System.Text.Json.Serialization;

namespace Common.ResultPattern;

/// <summary>
/// Represents the result of an operation that can either be successful or contain an error.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class representing a successful result.
    /// </summary>
    protected Result()
    {
        IsSuccess = true;
        Error = default;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class representing a failed result with an error.
    /// </summary>
    /// <param name="error">The error associated with the failed result.</param>
    protected Result(Error? error)
    {
        IsSuccess = false;
        Error = error;
    }

    /// <summary>
    /// Gets a value indicating whether the result is successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets the error associated with the result, if any.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Error? Error { get; }

    /// <summary>
    /// Implicitly converts an <see cref="Error"/> to a <see cref="Result"/> representing a failed result.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    /// <returns>A new instance of <see cref="Result"/> representing a failed result with the specified error.</returns>
    public static implicit operator Result(Error error) =>
        new(error);

    /// <summary>
    /// Creates a new instance of <see cref="Result"/> representing a successful result.
    /// </summary>
    /// <returns>A new instance of <see cref="Result"/> representing a successful result.</returns>
    public static Result Success() =>
        new();

    /// <summary>
    /// Creates a new instance of <see cref="Result"/> representing a failed result with the specified error.
    /// </summary>
    /// <param name="error">The error associated with the failed result.</param>
    /// <returns>A new instance of <see cref="Result"/> representing a failed result with the specified error.</returns>
    public static Result Failure(Error error) =>
        new(error);
}
