using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EmployeeController : BaseApiController
{
    private readonly IEmployeeService _employeeService;
    private readonly IDependantService _dependantService;

    public EmployeeController(IEmployeeService employeeService, IDependantService dependantService)
    {
        _employeeService = employeeService;
        _dependantService = dependantService;
    }
    
    // TODO: Get All
    [HttpGet]
    public IActionResult GetAll()
    {
        var employees = _employeeService.GetAll().ToList();
        if (employees.Count > 0)
        {
            return Ok(employees); // should automatically convert to a JSON object array
        }
        return NotFound();
    }
    // TODO: Hire Employee
    [HttpPost]
    public IActionResult HireEmployee([FromBody] EmployeeDto employee)
    {
        _employeeService.HireEmployee(employee);
        return NoContent();
    }
    // TODO: Fire employee
    [HttpDelete("{id}")]
    public IActionResult FireEmployee(int id)
    {
        _employeeService.FireEmployee(id);
        return NoContent();
    }
    // TODO: Find employee
    [HttpGet("{id}")]
    public IActionResult Find(int id)
    {
        var employee = _employeeService.GetById(id);
        if (employee != null)
        {
            return Ok(employee); // should automatically be converted to JSON
        }

        return NotFound();
    }
    // TODO: Update employee salary
    [HttpPut("{id}")]
    public IActionResult UpdateSalary(int id, [FromQuery] decimal salary)
    {
        _employeeService.UpdateSalary(id, salary);
        return NoContent();
    }
}