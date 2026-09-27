public class LessonService : ILessonService
{
    public async Task<Result<LessonResponse[]>> GetAllLessons()
    {
        await Task.Delay(500);

        var mockLessons = new[]
        {
            new LessonResponse(
                1,
                "Class 1",
                "Math",
                new DateTime(2023, 1, 1),
                new LessonContent
                {
                    Explanation = "Explanation example",
                    Strategies = "Explanation example"
                },
                0
            ),
          };

        return Result<LessonResponse[]>.Success(mockLessons);
    }
}