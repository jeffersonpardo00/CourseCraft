public class LessonService : ILessonService
{
    public async Task<Result<LessonResponse[]>> CreateLessonsPlan (
        StudentAIRequest student,
        IChatAIService chatAIService
    )
    {
        var result = await chatAIService.GetLessonsPlan(student);

        if (result.IsSuccess)
        {
            var mockLessons = new[]
                {
                    new LessonResponse(
                        1,
                        "Class 1",
                        "Math",
                        new DateTime(2023, 1, 1),
                        new LessonContent
                        {
                            Explanation = result.Value ?? "",
                            Strategies = "Explanation example"
                        },
                        0
                    )
                };

            return Result<LessonResponse[]>.Success(mockLessons);
        }
        else if (result.Error != null)
        {
            return Result<LessonResponse[]>.SetError(result.Error);
        }
        else
        {
            return Result<LessonResponse[]>.Internal();
        }
    }

    public async Task<Result<LessonResponse[]>> GetAllLessons(
        IChatAIService chatAIService
    ) {
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
                    )
                };

            return Result<LessonResponse[]>.Success(mockLessons);
    }

    
}