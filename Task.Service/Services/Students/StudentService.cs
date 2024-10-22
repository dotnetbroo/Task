using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task.Data.IRepositories.Students;
using Task.Domain.Entities;
using Task.Service.Commons.Exceptions;
using Task.Service.DTOs.StudentDTOs;
using Task.Service.Interfaces.Students;

namespace Task.Service.Services.Students;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<StudentForResultDto> CreateAsync(StudentForCreationDto dto)
    {
        var student = await _studentRepository.SelectAll()
            .Where(c => c.FullName.ToLower() == dto.FullName.ToLower())
            .FirstOrDefaultAsync();
        if (student is not null)
            throw new CustomException(403, "Student is already exsit.");

        var mapped = _mapper.Map<Student>(dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var result = await _studentRepository.CreateAsync(mapped);

        return _mapper.Map<StudentForResultDto>(result);
    }

    public async Task<StudentForResultDto> ModifyAsync(int id, StudentForUpdateDto dto)
    {
        var student = await _studentRepository.SelectAll()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        if (student is null)
            throw new CustomException(404, "Student is not found.");

        var mapped = _mapper.Map(dto, student);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _studentRepository.UpdateAsync(mapped);

        return _mapper.Map<StudentForResultDto>(result);
    }

    public async Task<bool> ReamoveAsync(long id)
    {
        var student = await _studentRepository.SelectAll()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        if (student is null)
            throw new CustomException(404, "Student is not found.");

        await _studentRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<StudentForResultDto>> RetrieveAllAsync()
    {
        var students = await _studentRepository.SelectAll()
                .AsNoTracking()
                .ToListAsync();

        return _mapper.Map<IEnumerable<StudentForResultDto>>(students);
    }

    public async Task<StudentForResultDto> RetrieveByIdAsync(long id)
    {
        var student = await _studentRepository.SelectAll()
                 .Where(c => c.Id == id)
                 .AsNoTracking()
                 .FirstOrDefaultAsync();
        if (student is null)
            throw new CustomException(404, "Student is not found.");

        return _mapper.Map<StudentForResultDto>(student);
    }
}
