CREATE TABLE [dbo].[TrainingPlanHistory]
(
	[Id] INT NOT NULL, 
	[EmpId] VARCHAR(50) NOT NULL, 
    [ManagerId] VARCHAR(50) NOT NULL, 
    [TrainingArea] VARCHAR(100) NOT NULL, 
    [TrainingProgram] VARCHAR(100) NOT NULL, 
    [Remarks] VARCHAR(MAX) NULL, 
    [Timeframe] VARCHAR(50) NULL, 
    [ClosedMonth] VARCHAR(50) NULL, 
    [Status] VARCHAR(20) NULL,
	[CreatedDate] DATETIME NOT NULL, 
	CONSTRAINT [FK_TrainingPlanHistory_TrainingPlan] FOREIGN KEY ([Id]) REFERENCES [TrainingPlan]([Id]), 
    CONSTRAINT [FK_TrainingPlanHistory_Employee] FOREIGN KEY ([EmpId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_TrainingPlanHistory_EmployeeManager] FOREIGN KEY ([ManagerId]) REFERENCES [Employee]([Id]), 
)
