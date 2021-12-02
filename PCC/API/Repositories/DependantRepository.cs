using API.Enums;
using API.Interfaces;
using API.Models;

namespace API.Repositories;

public class DependantRepository : BaseRepository<Dependant>, IDependantRepository
{
    public DependantRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public int Create(Dependant entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Dependant>? GetAll()
    {
        throw new NotImplementedException();
    }

    public Dependant? Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Dependant entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Dependant> GetDependantsByEmployeeId(int id)
    {
        throw new NotImplementedException();
    }

    public Tuple<Dependant, Employee>? GetDependantAndEmployeeByDependantId(int dependantId)
    {
        throw new NotImplementedException();
    }

    public void AddDependantEmployeeRelationship(int dependantId, int employeeId, RelationshipTypes relationship)
    {
        throw new NotImplementedException();
    }

    public void RemoveDependantEmployeeRelationship(int dependantId, int employeeId)
    {
        throw new NotImplementedException();
    }
}