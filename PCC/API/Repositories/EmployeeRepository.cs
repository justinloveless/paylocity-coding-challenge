using API.Interfaces;
using API.Models;

namespace API.Repositories;

public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public int Create(Employee entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Employee>? GetAll()
    {
        throw new NotImplementedException();
    }

    public Employee? Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Employee entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Tuple<Employee, List<Dependant>>> GetAllWithDependants()
    {
        throw new NotImplementedException();
    }

    public Tuple<Employee, List<Dependant>> GetByIdWithDependants(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateSalaryById(int id, decimal salary)
    {
        throw new NotImplementedException();
    }
}