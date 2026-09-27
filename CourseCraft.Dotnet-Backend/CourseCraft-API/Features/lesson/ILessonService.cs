public interface ILessonService
{
    public Task<Result<LessonResponse[]>> GetAllLessons(
        IChatAIService chatAIService
    );
}