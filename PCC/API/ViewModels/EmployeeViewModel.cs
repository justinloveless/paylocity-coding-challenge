namespace API.ViewModels;

public class EmployeeViewModel
{
    public int? EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public decimal? Salary { get; set; }
    public IEnumerable<EmployeeDependantRelationViewModel> Dependants { get; set; }
}