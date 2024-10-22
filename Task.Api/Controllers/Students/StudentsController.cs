using Microsoft.AspNetCore.Mvc;
using Task.Api.Controllers.Commons;
using Task.Api.Models;
using Task.Service.DTOs.ClassDTOs;
using Task.Service.DTOs.StudentDTOs;
using Task.Service.Interfaces.Students;

namespace Task.Api.Controllers.Students;

public class StudentsController : BaseController
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] StudentForCreationDto dto)
           => Ok(new Response
           {
               Code = 200,
               Message = "Success",
               Data = await _studentService.CreateAsync(dto)
           });

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await _studentService.RetrieveAllAsync()
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await _studentService.RetrieveByIdAsync(id)
        });

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] StudentForUpdateDto dto)
        => Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await _studentService.ModifyAsync(id, dto)
        });

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await _studentService.ReamoveAsync(id)
        });
}
