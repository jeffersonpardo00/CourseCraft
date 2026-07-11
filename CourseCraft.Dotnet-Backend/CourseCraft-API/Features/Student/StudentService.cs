public class StudentService(): IStudentService
{
    public async Task<Result<StudentResponse>> GetStudentByIdAsync(int studentId)
    {
        await Task.Delay(500);
        if (studentId != 1)
            return Result<StudentResponse>.NotFound("Student not found.");

       var MockStudent =
            new StudentResponse(
                "Molley",
                null,
                "Mol",
                null,
                "molie.mol@gmail.com",
                new DateTime(2016, 1, 1),
                2,
                ["drawing","basketball"],
                ["note1"]
            );

        return Result<StudentResponse>.Success(MockStudent);
    }
    public async Task<Result<StudentResponse>> CreateStudentAsync( CreateStudentRequest createStudentReq)
    {
        await Task.Delay(500);

        var newStudent = new StudentResponse
        (
            createStudentReq.FirstName, 
            createStudentReq.MiddleName,
            createStudentReq.LastName,
            createStudentReq.LastName2,
            createStudentReq.Email,
            createStudentReq.BirthDate,
            createStudentReq.LearningLevel,
            createStudentReq.Interests,
            createStudentReq.Notes
        );

        return Result<StudentResponse>.Success(newStudent);

    }
}