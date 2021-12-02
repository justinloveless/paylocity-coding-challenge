using API.Enums;

namespace API.Models;

public class EmployeeDependantRelationship
{
    public int? EmployeeId { get; set; }
    public int? DependantId { get; set; }
    public RelationshipTypes? RelationshipType { get; set; }
}