using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class DependantController : BaseApiController
{
    private readonly IDependantService _dependantService;

    public DependantController(IDependantService dependantService)
    {
        _dependantService = dependantService;
    }
    
    
    [HttpPost]
    public IActionResult AddDependant([FromBody] DependantDto dependant)
    {
        _dependantService.AddDependantToEmployee(dependant);
        return NoContent();
    }
    
    [HttpDelete]
    public IActionResult RemoveDependant([FromQuery] int dependantId, [FromQuery] int employeeId)
    {
        _dependantService.RemoveDependantFromEmployee(dependantId, employeeId);
        return NoContent();
    }
    
}