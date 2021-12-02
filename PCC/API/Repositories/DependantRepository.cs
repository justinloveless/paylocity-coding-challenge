using System.Data;
using API.DTOs;
using API.Enums;
using API.Interfaces;
using API.Models;

namespace API.Repositories;

public class DependantRepository : BaseRepository<Dependant>, IDependantRepository
{
    public DependantRepository(IConfiguration configuration) : base(configuration)
    {
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
        DataTable table = ExecuteQuery(@"
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
        DataTable table = ExecuteQuery(@"
SELECT DependantId, FirstName, LastName 
FROM dbo.Dependants",
            new Dictionary<string, object>() { });
        return table.AsEnumerable().Select(DataRowToDependant).ToList();
    }

    public Dependant? Get(int id)
    {
        DataTable table = ExecuteQuery(@"
SELECT FirstName, LastName 
FROM dbo.Dependants
        WHERE DependantId = @id", new Dictionary<string, object>() { {"@id", id} });
        return table.AsEnumerable().Select(DataRowToDependant).FirstOrDefault();
    }

    public void Update(int id, Dependant entity)
    {
        ExecuteQuery(@"
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
        ExecuteQuery(@"
DELETE FROM dbo.Dependants 
WHERE DependantId = @id",
            new Dictionary<string, object>()
            {
                { "@id", id }
            });
    }

    public IEnumerable<DependantDto> GetDependantsByEmployeeId(int id)
    {
        return ExecuteQuery(@"
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
        return ExecuteQuery(@"
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
        ExecuteQuery(@"
INSERT INTO dbo.EmployeeDependantRelations (EmployeeId, DependantId, RelationType)
VALUES (@empId, @depId, @rel)",
            new Dictionary<string, object>()
            {
                { "@empId", employeeId }, { "@depId", dependantId }, { "@rel", relationship }
            });
    }

    public void RemoveDependantEmployeeRelationship(int dependantId, int employeeId)
    {
        ExecuteQuery(@"
DELETE FROM dbo.EmployeeDependantRelations 
WHERE EmployeeId = @empId AND DependantId = @depId",
            new Dictionary<string, object>() { { "@empId", employeeId }, { "@depId", dependantId } });
    }
}