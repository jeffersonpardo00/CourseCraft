public enum ResultErrorType
{
    NotFound,
    Conflict,
    Validation,
    Unavailable,
    Internal
}

public class ResultError
{
    public ResultErrorType Type { get; }
    public string Message { get; }
    public IDictionary<string, string[]> ValidationErrors { get; }
    public ResultError(ResultErrorType type, string message)
        : this(type, message, new Dictionary<string, string[]>())
    {
    }

    public ResultError(ResultErrorType type, string message, IDictionary<string, string[]> validationErrors)
    {
        Type = type;
        Message = message;
        ValidationErrors = validationErrors ?? new Dictionary<string, string[]>();
    }
}