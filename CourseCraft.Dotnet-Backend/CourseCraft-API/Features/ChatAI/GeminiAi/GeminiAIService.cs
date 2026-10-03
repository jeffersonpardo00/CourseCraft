using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Features;
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

    public Task<Result<string>> GetLessonsPlan(StudentAIRequest student)
    {
    
        var lesson_prompt =
    $"help me to do a lesson of maths for my student in grade {student.LearningLevel}, " +
    $"My student interests are {string.Join(", ", student.Interests)}. " +
    $"Some notes I have been collecting about my student are: {string.Join(", ", student.Notes)}, " +
    "please be very aware of my student's interest and annotations so the lesson is personalized. " +
    "The lesson should consist in an Explanation script of the topic and a list of " +
    "bullet points of strategies to deliver the lesson better. " +
    "Please answer in JSON form in this way: " +
    "{ \"Explanation\": \"the script of the lesson\", \"Strategies\": \"strategy 1, strategy 2, ...\" } " +
    "DO NOT RESPOND ANYTHING ELSE";

        return  GetChatResponse(new ChatAIReq{ prompt = lesson_prompt});

    }

    private async Task<Result<string>> GetChatResponse (ChatAIReq chatAIReq)
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
        var MockText = 
             "{ \"Explanation\": \"Hey there! Today, we are going to combine your awesome drawing skills with a fun basketball game! Imagine you are playing in a big championship game. In the first half, you make 3 incredible baskets! Let's take your marker and draw 3 orange basketballs right here: 1, 2, 3. Now, in the second half, you dribble down the court and sink 2 more baskets! Let's draw those 2 next to the others: 1, 2. Addition is just like adding up your total score to see how many baskets you made all together. We use the plus sign (+) to show we are joining the groups together: 3 + 2. Let's count all the basketballs you drew to find the final score: 1, 2, 3, 4, 5! That means 3 plus 2 equals 5! You scored 5 points and solved an addition problem all with your own drawing!\", "
            +"\"Strategies\": \"Use 'Draw and Count' methods where she sketches basketballs, stars, or jerseys to represent each addend instead of relying on abstract numbers, Introduce a physical movement break where she tosses a soft ball into a basket for each number to connect gross motor skills with addition, Use two different colored markers (e.g., orange for the first group, blue for the second) to visually distinguish the two parts being added together, Teach the 'Counting On' strategy using her drawings by saying the first number and counting the second group on fingers or drawn dots, Keep the addends small (sums within 10) to celebrate quick 'slam dunk' successes and rebuild her math confidence\" } ";
           
        return Result<string>.Success(MockText);
        /*var response = await _httpClient.SendAsync(request);
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
    */}

}


