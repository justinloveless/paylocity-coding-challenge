using System.Data;
using API.DTOs;
using API.Enums;
using API.Interfaces;
using API.Models;

namespace API.Repositories;

public class EmployeeRepository: IEmployeeRepository
{
    private readonly ISqlService _sqlService;

    public EmployeeRepository(ISqlService sqlService)
    {
        _sqlService = sqlService;
    }

    public Employee DataRowToEmployee(DataRow row)
    {
        return new Employee()
        {
            EmployeeId = row.Field<int>("EmployeeId"),
            FirstName = row.Field<string>("FirstName") ?? string.Empty,
            LastName = row.Field<string>("LastName") ?? string.Empty,
            Salary = row.Field<decimal>("Salary")
        };
    }

    public int Create(Employee entity)
    {
        return _sqlService.ExecuteSingle(@"
INSERT INTO dbo.Employees (FirstName, LastName, Salary) 
Output inserted.EmployeeId as id
VALUES (@first, @last, @sal)", new Dictionary<string, object>()
            {
                {"@first", entity.FirstName},
                {"@last", entity.LastName},
                {"@sal", entity.Salary}
            }).AsEnumerable()
            .Select(row => row.Field<int>("id")).FirstOrDefault();
    }

    public void CreateWithDependants(EmployeeDto employee)
    {
        int employeeId = Create(new Employee()
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Salary = employee.Salary
        });
        foreach (var dependant in employee.Dependants)
        {
            // add dependant
            int dependantId = _sqlService.ExecuteSingle(@"
INSERT INTO dbo.Dependants (FirstName, LastName) 
Output inserted.DependantId as id
VALUES ( @first, @last)", 
                new Dictionary<string, object>()
                {
                    {"@first", dependant.FirstName ?? string.Empty},
                    {"@last", dependant.LastName ?? string.Empty}
                }).AsEnumerable().Select(row => row.Field<int>("id")).FirstOrDefault();
            
            // add relationship
            _sqlService.ExecuteSingle(@"
INSERT INTO dbo.EmployeeDependantRelations (EmployeeId, DependantId, RelationType) 
VALUES (@empId, @depId, @relation)",
                new Dictionary<string, object>()
                {
                    {"@empId", employeeId},
                    {"@depId", dependantId},
                    {"@relation", Enum.GetName(dependant.Relationship ?? RelationshipTypes.child) ?? "child"}
                });
        }
    }

    public IEnumerable<Employee>? GetAll()
    {
        return _sqlService.ExecuteSingle(@"
SELECT EmployeeId, FirstName, LastName, Salary 
FROM dbo.Employees", 
                new Dictionary<string, object>() { })
            .AsEnumerable().Select(DataRowToEmployee).ToList();
    }

    public Employee? Get(int id)
    {
        return _sqlService.ExecuteSingle(@"
SELECT EmployeeId, FirstName, LastName, Salary 
FROM dbo.Employees
WHERE EmployeeId = @id", 
                new Dictionary<string, object>() { { "@id", id } })
            .AsEnumerable().Select(DataRowToEmployee).FirstOrDefault();
    }

    public void Update(int id, Employee entity)
    {
        _sqlService.ExecuteSingle(@"
UPDATE dbo.Employees
SET FirstName = @first, LastName = @last, Salary = @sal
WHERE EmployeeId = @id", new Dictionary<string, object>()
        {
            { "@first", entity.FirstName },
            { "@last", entity.LastName },
            { "@sal", entity.Salary },
            { "@id", entity.EmployeeId }
        });
    }

    public void Delete(int id)
    {
        
      // delete employee, all dependants, and all relationships for employee
      
      var parameters = new Dictionary<string, object>()
      {
          {"@empId", id}
      }; 
      _sqlService.AddQuery(@"
DELETE FROM dbo.Employees
WHERE EmployeeId = @empId", parameters);
      
      _sqlService.AddQuery(@"
DELETE FROM dbo.Dependants
WHERE DependantId IN (
    SELECT D.DependantId
    from dbo.EmployeeDependantRelations EDR
    INNER JOIN Dependants D on EDR.DependantId = D.DependantId
    WHERE EmployeeId = @empId
)", parameters);
      
      _sqlService.AddQuery(@"
DELETE FROM dbo.EmployeeDependantRelations
WHERE EmployeeId = @empId", parameters);
       
      _sqlService.SaveChanges();

    }

    private List<EmployeeDto> DataTableToEmployeeDependantListTuple(DataTable table)
    {
        List<EmployeeDto> employees = new List<EmployeeDto>();
        var rows = table.AsEnumerable();
        foreach (var row in rows)
        {
            if (employees.Any(e => e.EmployeeId == row.Field<int>("EmployeeId")))
            {
                continue;
            }
            var employeeDependants = rows.Where(r => 
                r.Field<int>("EmployeeId") == row.Field<int>("EmployeeId"));
            List<EmployeeDependantRelationDto> relations = employeeDependants
                .Where(r => r.Field<int?>("DependantId") != null)
                .Select(r => 
                new EmployeeDependantRelationDto()
            {
                DependantId = r.Field<int?>("DependantId"),
                FirstName = r.Field<string?>("DepFirstName"),
                LastName = r.Field<string?>("DepLastName"),
                Relationship = (RelationshipTypes)Enum.Parse(typeof(RelationshipTypes),
                    (r.Field<string>("Relationship") ?? Enum.GetName(RelationshipTypes.child)))
            }).ToList();
            EmployeeDto employee = 
                new EmployeeDto()
            {
                EmployeeId = row.Field<int?>("EmployeeId"),
                FirstName = row.Field<string?>("EmpFirstName"),
                LastName = row.Field<string?>("EmpLastName"),
                Salary = row.Field<decimal?>("Salary"),
                Dependants = relations
            };
            employees.Add(employee);
        }
        return employees;
    }
    public IEnumerable<EmployeeDto> GetAllDtos()
    {
        var results = _sqlService.ExecuteSingle(@"
SELECT 
E.EmployeeId, E.FirstName as 'EmpFirstName', E.LastName as 'EmpLastName', E.Salary, 
EDR.RelationType as Relationship, 
D.DependantId, D.FirstName as 'DepFirstName', D.LastName as 'DepLastName'
FROM dbo.Employees as E
LEFT OUTER JOIN EmployeeDependantRelations EDR on E.EmployeeId = EDR.EmployeeId
LEFT OUTER JOIN Dependants D on EDR.DependantId = D.DependantId", new Dictionary<string, object>());
        return DataTableToEmployeeDependantListTuple(results);
    }

    public EmployeeDto GetDtoById(int id)
    {
        var results = _sqlService.ExecuteSingle(@"
SELECT 
E.EmployeeId, E.FirstName as 'EmpFirstName', E.LastName as 'EmpLastName', E.Salary, 
EDR.RelationType  as Relationship, 
D.DependantId, D.FirstName as 'DepFirstName', D.LastName as 'DepLastName'
FROM dbo.Employees as E
LEFT OUTER JOIN EmployeeDependantRelations EDR on E.EmployeeId = EDR.EmployeeId
LEFT OUTER JOIN Dependants D on EDR.DependantId = D.DependantId
        WHERE E.EmployeeId = @id", 
            new Dictionary<string, object>() {{"@id", id}});
        return DataTableToEmployeeDependantListTuple(results).First();
    }

    public void UpdateSalaryById(int id, decimal salary)
    {
        _sqlService.ExecuteSingle(@"UPDATE dbo.Employees
SET Salary = @sal
WHERE EmployeeId = @id", 
            new Dictionary<string, object>()
            {
                { "@sal", salary }, 
                { "@id", id }
            });
    }
}