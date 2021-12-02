using API.Models;
using API.ViewModels;

namespace API.Interfaces;

public interface IDependantService
{
    // Get dependant by ID
    public DependantViewModel? GetById(int id);
    // Get dependants of Employee by Employee ID
    public IEnumerable<DependantViewModel> GetDependantsByEmployeeId(int employeeId);
    // Add dependant to Employee
    public void AddDependantToEmployee(DependantViewModel dependant);
    //Remove dependant from Employee
    public void RemoveDependantFromEmployee(int dependantId, int employeeId);
}