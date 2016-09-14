CREATE TABLE [dbo].[IssueHistory]
(
	[Id] INT NOT NULL, 
    [EmpId] VARCHAR(50) NOT NULL, 
    [ManagerId] VARCHAR(50) NOT NULL, 
	[IssueDesc] VARCHAR(MAX) NOT NULL, 
    [ActionItem] VARCHAR(100) NULL, 
    [OwnerId] VARCHAR(50) NULL, 
    [DueDate] DATETIME NULL, 
    [Status] VARCHAR(20) NULL, 
    [CreatedDate] DATETIME NOT NULL, 
	CONSTRAINT [FK_IssueHistory_Issue] FOREIGN KEY ([Id]) REFERENCES [Issue]([Id]), 
    CONSTRAINT [FK_IssueHistory_Employee] FOREIGN KEY ([EmpId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_IssueHistory_EmployeeManager] FOREIGN KEY ([ManagerId]) REFERENCES [Employee]([Id]),
	CONSTRAINT [FK_IssueHistory_Owner] FOREIGN KEY ([OwnerId]) REFERENCES [Employee]([Id])
)
