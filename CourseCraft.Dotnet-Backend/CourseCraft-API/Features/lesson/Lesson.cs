public class Lesson
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Subject { get; set; }
    public DateTime LastAdjustement { get; set; }
    public required LessonContent Content { get; set; }
    public required int Status { get; set; }
}

public class LessonContent
{
    public required string Explanation { get; set; }
    public required string Strategies { get; set; }
 
}