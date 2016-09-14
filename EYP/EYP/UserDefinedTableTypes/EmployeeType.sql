CREATE TYPE [dbo].[EmployeeType] AS TABLE
(
	[Id] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(100) NOT NULL, 
    [Project] VARCHAR(100) NOT NULL, 
    [ManagerId] VARCHAR(50) NULL, 
    [Email] VARCHAR(100) NOT NULL, 
    [IsManager] BIT NOT NULL
)
