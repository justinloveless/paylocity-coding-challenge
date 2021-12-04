namespace API.DTOs;

public class EmployeeDeductionDetailsDto
{
    public int EmployeeId { get; set; }
    public double TotalDeductions { get; set; }
    public double TotalDiscounts { get; set; }
    public double GrossPaycheck { get; set; }
    public double NetPaycheck { get; set; }
}