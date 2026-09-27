public static class LessonEndpoints
{
    public static void MapLessonEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/lesson").WithTags("Lessons");
        group.MapGet("/", GetAllLessons);
    }

    private static async Task<IResult> GetAllLessons(
        ILessonService service,
        IChatAIService chatAIService
    )
    {
        var result = await service.GetAllLessons(chatAIService);
        return result.ToHttpResult();
    }
}