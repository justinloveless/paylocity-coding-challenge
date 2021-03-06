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
    public EmployeeDto? GetById(int id)
    {
        return _employeeRepository.GetDtoById(id);
    }

    public IEnumerable<EmployeeDto> GetAll()
    {
        return _employeeRepository.GetAllDtos();
    }

    public void HireEmployee(EmployeeDto employee)
    {
        _employeeRepository.CreateWithDependants(employee);
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
        foreach (var dependant in employee.Dependants ?? new List<EmployeeDependantRelationDto>())
        {
            _dependantRepository.Delete(dependant.DependantId ?? 0);
            _dependantRepository.RemoveDependantEmployeeRelationship(dependant.DependantId ?? 0, id);
        }
        _employeeRepository.Delete(id);
    }
}