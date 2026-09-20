public static class LessonEndpoints
{
    public static void MapLessonEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/lesson").WithTags("Lessons");
        group.MapGet("/", GetAllLessons);
    }

    private static async Task<IResult> GetAllLessons(ILessonService service)
    {
        var result = await service.GetAllLessons();
        return result.ToHttpResult();
    }
}