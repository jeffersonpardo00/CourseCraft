public enum ResultErrorType
{
    NotFound,
    Conflict,
    Validation
}

public class ResultError
{
    public ResultErrorType Type { get; }
    public string Message { get; }

    public IDictionary<string, string[]> ValidationErrors { get; }

    public ResultError(ResultErrorType type, string message)
    {
        Type = type;
        Message = message;
    }
}