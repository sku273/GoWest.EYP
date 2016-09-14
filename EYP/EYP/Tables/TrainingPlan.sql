CREATE TABLE [dbo].[TrainingPlan]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	[EmpId] VARCHAR(50) NOT NULL, 
    [ManagerId] VARCHAR(50) NOT NULL, 
    [TrainingArea] VARCHAR(100) NOT NULL, 
    [TrainingProgram] VARCHAR(100) NOT NULL, 
    [Remarks] VARCHAR(MAX) NULL, 
    [Timeframe] VARCHAR(50) NULL, 
    [ClosedMonth] VARCHAR(50) NULL, 
    [Status] VARCHAR(20) NULL,
	[CreatedDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_TrainingPlan_Employee] FOREIGN KEY ([EmpId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_TrainingPlan_EmployeeManager] FOREIGN KEY ([ManagerId]) REFERENCES [Employee]([Id]), 
)
