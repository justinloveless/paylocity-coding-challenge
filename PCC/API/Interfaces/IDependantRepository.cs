using API.Enums;
using API.Models;

namespace API.Interfaces;

public interface IDependantRepository: IRepository<Dependant>
{
    public IEnumerable<Dependant> GetDependantsByEmployeeId(int id);
    public Tuple<Dependant, Employee>? GetDependantAndEmployeeByDependantId(int dependantId);
    public void AddDependantEmployeeRelationship(int dependantId, int employeeId, RelationshipTypes relationship);
    public void RemoveDependantEmployeeRelationship(int dependantId, int employeeId);
}