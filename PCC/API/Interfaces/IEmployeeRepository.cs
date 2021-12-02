using API.Enums;
using API.Models;
using API.ViewModels;

namespace API.Interfaces;

public interface IEmployeeRepository: IRepository<Employee>
{
    public IEnumerable<EmployeeViewModel> GetAllDtos();
    public EmployeeViewModel GetDtoById(int id);
    public void UpdateSalaryById(int id, decimal salary);
}