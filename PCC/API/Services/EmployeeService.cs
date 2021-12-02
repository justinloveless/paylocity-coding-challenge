using API.DTOs;
using API.Interfaces;
using API.Models;

namespace API.Services;

public class EmployeeService: IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDependantRepository _dependantRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, IDependantRepository dependantRepository)
    {
        _employeeRepository = employeeRepository;
        _dependantRepository = dependantRepository;
    }
    public EmployeeDto GetById(int id)
    {
        return _employeeRepository.GetDtoById(id);
    }

    public IEnumerable<EmployeeDto> GetAll()
    {
        return _employeeRepository.GetAllDtos();
    }

    public void HireEmployee(EmployeeDto employee)
    {
        _employeeRepository.Create(new Employee
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Salary = employee.Salary,
        });
    }

    public void UpdateSalary(int id, decimal newSalary)
    {
        _employeeRepository.UpdateSalaryById(id, newSalary);
    }

    public void FireEmployee(int id)
    {
        var employee = _employeeRepository.GetDtoById(id);
        // TODO: Delete all dependants of employee, and remove all relationships, then delete employee itself
        // Really need to find a better way to do this, and this should be done using a transaction
        foreach (var dependant in employee.Dependants)
        {
            _dependantRepository.Delete(dependant.DependantId);
            _dependantRepository.RemoveDependantEmployeeRelationship(dependant.DependantId, id);
        }
        _employeeRepository.Delete(id);
    }
}