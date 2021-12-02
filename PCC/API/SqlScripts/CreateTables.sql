if not exists (select * 
    from INFORMATION_SCHEMA.TABLES 
        WHERE TABLE_SCHEMA = 'dbo' 
        AND TABLE_NAME = 'Employees')
begin
create table Employees (
    EmployeeId int identity primary key,
    FirstName varchar(50) not null,
    LastName varchar(50) not null,
    Salary decimal not null
)
end

if not exists (select *
               from INFORMATION_SCHEMA.TABLES
               WHERE TABLE_SCHEMA = 'dbo'
                 AND TABLE_NAME = 'Dependants')
    begin
create table Dependants (
    DependantId int identity primary key,
    FirstName varchar(50) not null,
    LastName varchar(50) not null
)
end

if not exists (select *
               from INFORMATION_SCHEMA.TABLES
               WHERE TABLE_SCHEMA = 'dbo'
                 AND TABLE_NAME = 'EmployeeDependantRelations')
    begin
create table EmployeeDependantRelations (
    EmployeeId int not null,
    DependantId int not null,
    RelationType varchar(10) check(RelationType in ('child', 'spouse'))
    primary key (EmployeeId, DependantId)
)
end