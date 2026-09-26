public static class ChatAIEndpoints
{
    public static void MapChatAIEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/ChatAI").WithTags("ChatsAI");
        group.MapPost("/newGeminiPrompt", GetGeminiChatResponse);
    }

    private static async Task<IResult> GetGeminiChatResponse(ChatAIReq chatAIReq, IGeminiAIService service)
    {
        var result = await service.getChatResponse(chatAIReq);
        return result.ToHttpResult();
    }
}