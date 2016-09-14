CREATE PROCEDURE [dbo].[GetEmployeeFeedbackByEmpId]
	@EmpId VARCHAR(50)
	--@managerId INT
AS
BEGIN
	SELECT f.[Id]
      ,f.[EmpId]
	  ,e.Name AS EmployeeName
      ,f.[ManagerId]
	  ,m.Name AS ManagerName
      ,f.[QuestionId]
	  ,q.Name AS Question
	  ,qt.Name AS QuestionType
      ,[Answer]
      ,[RatingScale]
	  ,f.[CreatedDate]
  FROM [FeedbackQuesAns] f
  INNER JOIN Employee e
  on f.EmpId = e.Id
  AND e.Id = @EmpId
  LEFT JOIN Employee m
  on f.ManagerId = m.Id
  AND m.Id = @EmpId
  --AND f.ManagerId = @managerId
  INNER JOIN Question q
  on f.QuestionId = q.Id
  INNER JOIN QuestionType qt
  on q.Type = qt.Id

  --SELECT a.[Id]
  --    ,[EmpId]
  --    ,a.[ManagerId]
  --    ,[ActionItemDesc]
  --    ,[Owner]
  --    ,[DueDate]
  --    ,[Status]
	 -- ,[Remarks]
  --FROM [ActionItem] a
  --INNER JOIN Employee e
  --on a.EmpId = e.Id
  --AND e.Id = @EmpId
  --LEFT JOIN Employee m
  --on a.ManagerId = m.ManagerId
  --AND a.ManagerId = @managerId

  SELECT i.[Id]
      ,[EmpId]
	  ,e.Name AS EmployeeName
      ,i.[ManagerId]
	  ,m.Name AS ManagerName
      ,[IssueDesc]
      ,[ActionItem]
      ,[OwnerId]
	  ,o.Name AS OwnerName
      ,[DueDate]
      ,[Status]
	  ,i.CreatedDate
  FROM [Issue] i
  INNER JOIN Employee e
  on i.EmpId = e.Id
  AND e.Id = @EmpId
  LEFT JOIN Employee o
  on i.OwnerId = o.Id
  AND o.Id = @EmpId
  LEFT JOIN Employee m
  on i.ManagerId = m.ManagerId
  AND m.Id = @EmpId
  --AND i.ManagerId = @managerId

  SELECT t.[Id]
      ,[EmpId]
	  ,e.Name AS EmployeeName
      ,t.[ManagerId]
	  ,m.Name AS ManagerName
      ,[TrainingArea]
      ,[TrainingProgram]
      ,[Remarks]
      ,[Timeframe]
      ,[ClosedMonth]
      ,[Status]
	  ,t.CreatedDate
  FROM [TrainingPlan] t
  INNER JOIN Employee e
  on t.EmpId = e.Id
  AND e.Id = @EmpId
  LEFT JOIN Employee m
  on t.ManagerId = m.ManagerId
  AND m.Id = @EmpId
  --AND t.ManagerId = @managerId

  SELECT EmpId, 
		Area, 
		Rating 
  FROM EmployeeDNA
  WHERE EmpId = @empId
  --AND CreatedDate = (SELECT MAX(CreatedDate) FROM EmployeeDNA WHERE EmpId = @empId)

  SELECT e.Id,
		e.Name,
		e.Project,
		e.ManagerId,
		m.Name AS ManagerName,
		e.Email,
		e.IsManager
	FROM Employee e
	LEFT JOIN Employee m
	ON e.ManagerId = m.Id
	WHERE e.Id = @EmpId
END