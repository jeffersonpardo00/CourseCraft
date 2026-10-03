public record LessonResponse
(
    int Id,
    string Title,
    string Subject,
    DateTime LastAdjustement,
    LessonContent Content,
    int Status
);