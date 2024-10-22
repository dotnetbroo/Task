using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task.Data.IRepositories.Classes;
using Task.Domain.Entities;
using Task.Service.Commons.Exceptions;
using Task.Service.DTOs.ClassDTOs;
using Task.Service.Interfaces.Classes;

namespace Task.Service.Services.Classes;

public class ClassService : IClassService
{
    private readonly IClassRepository classRepository;
    private readonly IMapper _mapper;

    public ClassService(IClassRepository classRepository, IMapper mapper)
    {
        this.classRepository = classRepository;
        _mapper = mapper;
    }
    public async Task<ClassForResultDto> CreateAsync(ClassForCreationDto dto)
    {
        var studentClass = await classRepository.SelectAll()
            .Where(c => c.Name.ToLower() == dto.Name.ToLower())
            .FirstOrDefaultAsync();
        if (studentClass is not null)
            throw new CustomException(403, "Class is already exsit.");

        var mapped = _mapper.Map<Class>(dto);
        mapped.CreatedAt = DateTime.UtcNow;

        var result = await classRepository.CreateAsync(mapped);

        return _mapper.Map<ClassForResultDto>(result);
    }

    public async Task<ClassForResultDto> ModifyAsync(int id, ClassForUpdateDto dto)
    {
        var student = await classRepository.SelectAll()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        if (student is null)
            throw new CustomException(404, "Class is not found.");

        var mapped = _mapper.Map(dto, student);
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await classRepository.UpdateAsync(mapped);

        return _mapper.Map<ClassForResultDto>(result);
    }

    public async Task<bool> ReamoveAsync(long id)
    {
        var student = await classRepository.SelectAll()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        if (student is null)
            throw new CustomException(404, "Class is not found.");

        await classRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<ClassForResultDto>> RetrieveAllAsync()
    {
        var students = await classRepository.SelectAll()
                .AsNoTracking()
                .Include(c => c.Students)
                .ToListAsync();

        return _mapper.Map<IEnumerable<ClassForResultDto>>(students);
    }

    public async Task<ClassForResultDto> RetrieveByIdAsync(long id)
    {
        var student = await classRepository.SelectAll()
                 .Where(c => c.Id == id)
                 .AsNoTracking()
                 .Include(x => x.Students)
                 .FirstOrDefaultAsync();
        if (student is null)
            throw new CustomException(404, "Class is not found.");

        return _mapper.Map<ClassForResultDto>(student);
    }
}
