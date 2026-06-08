public interface IProductService
{
    Task<Result<CreateStudentRequest>> CreateStudentAsync( CreateStudentRequest createStudentReq);
    Task<Result<UpdateStudentBasicInfoRequest>> UpdateStudentBasicInfoAsync(int studentId, UpdateStudentBasicInfoRequest updateStudentBasicInfoReq);
    Task<Result<UpdateStudentLevelRequest>> UpdateStudentLevelAsync(int studentId, UpdateStudentLevelRequest updateStudentLevelReq);
    Task<Result<CreateStudentInterestRequest>> CreateStudentInterestsAsync(int studentId, CreateStudentInterestRequest createStudentInterestReq);
    Task<Result<CreateStudentNoteRequest>> UpdateStudentNotesAsync(int studentId, CreateStudentNoteRequest CreateStudentNoteReq);
}