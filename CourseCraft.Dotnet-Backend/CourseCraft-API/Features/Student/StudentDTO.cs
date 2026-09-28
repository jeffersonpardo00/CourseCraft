public record StudentRequest
(
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

public record StudentAIRequest
(
    string FirstName,
    string MiddleName,
    string LastName,
    string LastName2,
    DateTime BirthDate,
    int LearningLevel,
    string[] Interests,
    string[] Notes
);

public record StudentResponse
(
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