namespace CourseCraft_API.Test;

public class LessonServiceTest
{
    private readonly LessonService lessonService = new();

    [Fact]
    public async Task LessonsPlanIsRetrieved_WhenChatSuccessfullyReplies()
    {
        // Arrange
        var mockStudent =
            new StudentAIRequest(
                "Molley",
                null,
                "Mol",
                null,
                new DateTime(2016, 1, 1),
                2,
                ["drawing","basketball"],
                ["she is still struggling with addition"]
            );

        const string mockText = """
            {
              "Explanation": "Hey there! Today, we are going to combine your awesome drawing skills with a fun basketball game! Imagine you are playing in a big championship game. In the first half, you make 3 incredible baskets! Let's take your marker and draw 3 orange basketballs right here: 1, 2, 3. Now, in the second half, you dribble down the court and sink 2 more baskets! Let's draw those 2 next to the others: 1, 2. Addition is just like adding up your total score to see how many baskets you made all together. We use the plus sign (+) to show we are joining the groups together: 3 + 2. Let's count all the basketballs you drew to find the final score: 1, 2, 3, 4, 5! That means 3 plus 2 equals 5! You scored 5 points and solved an addition problem all with your own drawing!",
              "Strategies": "Use 'Draw and Count' methods where she sketches basketballs, stars, or jerseys to represent each addend instead of relying on abstract numbers, Introduce a physical movement break where she tosses a soft ball into a basket for each number to connect gross motor skills with addition, Use two different colored markers (e.g., orange for the first group, blue for the second) to visually distinguish the two parts being added together, Teach the 'Counting On' strategy using her drawings by saying the first number and counting the second group on fingers or drawn dots, Keep the addends small (sums within 10) to celebrate quick 'slam dunk' successes and rebuild her math confidence"
            }
            """;
        IChatAIService chatAISuccessService = new ChatAISuccessServiceMock(mockText);

        // Act
        var result = await lessonService.CreateLessonsPlan(mockStudent, chatAISuccessService);

        // Assert
        Assert.True(result.IsSuccess);
        var lesson = Assert.Single(result.Value!);
        Assert.Contains("combine your awesome drawing skills", lesson.Content.Explanation);
        Assert.Contains("Use 'Draw and Count' methods", lesson.Content.Strategies);
    }

    private sealed class ChatAISuccessServiceMock : IChatAIService
    {
        private readonly string response;

        public ChatAISuccessServiceMock(string response)
        {
            this.response = response;
        }

        public Task<Result<string>> GenerateLessonsPlan(StudentAIRequest student)
        {
            return Task.FromResult(Result<string>.Success(response));
        }
    }
}