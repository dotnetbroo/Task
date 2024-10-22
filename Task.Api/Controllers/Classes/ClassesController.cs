using Microsoft.AspNetCore.Mvc;
using Task.Api.Controllers.Commons;
using Task.Api.Models;
using Task.Service.DTOs.ClassDTOs;
using Task.Service.Interfaces.Classes;

namespace Task.Api.Controllers.Classes;

public class ClassesController : BaseController
{
    private readonly IClassService _classService;

    public ClassesController(IClassService classService)
    {
        _classService = classService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ClassForCreationDto dto)
           => Ok(new Response
           {
               Code = 200,
               Message = "Success",
               Data = await _classService.CreateAsync(dto)
           });

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await _classService.RetrieveAllAsync()
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await _classService.RetrieveByIdAsync(id)
        });

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] ClassForUpdateDto dto)
        => Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await _classService.ModifyAsync(id, dto)
        });

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await _classService.ReamoveAsync(id)
        });
}
