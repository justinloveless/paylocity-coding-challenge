using API.DTOs;
using API.Interfaces;

namespace API.Services;

public class DependantService: IDependantService
{
    public DependantDto? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DependantDto> GetDependantsByEmployeeId(int employeeId)
    {
        throw new NotImplementedException();
    }

    public void AddDependantToEmployee(DependantDto dependant)
    {
        throw new NotImplementedException();
    }

    public void RemoveDependantFromEmployee(int dependantId)
    {
        throw new NotImplementedException();
    }
}