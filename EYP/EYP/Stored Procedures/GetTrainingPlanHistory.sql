CREATE PROCEDURE [dbo].[GetTrainingPlanHistory]
	@TrainingPlanId INT
AS
BEGIN
	SELECT [Id]
      ,[EmpId]
      ,[ManagerId]
      ,[TrainingArea]
      ,[TrainingProgram]
      ,[Remarks]
      ,[Timeframe]
      ,[ClosedMonth]
      ,[Status]
      ,[CreatedDate]
  FROM [TrainingPlanHistory]
  WHERE Id = @TrainingPlanId
  ORDER BY CreatedDate DESC
END