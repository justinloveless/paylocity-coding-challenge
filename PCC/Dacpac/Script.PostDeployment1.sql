/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (select * from Employees)
    begin
        insert into Employees (FirstName, LastName, Salary)
        values
            (
                'Justin', 'Loveless', 52000
            ),
            (
                'Nicholas', 'Lee', 52000
            ),
            (
                'Lois', 'Foster', 52000
            ),
            (
                'Albert', 'Diaz', 52000
            ),
            (
                'Ashley', 'Ross', 52000
            )
    end

if not exists (select * from Dependants )
    begin
        insert into Dependants (FirstName, LastName)
        values
            (
                'Paula', 'Loveless'
            ),
            (
                'Mildred', 'Loveless'
            ),
            (
                'Debra', 'Foster'
            ),
            (
                'Ruby', 'Diaz'
            ),
            (
                'Frank', 'Diaz'
            ),
            (
                'Jennifer', 'Diaz'
            ),
            (
                'Fred', 'Ross'
            )
    end

if not exists (select * from EmployeeDependantRelations)
    begin
        insert into EmployeeDependantRelations (EmployeeId, DependantId, RelationType)
        values
            (
                1, 1, 'child'
            ),
            (
                1, 2, 'spouse'
            ),
            (
                3, 3, 'spouse'
            ),
            (
                4, 4, 'spouse'
            ),
            (
                4, 5, 'child'
            ),
            (
                4, 6, 'child'
            ),
            (
                5, 7, 'spouse'
            )
    end 


