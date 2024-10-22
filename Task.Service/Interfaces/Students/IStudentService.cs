using Task.Service.DTOs.StudentDTOs;

namespace Task.Service.Interfaces.Students;

public interface IStudentService
{
    Task<bool> ReamoveAsync(long id);
    Task<StudentForResultDto> RetrieveByIdAsync(long id);
    Task<StudentForResultDto> CreateAsync(StudentForCreationDto dto);
    Task<StudentForResultDto> ModifyAsync(int id, StudentForUpdateDto dto);
    Task<IEnumerable<StudentForResultDto>> RetrieveAllAsync();
}
