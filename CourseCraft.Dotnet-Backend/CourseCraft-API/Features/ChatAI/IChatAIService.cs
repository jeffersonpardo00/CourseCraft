public interface IChatAIService
{
     public Task<Result<string>> GenerateLessonsPlan (StudentAIRequest student);
}