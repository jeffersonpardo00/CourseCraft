public interface IChatAIService
{
     public Task<Result<string>> GetLessonsPlan (StudentAIRequest student);
}