CREATE TYPE [dbo].[TrainingPlanType] AS TABLE
(
	[Id] INT NULL,
    [TrainingArea] VARCHAR(100) NOT NULL, 
    [TrainingProgram] VARCHAR(100) NOT NULL, 
    [Remarks] VARCHAR(MAX) NULL, 
    [Timeframe] VARCHAR(50) NULL, 
    [ClosedMonth] VARCHAR(50) NULL, 
    [Status] VARCHAR(20) NULL
)
