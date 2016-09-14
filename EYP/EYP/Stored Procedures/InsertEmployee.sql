CREATE PROCEDURE [dbo].[InsertEmployee]
	@EmpId VARCHAR(50),
	@Name VARCHAR(100),
	@ProjectName VARCHAR(100),
	@ManagerId VARCHAR(50),
	@Email VARCHAR(100), 
	@IsManager bit
AS
BEGIN
	IF EXISTS(SELECT Id FROM Employee WHERE Id = @EmpId)
	BEGIN
		UPDATE Employee SET Project = @ProjectName, ManagerId = @ManagerId, Email= @Email, IsManager = @IsManager
		WHERE Id = @EmpId
	END
	ELSE
	BEGIN
		INSERT INTO Employee (ID, Name, Project, ManagerId, Email, IsManager) VALUES (@EmpId, @Name, @ProjectName, @ManagerId, @Email, @IsManager)
	END
END
