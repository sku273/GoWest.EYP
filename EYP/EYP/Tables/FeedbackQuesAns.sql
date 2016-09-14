CREATE TABLE [dbo].[FeedbackQuesAns]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [EmpId] VARCHAR(50) NOT NULL, 
    [ManagerId] VARCHAR(50) NOT NULL, 
    [QuestionId] INT NOT NULL, 
    [Answer] VARCHAR(MAX) NULL, 
    [RatingScale] INT NULL, 
    [CreatedDate] DATETIME NULL, 
    CONSTRAINT [FK_FeedbackQuesAns_Employee] FOREIGN KEY ([EmpId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_FeedbackQuesAns_EmployeeManager] FOREIGN KEY ([ManagerId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_FeedbackQuesAns_Question] FOREIGN KEY ([QuestionId]) REFERENCES [Question]([Id]),

)
