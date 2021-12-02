using API.DTOs;
using API.Enums;
using API.Models;

namespace API.Interfaces;

public interface IDependantRepository: IRepository<Dependant>
{
    public IEnumerable<DependantDto> GetDependantsByEmployeeId(int id);
    public DependantDto? GetDependantAndEmployeeByDependantId(int dependantId);
    public void AddDependantEmployeeRelationship(int dependantId, int employeeId, RelationshipTypes relationship);
    public void RemoveDependantEmployeeRelationship(int dependantId, int employeeId);
}