CREATE TABLE [dbo].[EmployeeDependantRelations]
(
    EmployeeId int not null,
    DependantId int not null,
    RelationType varchar(10) check(RelationType in ('child', 'spouse'))
    primary key (EmployeeId, DependantId)
)
