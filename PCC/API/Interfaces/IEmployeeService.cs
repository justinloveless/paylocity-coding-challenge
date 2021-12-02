using API.DTOs;

namespace API.Interfaces;

public interface IEmployeeService
{
    //Get Employee by ID
    public EmployeeDto? GetById(int id);
    //Get all employees
    public IEnumerable<EmployeeDto> GetAll();
    //Hire new employee
    public void HireEmployee(EmployeeDto employee);
    //Update salary
    public void UpdateSalary(int id, decimal newSalary);
    //Fire employee
    public void FireEmployee(int id);
}