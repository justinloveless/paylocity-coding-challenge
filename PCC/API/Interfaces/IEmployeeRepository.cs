using API.DTOs;
using API.Models;

namespace API.Interfaces;

public interface IEmployeeRepository: IRepository<Employee>
{
    public IEnumerable<Tuple<Employee, List<Dependant>>> GetAllWithDependants();
    public Tuple<Employee, List<Dependant>> GetByIdWithDependants(int id);
    public void UpdateSalaryById(int id, decimal salary);
}