using API.Enums;

namespace API.ViewModels;

public class DependantViewModel
{
    public int? DependantId { get; set; }
    public int? EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public RelationshipTypes? Relationship { get; set; }
}