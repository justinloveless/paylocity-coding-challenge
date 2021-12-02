using API.DTOs;
using API.Models;

namespace API.Interfaces;

public interface IDependantService
{
    // Get dependant by ID
    public DependantDto? GetById(int id);
    // Get dependants of Employee by Employee ID
    public IEnumerable<DependantDto> GetDependantsByEmployeeId(int employeeId);
    // Add dependant to Employee
    public void AddDependantToEmployee(DependantDto dependant);
    //Remove dependant from Employee
    public void RemoveDependantFromEmployee(int dependantId, int employeeId);
}