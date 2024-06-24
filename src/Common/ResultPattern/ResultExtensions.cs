namespace Common.ResultPattern;

public static class ResultExtensions
{
    /// <summary>
    /// Matches the result and executes the appropriate function based on whether the result is a success or failure.
    /// </summary>
    /// <typeparam name="T">The return type of the success and failure functions.</typeparam>
    /// <param name="result">The result to match.</param>
    /// <param name="onSuccess">The function to execute if the result is a success.</param>
    /// <param name="onFailure">The function to execute if the result is a failure.</param>
    /// <returns>The result of executing the appropriate function.</returns>
    public static T Match<T>(
        this Result result,
        Func<T> onSuccess,
        Func<Error, T> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result.Error!);
    }

    /// <summary>
    /// Matches the result and executes the appropriate function based on whether the result is a success or failure.
    /// </summary>
    /// <typeparam name="T">The return type of the success and failure functions.</typeparam>
    /// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
    /// <param name="result">The result to match.</param>
    /// <param name="onSuccess">The function to execute if the result is a success.</param>
    /// <param name="onFailure">The function to execute if the result is a failure.</param>
    /// <returns>The result of executing the appropriate function.</returns>
    public static T Match<T, TValue>(
        this ResultT<TValue> result,
        Func<TValue, T> onSuccess,
        Func<Error, T> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error!);
    }
}
