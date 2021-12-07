using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using API.DTOs;
using API.Enums;
using API.Interfaces;
using API.Models;
using API.Services;
using Moq;
using Xunit;

namespace Testing;

public class EmployeeServiceTests
{
    private EmployeeService _sut;
    private readonly Mock<IEmployeeRepository> _employeeRepoMock = new Mock<IEmployeeRepository>();
    private readonly Mock<IDependantRepository> _dependantRepoMock = new Mock<IDependantRepository>();

    public EmployeeServiceTests()
    {
        _sut = new EmployeeService(_employeeRepoMock.Object, _dependantRepoMock.Object);
    }

    [Fact]
    public void FireEmployee_ShouldRemoveEmployee_WhenEmployeeExists()
    {
        // Arrange
        var id = 24;
        var firstName = "Manuel";
        var lastName = "Mangogo";
        var salary = 454545;
        var dependant1 = new EmployeeDependantRelationDto
        {
            DependantId = 50,
            FirstName = "Annabelle",
            LastName = "Mangogo",
            Relationship = RelationshipTypes.child
        };
        var dependant2 = new EmployeeDependantRelationDto
        {
            DependantId = 52,
            FirstName = "Johnny",
            LastName = "Mangogo",
            Relationship = RelationshipTypes.child
        };
        var dependants = new List<EmployeeDependantRelationDto>()
        {
            dependant1, dependant2
        };
        var employeeDto = new EmployeeDto
        {
            EmployeeId = id,
            FirstName = firstName,
            LastName = lastName,
            Salary = salary,
            Dependants = dependants
        };
        var dependantsCount = employeeDto.Dependants.Count();
        _employeeRepoMock.Setup(x => x.GetDtoById(id))
            .Returns(employeeDto);
        _employeeRepoMock.Setup(x => x.Delete(id));
        _dependantRepoMock.Setup(x => x.Delete(It.IsAny<int>()));
        _dependantRepoMock.Setup(x => 
            x.RemoveDependantEmployeeRelationship(It.IsAny<int>(), id));
        
        
        // Act 
        _sut.FireEmployee(id);

        // Assert 
        _employeeRepoMock.Verify(x => x.GetDtoById(id), Times.Once);
        _dependantRepoMock.Verify(x => 
            x.Delete(It.IsAny<int>()), Times.Exactly(dependantsCount));
        _dependantRepoMock.Verify(x => 
            x.RemoveDependantEmployeeRelationship(It.IsAny<int>(), id), 
            Times.Exactly(dependantsCount));
        _employeeRepoMock.Verify(x => x.Delete(id), Times.Once);

    }
    
    [Fact]
    public void UpdateSalary_ShouldChangeSalary_WhenEmployeeExists()
    {
        // Arrange
        var id = 13;
        var newSalary = 99999;
        _employeeRepoMock.Setup(x => x.UpdateSalaryById(id, newSalary));

        // Act
        _sut.UpdateSalary(id, newSalary);

        // Assert
        _employeeRepoMock.Verify(x => 
            x.UpdateSalaryById(id, newSalary), Times.Once);

    }

    [Fact]
    public void HireEmployee_ShouldCreateEmployee_WhenEmployeeIsValid()
    {
        // Arrange
        var id = 12;
        var firstName = "Antonio";
        var lastName = "Mendez";
        var salary = 12345;
        EmployeeDto employeeDto = new EmployeeDto()
        {
            Dependants = new List<EmployeeDependantRelationDto>(),
            EmployeeId = id,
            FirstName = firstName,
            LastName = lastName,
            Salary = salary
        };
        
        _employeeRepoMock.Setup(x => x.CreateWithDependants(employeeDto));

        // Act
        _sut.HireEmployee(employeeDto);

        // Assert
        _employeeRepoMock.Verify(x => 
            x.CreateWithDependants(employeeDto), Times.Once);

        
    }

    [Fact]
    public void GetAll_ShouldReturnEmployeeDtoList_WhenEmployeesExist()
    {
        // Arrange
        var id = 12;
        var firstName = "Antonio";
        var lastName = "Mendez";
        var salary = 12345;
        EmployeeDto employeeDto1 = new EmployeeDto()
        {
            Dependants = new List<EmployeeDependantRelationDto>()
            {
                new EmployeeDependantRelationDto()
                {
                    DependantId = 3,
                    FirstName = "Marbles",
                    LastName = "Rollo",
                    Relationship = RelationshipTypes.child
                }
            },
            EmployeeId = id,
            FirstName = firstName,
            LastName = lastName,
            Salary = salary
        };
        EmployeeDto employeeDto2 = new EmployeeDto()
        {
            Dependants = new List<EmployeeDependantRelationDto>()
            {
                new EmployeeDependantRelationDto()
                {
                    DependantId = 100,
                    FirstName = "Holly",
                    LastName = "Molly",
                    Relationship = RelationshipTypes.spouse
                }
            },
            EmployeeId = 99,
            FirstName = "Ronald",
            LastName = "McDonald",
            Salary = 98765
        };
        List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
        employeeDtos.Add(employeeDto1);
        employeeDtos.Add(employeeDto2);
        _employeeRepoMock.Setup(x => x.GetAllDtos())
            .Returns(employeeDtos);
        
        // Act
        var result = _sut.GetAll();

        // Assert
        Assert.Equal(result, employeeDtos);

    }
    
    [Fact]
    public void GetById_ShouldReturnEmployeeDto_WhenEmployeeExists()
    {
        // Arrange
        var id = 12;
        var firstName = "Antonio";
        var lastName = "Mendez";
        var salary = 12345;
        EmployeeDto employeeDto = new EmployeeDto()
        {
            Dependants = new List<EmployeeDependantRelationDto>()
            {
                new EmployeeDependantRelationDto()
                {
                    DependantId = 3,
                    FirstName = "Marbles",
                    LastName = "Rollo",
                    Relationship = RelationshipTypes.child
                }
            },
            EmployeeId = id,
            FirstName = firstName,
            LastName = lastName,
            Salary = salary
        };
        _employeeRepoMock.Setup(x => x.GetDtoById(id))
            .Returns(employeeDto);
        
        // Act
        var employee = _sut.GetById(id);

        // Assert
        Assert.NotNull(employee);
        Assert.Equal(id, employee.EmployeeId);

    }
    
}