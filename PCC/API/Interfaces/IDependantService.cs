using API.DTOs;
using API.Models;

namespace API.Interfaces;

public interface IDependantService
{
    // TODO: Get dependant by ID
    public DependantDto? GetById(int id);
    // TODO: Get dependants of Employee by Employee ID
    public IEnumerable<DependantDto> GetDependantsByEmployeeId(int employeeId);
    // TODO: Add dependant to Employee
    public void AddDependantToEmployee(DependantDto dependant);
    // TODO: Remove dependant from Employee
    public void RemoveDependantFromEmployee(int dependantId);
}