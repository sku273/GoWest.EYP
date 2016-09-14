CREATE PROCEDURE [dbo].[InsertEmployeeDNA]
	@employeeDNAData EmployeeDNAType READONLY
AS
BEGIN
	DELETE FROM EmployeeDNA WHERE EmpId IN (SELECT EmpId FROM @employeeDNAData)
	INSERT INTO EmployeeDNA (EmpId, Area, Rating, CreatedDate) SELECT EmpId, Area, Rating, GETDATE() FROM @employeeDNAData
END
