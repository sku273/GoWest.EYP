CREATE PROCEDURE [dbo].[GetIssueHistory]
	@IssueId INT
AS
BEGIN
	SELECT i.[Id]
      ,[EmpId]
      ,i.[ManagerId]
      ,[IssueDesc]
      ,[ActionItem]
      ,e.[Name] AS OwnerName
      ,[DueDate]
      ,[Status]
      ,[CreatedDate]
  FROM [IssueHistory] i
  INNER JOIN Employee e
  ON i.OwnerId = e.Id
  WHERE i.Id = @IssueId
  ORDER BY CreatedDate DESC
END