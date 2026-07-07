public sealed class Result<T>
{
    public T? Value { get; }
    public ResultError? Error { get; }
    public bool IsSuccess => Error is null;

    private Result(T value) => Value = value;
    private Result(ResultError error) => Error = error;

    public static Result<T> Success(T value) => new(value);
    public static Result<T> NotFound(string message = "Resource not found.") =>
        new(new ResultError(ResultErrorType.NotFound, message));
    public static Result<T> Conflict(string message) =>
        new(new ResultError(ResultErrorType.Conflict, message));
}

public static class ResultExtensions
{
    public static IResult ToHttpResult<T>(this Result<T> result)
    {
         if (result.IsSuccess)
        return Results.Ok(result.Value);

    return result.Error!.Type switch
    {
        ResultErrorType.NotFound    => Results.NotFound(),
        ResultErrorType.Conflict    => Results.Conflict(result.Error.Message),
        ResultErrorType.Validation  => Results.ValidationProblem(result.Error.ValidationErrors!),
        _                           => Results.StatusCode(500)
    };
    }
}