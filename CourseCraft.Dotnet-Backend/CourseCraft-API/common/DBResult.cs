public sealed class DBResult<T>
{
    public T? Value { get; }
    public DBError? Error { get; }
    public bool IsSuccess => Error is null;
    private DBResult(T value) => Value = value;
    private DBResult(DBError error) => Error = error;
    public static DBResult<T> Success(T value) => new(value);
    public static DBResult<T> Unavailable(string message = "Resource not found.") =>
        new(new DBError(DBErrorType.Unavailable, message));
    public static DBResult<T> NullReceived(string message = "Null Received.") =>
        new(new DBError(DBErrorType.NullReceived, message));
    public static DBResult<T> NullParameters(string message = "Null parameter sent.") =>
        new(new DBError(DBErrorType.NullParameters, message));
    public static DBResult<T> DBInternalError(string message = "Internal error in data base.") =>
        new(new DBError(DBErrorType.DBInternalError, message));
    
}

public enum DBErrorType
{
    Unavailable,
    NullReceived,
    NullParameters,
    DBInternalError

}

public class DBError
{
    public DBErrorType Type { get; }
    public string Message { get; }
    public IDictionary<string, string[]> ValidationErrors { get; }
    public DBError(DBErrorType type, string message) : this(type, message, new Dictionary<string, string[]>())
    {
    }

    public DBError (DBErrorType type, string message, IDictionary<string, string[]> validationErrors)
    {
        Type = type;
        Message = message;
        ValidationErrors = validationErrors ?? new Dictionary<string, string[]>();
    }
}