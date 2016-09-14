CREATE PROCEDURE [dbo].[GetFeedbackQuesAnsHistory]
	@empId VARCHAR(50),
	@questionId int
AS
BEGIN
	SELECT [Id]
      ,[EmpId]
      ,[ManagerId]
      ,[QuestionId]
      ,[Answer]
      ,[RatingScale]
      ,[CreatedDate]
	FROM FeedbackQuesAnsHistory
	WHERE QuestionId = @questionId
	AND EmpId = @empId
	ORDER BY CreatedDate DESC
END