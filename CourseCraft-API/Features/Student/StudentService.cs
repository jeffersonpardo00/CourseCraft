public class StudentService(): IStudentService
{
    
    public async Task<Result<GetStudentByIdResp>> GetStudentByIdAsync(int studentId)
    {
        await Task.Delay(500);
        if (studentId != 1)
            return Result<GetStudentByIdResp>.NotFound("Product not found.");

       var MockStudent =
            new GetStudentByIdResp(
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

        return Result<GetStudentByIdResp>.Success(MockStudent);
    }
}