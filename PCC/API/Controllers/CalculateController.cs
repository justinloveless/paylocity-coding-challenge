using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CalculateController : BaseApiController
{
    private readonly IEmployeeService _employeeService;
    private readonly IDeductionCalculatorService _calculatorService;

    public CalculateController(IEmployeeService employeeService, IDeductionCalculatorService calculatorService)
    {
        _employeeService = employeeService;
        _calculatorService = calculatorService;
    }

    [HttpGet("total")]
    public async Task<IActionResult> CalculateTotalDeductions()
    {
        return await Task.Run(() =>
        {
            var employees = _employeeService.GetAll();
            var total = _calculatorService.GetTotalDeductions(employees);
            return Ok(total);
        });
    }

    [HttpGet("employee/{id}")]
    public async Task<IActionResult> CalculateEmployeeDeductions(int id)
    {
        return await Task.Run(() =>
        {
            var details = _calculatorService.GetDeductionByEmployee(id);
            return Ok(details);
        });
    }
}