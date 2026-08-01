public interface ISessionService
{
    public Task<Result<SessionResponse[]>> GetAllSessions();
}