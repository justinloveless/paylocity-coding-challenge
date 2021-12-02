using API.Enums;
using API.Models;
using API.ViewModels;

namespace API.Interfaces;

public interface IDependantRepository: IRepository<Dependant>
{
    public IEnumerable<DependantViewModel> GetDependantsByEmployeeId(int id);
    public DependantViewModel? GetDependantAndEmployeeByDependantId(int dependantId);
    public void AddDependantEmployeeRelationship(int dependantId, int employeeId, RelationshipTypes relationship);
    public void RemoveDependantEmployeeRelationship(int dependantId, int employeeId);
    public void AddDependantToEmployee(DependantViewModel dependant);
}