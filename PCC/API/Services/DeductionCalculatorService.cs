using API.DTOs;
using API.Interfaces;

namespace API.Services;

public class DeductionCalculatorService : IDeductionCalculatorService
{
    private readonly IEmployeeService _employeeService;
    private static readonly int PaychecksPerYear = 26;
    private static readonly double EmployeeCostPerYear = 1000;
    private static readonly double DependantCostPerYear = 500;
    private static readonly double DiscountRate = 0.1;
    

    public DeductionCalculatorService(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    private bool ShouldApplyDiscount(object? obj)
    {
        if (obj is not string)
            return false;
        // not using obj.ToString() here in case obj is null.
        // Probably paranoid about that though, since checking if it's
        // not a string should also handle if the obj is null
        var str = Convert.ToString(obj); 
        return str != null && str.StartsWith('A');
    }
    
    public EmployeeDeductionDetailsDto? GetDeductionByEmployee(int id)
    {
        EmployeeDeductionDetailsDto deductionDetails = new EmployeeDeductionDetailsDto();
        var employee = _employeeService.GetById(id);
        if (employee == null)
            return null;
        double deductions = 0;
        double discounts = 0;
        foreach (var dependant in employee.Dependants ?? new List<EmployeeDependantRelationDto>())
        {
            bool applyDiscount = ShouldApplyDiscount(dependant.FirstName);
            deductions += DependantCostPerYear * 
                          (applyDiscount ? 1 - DiscountRate : 1);
            discounts += DependantCostPerYear * 
                         (applyDiscount ? DiscountRate : 0);
        }

        bool applyEmployeeDiscount = ShouldApplyDiscount(employee.FirstName);
        deductions += EmployeeCostPerYear * (applyEmployeeDiscount ? 1 - DiscountRate : 1);
        discounts += EmployeeCostPerYear * (applyEmployeeDiscount ? DiscountRate : 0);
        
        deductionDetails.GrossPaycheck = (double)(employee.Salary ?? 0) / PaychecksPerYear;
        deductionDetails.EmployeeId = id;
        deductionDetails.TotalDeductions = deductions;
        deductionDetails.TotalDiscounts = discounts;
        deductionDetails.NetPaycheck = Math.Round( deductionDetails.GrossPaycheck - deductions / PaychecksPerYear, 2);
        // NOTE: NetPaycheck won't be completely accurate, due to rounding errors.
        // To be completely correct I would want to use an array for each paycheck
        // throughout the year, and correct for the error at the last paycheck

        return deductionDetails;
    }
    
    public double GetTotalDeductions(IEnumerable<EmployeeDto> employees)
    {
        return employees.Sum(e => 
            1000 * (e.FirstName != null && e.FirstName.StartsWith('A') ? 0.9 : 1.0)
            + (e.Dependants ?? Array.Empty<EmployeeDependantRelationDto>()).Sum(d => 
                500 * (d.FirstName != null && d.FirstName.StartsWith('A') ? 0.9 : 1.0)));
    }
}