public interface IGeminiAIService
{
    public Task<Result<string>> getChatResponse (ChatAIReq chatAIReq);
}