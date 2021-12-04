using API.DTOs;

namespace API.Interfaces;

public interface IDeductionCalculatorService
{
    public double GetTotalDeductions(IEnumerable<EmployeeDto> employees);

    public EmployeeDeductionDetailsDto? GetDeductionByEmployee(int id);
    
    
    
}