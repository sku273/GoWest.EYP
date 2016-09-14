CREATE PROCEDURE [dbo].[GetEmployeeByEmpId]
	@EmpId VARCHAR(50)
AS
BEGIN
	SELECT e.Id,
		e.Name,
		e.Project,
		e.ManagerId,
		m.Name AS ManagerName,
		e.Email,
		e.IsManager
	FROM Employee e
	LEFT JOIN Employee m
	ON e.ManagerId = m.Id
	WHERE e.Id = @EmpId
END