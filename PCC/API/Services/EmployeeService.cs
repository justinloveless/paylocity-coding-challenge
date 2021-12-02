using API.DTOs;
using API.Interfaces;

namespace API.Services;

public class EmployeeService: IEmployeeService
{
    public EmployeeDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<EmployeeDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public void HireEmployee(EmployeeDto employee)
    {
        throw new NotImplementedException();
    }

    public void UpdateSalary(int id, decimal newSalary)
    {
        throw new NotImplementedException();
    }

    public void FireEmployee(int id)
    {
        throw new NotImplementedException();
    }
}