namespace Common.ResultPattern;

/// <summary>
/// Represents an error in the application.
/// </summary>
public class Error
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> class.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <param name="errorType">The type of error.</param>
    private Error(
        string code,
        string description,
        ErrorType errorType
    )
    {
        Code = code;
        Description = description;
        ErrorType = errorType;
    }

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the error description.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the type of error.
    /// </summary>
    public ErrorType ErrorType { get; }

    /// <summary>
    /// Creates a new instance of <see cref="Error"/> with the specified code and description, representing a failure error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new instance of <see cref="Error"/>.</returns>
    public static Error Failure(string code, string description) =>
        new(code, description, ErrorType.Failure);

    /// <summary>
    /// Creates a new instance of <see cref="Error"/> with the specified code and description, representing a not found error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new instance of <see cref="Error"/>.</returns>
    public static Error NotFound(string code, string description) =>
        new(code, description, ErrorType.NotFound);

    /// <summary>
    /// Creates a new instance of <see cref="Error"/> with the specified code and description, representing a validation error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new instance of <see cref="Error"/>.</returns>
    public static Error Validation(string code, string description) =>
        new(code, description, ErrorType.Validation);

    /// <summary>
    /// Creates a new instance of <see cref="Error"/> with the specified code and description, representing a conflict error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new instance of <see cref="Error"/>.</returns>
    public static Error Conflict(string code, string description) =>
        new(code, description, ErrorType.Conflict);

    /// <summary>
    /// Creates a new instance of <see cref="Error"/> with the specified code and description, representing an access unauthorized error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new instance of <see cref="Error"/>.</returns>
    public static Error AccessUnAuthorized(string code, string description) =>
        new(code, description, ErrorType.AccessUnAuthorized);

    /// <summary>
    /// Creates a new instance of <see cref="Error"/> with the specified code and description, representing an access forbidden error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new instance of <see cref="Error"/>.</returns>
    public static Error AccessForbidden(string code, string description) =>
        new(code, description, ErrorType.AccessForbidden);
}
