public static class SessionEndpoints
{
     public static void MapStudentsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/session").WithTags("Sessions");
        group.MapGet("/", GetAllSessions);
    }

    private static async Task<IResult> GetAllSessions(ISessionService service)
    {
        var result = await service.GetAllSessions();
        return result.ToHttpResult();
    }

}