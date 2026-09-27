using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

public class GeminiService: IChatAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    public GeminiService (HttpClient httpClient, IConfiguration configuration)
    {
        this._httpClient = httpClient;
        _apiKey = configuration["Gemini:ApiKey"] ?? throw new InvalidOperationException("Gemini API key is not configured.");
    }

    public async Task<Result<string>> getChatResponse (ChatAIReq chatAIReq)
    {
        var requestBody = new 
        {
            contents = new []
            {
                new
                {
                    parts = new []
                    {
                        new
                        { 
                            text = chatAIReq.prompt
                        }
                    }
                }
            }
        };

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent"
        );
        request.Headers.Add("X-goog-api-key", _apiKey);
        request.Content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "Application/json"
        );
        var response = await _httpClient.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            using var responseContent = await response.Content.ReadAsStreamAsync();
            using var jsonDoc = await JsonDocument.ParseAsync(responseContent);

            var text = jsonDoc.RootElement
            .GetProperty("candidates")[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString();

            if (string.IsNullOrWhiteSpace(text))
                return Result<string>.Validation("No response from gemini.");

            return Result<string>.Success(text);
        }

        if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
        {
            var message = await response.Content.ReadAsStringAsync();
            return Result<string>.Unavailable($"Gemini service unavailable: {message}");
        }

        return Result<string>.NotFound($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
    }

}


