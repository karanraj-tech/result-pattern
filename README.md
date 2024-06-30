# 📝 Result Pattern in .NET and C#

This repository provides an explanation of the Result pattern in .NET and C#, along with code examples to illustrate its usage. Let's dive in! 🚀

## 📚 What is the Result Pattern?

The Result pattern is a design pattern commonly used to handle operations that can either succeed or fail. It provides a structured way to represent the outcome of an operation, allowing developers to handle both successful and error scenarios in a consistent manner.

## 💡 Why use the Result Pattern?

By using the Result pattern, you can improve the clarity and maintainability of your code. It helps to avoid exceptions for expected error scenarios and promotes a more explicit and predictable flow of control. Additionally, it enables better error handling and provides a clear separation between the happy path and error handling logic.

## 🛠️ How to use the Result Pattern?

To use the Result pattern, you typically define a custom `Result` type that encapsulates the outcome of an operation. This `Result` type can contain properties such as `IsSuccess`, `Error`, and `Value` to represent the success status, error (if any), and the result value (if successful) respectively.

Here's an example of how the Result pattern can be implemented in C#:

1. Define Error types

   First, define an enumeration for different types of errors.

```csharp
public enum ErrorType
{
    Failure = 0,
    NotFound = 1,
    Validation = 2,
    Conflict = 3,
    AccessUnAuthorized = 4,
    AccessForbidden = 5
}
```

2. Create an Error Class

   This class will encapsulate error details.

```csharp
public class Error
{
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

    public string Code { get; }

    public string Description { get; }

    public ErrorType ErrorType { get; }

    public static Error Failure(string code, string description) =>
        new(code, description, ErrorType.Failure);

    public static Error NotFound(string code, string description) =>
        new(code, description, ErrorType.NotFound);

    public static Error Validation(string code, string description) =>
        new(code, description, ErrorType.Validation);

    public static Error Conflict(string code, string description) =>
        new(code, description, ErrorType.Conflict);

    public static Error AccessUnAuthorized(string code, string description) =>
        new(code, description, ErrorType.AccessUnAuthorized);

    public static Error AccessForbidden(string code, string description) =>
        new(code, description, ErrorType.AccessForbidden);
}
```

3. Implement the Result Class

   This class represents the outcome of an operation.

```csharp
public class Result
{
    protected Result()
    {
        IsSuccess = true;
        Error = default;
    }

    protected Result(Error error)
    {
        IsSuccess = false;
        Error = error;
    }

    public bool IsSuccess { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Error? Error { get; }

    public static implicit operator Result(Error error) =>
        new(error);

    public static Result Success() =>
        new();

    public static Result Failure(Error error) =>
        new(error);
}
```

4. Implement the ResultT Class for Generic Results

   This class handles results that contain a value.

```csharp
public sealed class ResultT<TValue> : Result
{
    private readonly TValue? _value;

    private ResultT(
        TValue value
    ) : base()
    {
        _value = value;
    }

    private ResultT(
        Error error
    ) : base(error)
    {
        _value = default;
    }

    public TValue Value =>
        IsSuccess ? _value! : throw new InvalidOperationException("Value can not be accessed when IsSuccess is false");

    public static implicit operator ResultT<TValue>(Error error) =>
        new(error);

    public static implicit operator ResultT<TValue>(TValue value) =>
        new(value);

    public static ResultT<TValue> Success(TValue value) =>
        new(value);

    public static new ResultT<TValue> Failure(Error error) =>
        new(error);
}

```

5. Add Extension Methods for Result Matching

   These methods help in handling results seamlessly.

```csharp
public static class ResultExtensions
{
    public static T Match<T>(
        this Result result,
        Func<T> onSuccess,
        Func<Error, T> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result.Error!);
    }

    public static T Match<T, TValue>(
        this ResultT<TValue> result,
        Func<TValue, T> onSuccess,
        Func<Error, T> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error!);
    }
}
```

## 💻 Examples

Here are a few examples to demonstrate the usage of the Result pattern:

- Performing a database query to get Configuration by Id:

```csharp
public async Task<ResultT<ConfigurationResponse>> GetByIdAsync(Guid id, CancellationToken ct)
{
    // Fetch configuration from the DB
    Configuration? configuration = await repository.GetById(id, ct);

    if (configuration is null)
    {
        return ResultT<ConfigurationResponse>.Failure(ConfigurationErrors.NotFound(id.ToString()));
    }
    return ResultT<ConfigurationResponse>.Success(configuration.ToDto());
}
```

- Performing a database query to get Configuration by Id with use of implicit operator:

```csharp
public async Task<ResultT<ConfigurationResponse>> GetByIdAsync(Guid id, CancellationToken ct)
{
    // Fetch configuration from the DB
    Configuration? configuration = await repository.GetById(id, ct);

    if (configuration is null)
    {
        return ConfigurationErrors.NotFound(id.ToString());
    }
    return configuration.ToDto();
}
```

- Handling Result in an API Endpoint:

```csharp
public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
{
    var result = await configurationService.GetByIdAsync(id, ct);

    if (result.IsSuccess)
    {
        return Ok(result.Value);
    }
    return Problem(result.Error!);
}
```

- Handling Result in an API Endpoint using the Match extension Method:

```csharp
public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
{
    var result = await configurationService.GetByIdAsync(id, ct);

    return result.Match(
        onSuccess: Ok,
        onFailure: Problem
    );
}
```

## 🏁 Conclusion

The Result pattern is a powerful tool for handling success and error scenarios in .NET and C#. By adopting this pattern, you can write more robust and maintainable code that is easier to understand and debug.

🌟 Start using the Result pattern in your projects today and experience the benefits it brings!
