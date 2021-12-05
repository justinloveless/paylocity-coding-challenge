CREATE TABLE [dbo].[Employees]
(
    EmployeeId int identity primary key,
    FirstName varchar(50) not null,
    LastName varchar(50) not null,
    Salary decimal not null
)
