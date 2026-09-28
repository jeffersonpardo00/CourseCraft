public interface ILessonService
{
    public Task<Result<LessonResponse[]>> GetAllLessons(
        IChatAIService chatAIService
    );
    public Task<Result<LessonResponse[]>> CreateLessonsPlan(
        IChatAIService chatAIService,
        Student student
    );
}