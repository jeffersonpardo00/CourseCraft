public interface IStudentService
{
    // Task<Result<CreateStudentRequest>> CreateStudentAsync( CreateStudentRequest createStudentReq);
    // Task<Result<UpdateStudentBasicInfoRequest>> UpdateStudentBasicInfoAsync(int studentId, UpdateStudentBasicInfoRequest updateStudentBasicInfoReq);
    // Task<Result<UpdateStudentLevelRequest>> UpdateStudentLevelAsync(int studentId, UpdateStudentLevelRequest updateStudentLevelReq);
    // Task<Result<CreateStudentInterestRequest>> CreateStudentInterestsAsync(int studentId, CreateStudentInterestRequest createStudentInterestReq);
    public Task<Result<GetStudentByIdResp>> GetStudentByIdAsync(int studentId);
}