using System.Collections.Generic;
using System.Data;
using API.Interfaces;
using API.Models;
using API.Repositories;
using Moq;
using Xunit;

namespace Testing;

public class DependantRepositoryTests
{
    private readonly DependantRepository _sut;
    private readonly Mock<ISqlService> _sqlMock = new Mock<ISqlService>();

    public DependantRepositoryTests()
    {
        _sut = new DependantRepository(_sqlMock.Object);
    }

    [Fact]
    public void Create_ShouldReturnId_WhenDependantIsValid()
    {
        // Arrange
        int expectedId = 13;
        Dependant dep = new Dependant();
        DataTable table = new DataTable();
        table.Clear();
        table.Columns.Add("id", typeof(int));
        DataRow row = table.NewRow();
        row["id"] = expectedId;
        table.Rows.Add(row);
        // don't really care about the inputs to the executeSingle method right now
        _sqlMock.Setup(x => 
            x.ExecuteSingle(It.IsAny<string>(), 
                It.IsAny<Dictionary<string, object>>()))
            .Returns(table);
        
        // Act
        int actualId = _sut.Create(dep);

        // Assert
        Assert.Equal(expectedId, actualId);

    }
}