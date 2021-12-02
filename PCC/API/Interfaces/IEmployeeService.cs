using API.ViewModels;

namespace API.Interfaces;

public interface IEmployeeService
{
    //Get Employee by ID
    public EmployeeViewModel? GetById(int id);
    //Get all employees
    public IEnumerable<EmployeeViewModel> GetAll();
    //Hire new employee
    public void HireEmployee(EmployeeViewModel employee);
    //Update salary
    public void UpdateSalary(int id, decimal newSalary);
    //Fire employee
    public void FireEmployee(int id);
}