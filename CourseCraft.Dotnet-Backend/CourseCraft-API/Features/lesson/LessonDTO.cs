public record LessonResponse
(
    int Id,
    string Name,
    string Subject,
    DateTime LastAdjustement,
    LessonContent Content,
    int Status
);