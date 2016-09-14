CREATE PROCEDURE [dbo].[InsertEmployeeFeeback]
	@EmpId VARCHAR(50),
	@ManagerId VARCHAR(50),
	@FeedbackQuesAns FeedbackQuesAnsType READONLY,
	--@ActionItem ActionItemType READONLY,
	@Issue IssueType READONLY,
	@TrainingPlan TrainingPlanType READONLY
AS
BEGIN
	DECLARE @CreatedDate DATETIME = GETDATE()

	UPDATE T SET T.Timeframe = D.Timeframe, T.Status = D.Status, T.Remarks = D.Remarks, T.CreatedDate = @CreatedDate, T.ClosedMonth = D.ClosedMonth
	FROM TrainingPlan T
	INNER JOIN @TrainingPlan D
	ON T.Id = D.Id

	INSERT INTO TrainingPlan (EmpId, ManagerId, TrainingArea, TrainingProgram, Remarks, Timeframe, ClosedMonth, Status, CreatedDate)
		(SELECT @EmpId, @ManagerId, TrainingArea, TrainingProgram, Remarks, Timeframe, ClosedMonth, Status, @CreatedDate FROM @TrainingPlan WHERE Id NOT IN (SELECT Id FROM TrainingPlan WHERE EmpId = @EmpId))

	UPDATE F SET F.Answer = D.Answer, F.RatingScale = D.RatingScale, F.CreatedDate = @CreatedDate
	FROM FeedbackQuesAns F
	INNER JOIN @FeedbackQuesAns D
	ON F.QuestionId = D.QuestionId
	AND F.EmpId = @EmpId

	INSERT INTO FeedbackQuesAns (EmpId, ManagerId, QuestionId, Answer, RatingScale, CreatedDate)
		(SELECT @EmpId, @ManagerId, QuestionId, Answer, RatingScale, @CreatedDate FROM @FeedbackQuesAns WHERE QuestionId NOT IN (SELECT QuestionId FROM FeedbackQuesAns WHERE EmpId = @EmpId))

	--INSERT INTO ActionItem (EmpId,ManagerId, ActionItemDesc, Owner, DueDate, Status, Remarks)
	--	(SELECT @EmpId, @ManagerId, ActionItemDesc, Owner, DueDate, Status, Remarks FROM @ActionItem)

	UPDATE I SET I.Status = D.Status, I.DueDate = D.DueDate, I.CreatedDate = @CreatedDate, I.OwnerId = D.OwnerId
	FROM Issue I
	INNER JOIN @Issue D
	ON I.Id = D.Id

	INSERT INTO Issue (EmpId, ManagerId, IssueDesc, ActionItem, OwnerId, DueDate, Status, CreatedDate)
		(SELECT @EmpId, @ManagerId, IssueDesc, ActionItem, OwnerId, DueDate, Status, @CreatedDate FROM @Issue WHERE Id NOT IN (SELECT Id FROM Issue WHERE EmpId = @EmpId))
END