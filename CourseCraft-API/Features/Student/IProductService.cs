public interface IProductService
{
    Task<Result<CreateStudentDTO>> CreateStudentAsync( CreateStudentDTO createStudentDTO);
    Task<Result<CreateStudentDTO>> UpdateStudentBasicInfoAsync(UpdateStudentBasicInfoDTO updateStudentBasicInfoDTO);
    Task<Result<CreateStudentDTO>> UpdateStudentLevelAsync(UpdateStudentLevelDTO updateStudentLevelDTO);
    Task<Result<CreateStudentDTO>> UpdateStudentInterestsAsync();
    Task<Result<CreateStudentDTO>> UpdateStudentNotesAsync();
}