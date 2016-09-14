CREATE TABLE [dbo].[Employee]
(
	[Id] VARCHAR(50) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL, 
    [Project] VARCHAR(100) NOT NULL, 
    [ManagerId] VARCHAR(50) NULL, 
    [Email] VARCHAR(100) NOT NULL, 
    [IsManager] BIT NOT NULL, 
    CONSTRAINT [FK_Employee_Employee] FOREIGN KEY ([ManagerId]) REFERENCES [Employee]([Id])
)
