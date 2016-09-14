CREATE TABLE [dbo].[FeedbackQuesAnsHistory]
(
	[Id] INT NOT NULL, 
    [EmpId] VARCHAR(50) NOT NULL, 
    [ManagerId] VARCHAR(50) NOT NULL, 
    [QuestionId] INT NOT NULL, 
    [Answer] VARCHAR(MAX) NULL, 
    [RatingScale] INT NULL, 
    [CreatedDate] DATETIME NULL, 
	CONSTRAINT [FK_FeedbackQuesAnsHistory_FeedbackQuesAns] FOREIGN KEY ([Id]) REFERENCES [FeedbackQuesAns]([Id]), 
    CONSTRAINT [FK_FeedbackQuesAnsHistory_Employee] FOREIGN KEY ([EmpId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_FeedbackQuesAnsHistory_EmployeeManager] FOREIGN KEY ([ManagerId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_FeedbackQuesAnsHistory_Question] FOREIGN KEY ([QuestionId]) REFERENCES [Question]([Id]),

)
