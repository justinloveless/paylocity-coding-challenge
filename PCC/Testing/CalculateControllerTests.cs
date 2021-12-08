using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Testing;

public class CalculateControllerTests
{
    private readonly CalculateController _sut;
    private readonly Mock<IEmployeeService> _employeeServiceMock = new Mock<IEmployeeService>();

    private readonly Mock<IDeductionCalculatorService> _deductionCalcServiceMock =
        new Mock<IDeductionCalculatorService>();

    public CalculateControllerTests()
    {
        _sut = new CalculateController(_employeeServiceMock.Object, _deductionCalcServiceMock.Object);
    }

    [Theory]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-100)]
    public async Task CalculateTotalDeductions_ShouldReturnTotal(double expectedTotal)
    {
        // Arrange
        List<EmployeeDto> employees = new List<EmployeeDto>()
        {
            
        };
        _employeeServiceMock.Setup(x => x.GetAll());
        _deductionCalcServiceMock.Setup(x => x.GetTotalDeductions(employees))
            .Returns(expectedTotal);
        
        // Act
        var result = await _sut.CalculateTotalDeductions();

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.Equal(expectedTotal, okResult.Value);
        Assert.Equal(200, okResult.StatusCode);
        

    }

}