using API.DTOs;

namespace API.Interfaces;

public interface IEmployeeService
{
    // TODO: Get Employee by ID
    public EmployeeDto GetById(int id);
    // TODO: Get all employees
    public IEnumerable<EmployeeDto> GetAll();
    // TODO: Hire new employee
    public void HireEmployee(EmployeeDto employee);
    // TODO: Update salary
    public void UpdateSalary(int id, decimal newSalary);
    // TODO: Fire employee
    public void FireEmployee(int id);
}