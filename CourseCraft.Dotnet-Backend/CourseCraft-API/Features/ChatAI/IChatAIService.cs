public interface IChatAIService
{
    public Task<Result<string>> getChatResponse (ChatAIReq chatAIReq);
}