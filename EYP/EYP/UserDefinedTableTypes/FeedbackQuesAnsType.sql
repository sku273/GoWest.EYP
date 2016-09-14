CREATE TYPE [dbo].[FeedbackQuesAnsType] AS TABLE
(
    [QuestionId] INT NOT NULL, 
    [Answer] VARCHAR(MAX) NULL, 
    [RatingScale] INT NULL
)
