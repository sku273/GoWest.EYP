CREATE PROCEDURE [dbo].[GetEmployeesByProject]
	@projectName VARCHAR(100)
AS
BEGIN
	SELECT Id, Name, Email FROM Employee 
	WHERE Project = @projectName
END
