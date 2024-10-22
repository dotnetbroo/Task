using Task.Service.DTOs.StudentDTOs;

namespace Task.Service.DTOs.ClassDTOs;

public class ClassForResultDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<StudentForResultDto> Students { get; set; }
}
