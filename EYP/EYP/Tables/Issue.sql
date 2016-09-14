CREATE TABLE [dbo].[Issue]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [EmpId] VARCHAR(50) NOT NULL, 
    [ManagerId] VARCHAR(50) NOT NULL, 
	[IssueDesc] VARCHAR(MAX) NOT NULL, 
    [ActionItem] VARCHAR(100) NULL, 
    [OwnerId] VARCHAR(50) NULL, 
    [DueDate] DATETIME NULL, 
    [Status] VARCHAR(20) NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_Issue_Employee] FOREIGN KEY ([EmpId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_Issue_EmployeeManager] FOREIGN KEY ([ManagerId]) REFERENCES [Employee]([Id]),
	CONSTRAINT [FK_Issue_Owner] FOREIGN KEY ([OwnerId]) REFERENCES [Employee]([Id])
)
