public interface IStudentService
{
    public Task<Result<StudentResponse>> CreateStudentAsync( StudentRequest createStudentReq);
    // Task<Result<UpdateStudentBasicInfoRequest>> UpdateStudentBasicInfoAsync(int studentId, UpdateStudentBasicInfoRequest updateStudentBasicInfoReq);
    // Task<Result<UpdateStudentLevelRequest>> UpdateStudentLevelAsync(int studentId, UpdateStudentLevelRequest updateStudentLevelReq);
    // Task<Result<CreateStudentInterestRequest>> CreateStudentInterestsAsync(int studentId, CreateStudentInterestRequest createStudentInterestReq);
    public Task<Result<StudentResponse>> GetStudentByIdAsync(int studentId);
}