// public record CreateStudentRequest
// (
//     string FirstName,
//     string MiddleName,
//     string LastName,
//     string LastName2,
//     string Email,
//     DateTime BirthDate,
//     int? LearningLevel,
//     string[]? Interests,
//     string[]? Notes
// );
// public record UpdateStudentBasicInfoRequest
// (
//     string FirstName,
//     string MiddleName,
//     string LastName,
//     string LastName2,
//     string Email,
//     DateTime BirthDate
// );
// public record UpdateStudentLevelRequest
// (
//     int Id,
//     decimal LearningLevel
// );
// public record CreateStudentInterestRequest
// (
//     int StudentId,
//     string Interest
// );

// public record CreateStudentNoteRequest
// (
//     int Id,
//     string Note
// );

public record GetStudentByIdResp
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