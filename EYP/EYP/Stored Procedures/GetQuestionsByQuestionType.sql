CREATE PROCEDURE [dbo].[GetQuestionsByQuestionType]
	@QuestionType VARCHAR(100)
AS
BEGIN
	SELECT
		q.Id, 
		q.Name AS Question, 
		qt.Name AS QuestionType,
		q.DefaultAnswerValues
	FROM Question q
	INNER JOIN QuestionType qt
	ON q.Type = qt.Id
	AND qt.Name = @QuestionType
END