using System.Data;
using API.DTOs;
using API.Enums;
using API.Interfaces;
using API.Models;

namespace API.Repositories;

public class DependantRepository : IDependantRepository
{
    private readonly ISqlService _sqlService;

    public DependantRepository(ISqlService sqlService)
    {
        _sqlService = sqlService;
    }

    private Dependant DataRowToDependant(DataRow row)
    {
        return new Dependant()
        {
            FirstName = row.Field<string>("FirstName") ?? string.Empty,
            LastName = row.Field<string>("LastName") ?? string.Empty
        };
    }

    public int Create(Dependant entity)
    {
        DataTable table = _sqlService.ExecuteSingle(@"
INSERT INTO dbo.Dependants (FirstName, LastName) 
OUTPUT inserted.DependantId as id
VALUES (@first, @last)", 
            new Dictionary<string, object>()
        {
            { "@first", entity.FirstName },
            { "@last", entity.LastName }
        });
        return table.AsEnumerable().Select(row => row.Field<int>("id")).FirstOrDefault();
    }

    public IEnumerable<Dependant>? GetAll()
    {
        DataTable table = _sqlService.ExecuteSingle(@"
SELECT DependantId, FirstName, LastName 
FROM dbo.Dependants",
            new Dictionary<string, object>() { });
        return table.AsEnumerable().Select(DataRowToDependant).ToList();
    }

    public Dependant? Get(int id)
    {
        DataTable table = _sqlService.ExecuteSingle(@"
SELECT FirstName, LastName 
FROM dbo.Dependants
        WHERE DependantId = @id", new Dictionary<string, object>() { {"@id", id} });
        return table.AsEnumerable().Select(DataRowToDependant).FirstOrDefault();
    }

    public void Update(int id, Dependant entity)
    {
        _sqlService.ExecuteSingle(@"
UPDATE dbo.Dependants
SET FirstName = @first, LastName = @Last
WHERE DependantId = @id", new Dictionary<string, object>()
        {
            {"@first", entity.FirstName},
            {"@last", entity.LastName},
            {"@id", entity.DependantId}
        });
    }

    public void Delete(int id)
    {
        
        _sqlService.ExecuteSingle(@"
DELETE FROM dbo.Dependants 
WHERE DependantId = @id",
            new Dictionary<string, object>()
            {
                { "@id", id }
            });
    }

    public IEnumerable<DependantDto> GetDependantsByEmployeeId(int id)
    {
        return _sqlService.ExecuteSingle(@"
SELECT D.DependantId, D.FirstName as DepFirstName, D.LastName as DepLastName, 
       EDR.EmployeeId, EDR.RelationType as Relationship
from dbo.EmployeeDependantRelations EDR
INNER JOIN Dependants D on EDR.DependantId = D.DependantId
WHERE EmployeeId = @id",
            new Dictionary<string, object>()
            {
                {"@id", id}
            }).AsEnumerable().Select(row =>
        {
            return new DependantDto
            {
                DependantId = row.Field<int>("DependantId") ,
                EmployeeId = row.Field<int>("EmployeeId"),
                FirstName = row.Field<string>("DepFirstName") ?? string.Empty,
                LastName = row.Field<string>("DepLastName") ?? string.Empty,
                Relationship = (RelationshipTypes)Enum.Parse(typeof(RelationshipTypes),
                    row.Field<string>("Relationship") ?? string.Empty)
            };
        }).ToList();
    }

    public DependantDto? GetDependantAndEmployeeByDependantId(int dependantId)
    {
        return _sqlService.ExecuteSingle(@"
SELECT D.DependantId, D.FirstName as DepFirstName, D.LastName as DepLastName, 
       E.EmployeeId, EDR.RelationType as Relationship 
from dbo.EmployeeDependantRelations EDR
INNER JOIN Dependants D on EDR.DependantId = D.DependantId
INNER JOIN Employees E on EDR.EmployeeId = E.EmployeeId
WHERE E.EmployeeId = @id", new Dictionary<string, object>()
        {
            {"@id", dependantId}
        }).AsEnumerable().Select(row => new DependantDto()
        {
            DependantId = row.Field<int>("DependantId"),
            EmployeeId = row.Field<int>("EmployeeId"),
            FirstName = row.Field<string>("DepFirstName") ?? string.Empty,
            LastName = row.Field<string>("DepLastName") ?? string.Empty,
            Relationship = (RelationshipTypes)Enum.Parse(typeof(RelationshipTypes),
                row.Field<string>("Relationship") ?? string.Empty)
        }).FirstOrDefault();
    }

    public void AddDependantEmployeeRelationship(int dependantId, int employeeId, RelationshipTypes relationship)
    {
        _sqlService.ExecuteSingle(@"
INSERT INTO dbo.EmployeeDependantRelations (EmployeeId, DependantId, RelationType)
VALUES (@empId, @depId, @rel)",
            new Dictionary<string, object>()
            {
                { "@empId", employeeId }, 
                { "@depId", dependantId }, 
                { "@rel", Enum.GetName(typeof(RelationshipTypes), relationship) ?? "child" }
            });
    }

    public void RemoveDependantEmployeeRelationship(int dependantId, int employeeId)
    {
        _sqlService.ExecuteSingle(@"
DELETE FROM dbo.EmployeeDependantRelations 
WHERE EmployeeId = @empId AND DependantId = @depId",
            new Dictionary<string, object>() { { "@empId", employeeId }, { "@depId", dependantId } });
    }
}