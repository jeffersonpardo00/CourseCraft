using System.Text.Json;

public class LessonService : ILessonService
{
    public async Task<Result<LessonResponse[]>> CreateLessonsPlan (
        StudentAIRequest student,
        IChatAIService chatAIService
    )
    {
        var result = await chatAIService.GetLessonsPlan(student);
        string Explanation = "";
        string Strategies = "";

        // Parse into a dynamic JSON document structure
        if(result.Value != null)
        {
            using (JsonDocument doc = JsonDocument.Parse(result.Value))
            {
                JsonElement root = doc.RootElement;
                Explanation = root.GetProperty("Explanation").GetString()??"";
                Strategies = root.GetProperty("Strategies").GetString()??"";
                Console.WriteLine($"Explanation: {Explanation}, Strategies: {Strategies}");
            }
        }
        
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
                            Explanation = Explanation,
                            Strategies = Strategies
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