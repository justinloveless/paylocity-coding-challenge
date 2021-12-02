using API.Enums;

namespace API.DTOs;

public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Salary { get; set; }
    public IEnumerable<EmployeeDependantRelationDto> Dependants { get; set; }
}