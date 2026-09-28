public interface IChatAIService
{
     public Task<Result<string>> GetLessonsPlan (Student student);
     //private Task<Result<string>> GetChatResponse (ChatAIReq chatAIReq);
}