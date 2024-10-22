using Task.Service.DTOs.ClassDTOs;
using Task.Service.DTOs.StudentDTOs;

namespace Task.Service.Interfaces.Classes;

public interface IClassService
{
    Task<bool> ReamoveAsync(long id);
    Task<ClassForResultDto> RetrieveByIdAsync(long id);
    Task<ClassForResultDto> CreateAsync(ClassForCreationDto dto);
    Task<ClassForResultDto> ModifyAsync(int id, ClassForUpdateDto dto);
    Task<IEnumerable<ClassForResultDto>> RetrieveAllAsync();
}
