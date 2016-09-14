CREATE TYPE [dbo].[IssueType] AS TABLE
(
	[Id] INT NULL,
	[IssueDesc] VARCHAR(MAX) NOT NULL, 
    [ActionItem] VARCHAR(100) NULL, 
    [OwnerId] VARCHAR(50) NULL, 
    [DueDate] DATETIME NULL, 
    [Status] VARCHAR(20) NULL
)
