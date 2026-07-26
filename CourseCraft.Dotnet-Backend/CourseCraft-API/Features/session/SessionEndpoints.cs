public static class SessionEndpoints
{
     public static void MapStudentsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/session").WithTags("Sessions");
    }

    private static async Task<IResult> GetAllSessions(IStudentService service)
    {
        var result = await service.GetAllSessions(id);
        return result.ToHttpResult();
    }


}