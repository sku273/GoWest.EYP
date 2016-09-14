CREATE PROCEDURE [dbo].[GetSubordinateListByManagerId]
	@ManagerId VARCHAR(50)
AS
BEGIN
	SELECT [Id]
      ,[Name]
      ,[Project]
      ,[ManagerId]
	  ,[Email]
	FROM [Employee]
	WHERE ManagerId = @ManagerId
END