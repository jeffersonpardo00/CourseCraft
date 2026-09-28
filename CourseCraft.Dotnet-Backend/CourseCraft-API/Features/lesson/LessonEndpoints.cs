public static class LessonEndpoints
{
    public static void MapLessonEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/lesson").WithTags("Lessons");
        group.MapGet("/", GetAllLessons);
        group.MapPost("/create",CreateLessonPlan);
    }
    private static async Task<IResult> GetAllLessons(
        ILessonService service,
        IChatAIService chatAIService
    )
    {
        var result = await service.GetAllLessons(chatAIService);
        return result.ToHttpResult();
    }

    private static async Task<IResult> CreateLessonPlan (
        //Student student,
        ILessonService service,
        IChatAIService chatAIService
    )
    {
        var mockStudent = new Student
        {
            Id = 1,
            FirstName = "Molley",
            LastName = "Smith",
            Email = "molie.mol@gmail.com",
            BirthDate = new DateTime(2016, 1, 1),
            LearningLevel = 2,
            Interests = [
                new Interest {Id=0, Text= "drawing"}, 
                new Interest {Id=1, Text= "basketball"}, 
                
            ],
            Notes = [
                new Note {
                    Id=0, 
                    Text= "she is still struggling with addition"
                }, 
            ]
        };

        var result = await service.CreateLessonsPlan(chatAIService, mockStudent);
        return result.ToHttpResult();
    }
}