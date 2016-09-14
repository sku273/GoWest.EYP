CREATE PROCEDURE [dbo].[InsertQuestion]
	@Question VARCHAR(2000),
	@QuestionType VARCHAR(100),
	@DefaultAnswerValues VARCHAR(MAX)
AS
BEGIN
	DECLARE @questionTypeId INT = (SELECT Id FROM QuestionType WHERE Name = @QuestionType)
	INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES (@Question, @questionTypeId, @DefaultAnswerValues)
END