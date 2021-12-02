using API.DTOs;
using API.Enums;
using API.Interfaces;
using API.Models;

namespace API.Services;

public class DependantService: IDependantService
{
    private readonly IDependantRepository _dependantRepository;

    public DependantService(IDependantRepository dependantRepository)
    {
        _dependantRepository = dependantRepository;
    }
    public DependantDto? GetById(int id)
    {
        return _dependantRepository.GetDependantAndEmployeeByDependantId(id);
    }

    public IEnumerable<DependantDto> GetDependantsByEmployeeId(int employeeId)
    {
        return _dependantRepository.GetDependantsByEmployeeId(employeeId);
    }

    public void AddDependantToEmployee(DependantDto dependant)
    {
        // TODO: Create single repository method to do both tasks in 1 query (or add trigger on server)
        _dependantRepository.Create(new Dependant
        {
            DependantId = dependant.DependantId,
            FirstName = dependant.FirstName,
            LastName = dependant.LastName
        });
        _dependantRepository.AddDependantEmployeeRelationship(
            dependant.DependantId ?? 0, dependant.EmployeeId ?? 0, dependant.Relationship ?? RelationshipTypes.child
            );
    }

    public void RemoveDependantFromEmployee(int dependantId, int employeeId)
    {
        // TODO: This can be made better by creating a single query to do both tasks
        _dependantRepository.Delete(dependantId);
        _dependantRepository.RemoveDependantEmployeeRelationship(dependantId, employeeId);
    }
}