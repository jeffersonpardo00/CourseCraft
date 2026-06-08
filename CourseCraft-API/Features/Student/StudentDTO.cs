public record CreateStudentDTO
(
    int Id,
    string FirstName,
    string MiddleName,
    string LastName,
    string LastName2,
    string Email,
    DateTime BirthDate,
    int? LearningLevel,
    string[]? Interests,
    string[]? Notes
);
public record UpdateStudentBasicInfoDTO
(
    int Id,
    string FirstName,
    string MiddleName,
    string LastName,
    string LastName2,
    string Email,
    DateTime BirthDate
);
public record UpdateStudentLevelDTO
(
    int Id,
    decimal LearningLevel
);
public record CreateStudentInterestDTO
(
    int StudentId,
    string Interest
);

public record CreateStudentNoteDTO
(
    int Id,
    string Note
);