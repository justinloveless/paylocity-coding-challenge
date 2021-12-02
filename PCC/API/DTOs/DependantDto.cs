using API.Enums;

namespace API.DTOs;

public class DependantDto
{
    public int DependantId { get; set; }
    public int DependeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public RelationshipTypes Relationship { get; set; }
}