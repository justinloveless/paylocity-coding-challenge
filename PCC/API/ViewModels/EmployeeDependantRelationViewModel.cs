using API.Enums;

namespace API.ViewModels;

public class EmployeeDependantRelationViewModel
{
    public int? DependantId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public RelationshipTypes? Relationship { get; set; }
}