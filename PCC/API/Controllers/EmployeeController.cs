using API.Interfaces;

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
    // TODO: Hire Employee
    // TODO: Fire employee
    // TODO: Find employee via query
    // TODO: Update employee salary
    // TODO: add dependant to employee
    // TODO: remove dependant from employee
}