CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(500) NOT NULL, 
    [Type] INT NOT NULL, 
    [DefaultAnswerValues] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Question_QuestionType] FOREIGN KEY ([Type]) REFERENCES [QuestionType]([Id])
)
