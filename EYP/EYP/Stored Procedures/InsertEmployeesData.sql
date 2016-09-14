CREATE PROCEDURE [dbo].[InsertEmployeesData]
	@employeeData EmployeeType READONLY
AS
BEGIN
	INSERT INTO Employee (Id, Name, Project, ManagerId, Email, IsManager) 
	(SELECT Id, Name, Project, ManagerId, Email, IsManager FROM @employeeData WHERE Id NOT IN (SELECT Id FROM Employee));

	UPDATE E SET E.Name = d.Name, E.Project = d.Project, e.ManagerId = d.ManagerId, e.Email = d.Email, e.IsManager = d.IsManager
	FROM Employee E
	INNER JOIN @employeeData d
	ON E.Id = d.Id
END
