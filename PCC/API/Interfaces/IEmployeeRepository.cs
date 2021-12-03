using API.DTOs;
using API.Enums;
using API.Models;

namespace API.Interfaces;

public interface IEmployeeRepository: IRepository<Employee>
{
    public IEnumerable<EmployeeDto> GetAllDtos();
    public EmployeeDto GetDtoById(int id);
    public void UpdateSalaryById(int id, decimal salary);
    public void CreateWithDependants(EmployeeDto employee);
}