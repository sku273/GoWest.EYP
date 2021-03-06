﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS(SELECT 1 FROM QuestionType WHERE Name ='PerformanceFeedback')
BEGIN
	INSERT INTO QuestionType(Name) VALUES('PerformanceFeedback')
END
IF NOT EXISTS(SELECT 1 FROM QuestionType WHERE Name ='GrowthPlan')
BEGIN
	INSERT INTO QuestionType(Name) VALUES('GrowthPlan')
END
IF NOT EXISTS(SELECT 1 FROM QuestionType WHERE Name ='StabilityAnalysis')
BEGIN
	INSERT INTO QuestionType(Name) VALUES('StabilityAnalysis')
END

DECLARE @performanceFeedback INT = (SELECT Id FROM QuestionType WHERE Name='PerformanceFeedback')
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='How have you found the past year/quarter and what are the reasons for this?')
BEGIN
	INSERT INTO Question (Name, Type) VALUES('How have you found the past year/quarter and what are the reasons for this?', @performanceFeedback)
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='What do you consider to be your main achievement of the past quarter/year?')
BEGIN
INSERT INTO Question (Name, Type) VALUES('What do you consider to be your main achievement of the past quarter/year?', @performanceFeedback)
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='What factors of your role do you find most challenging?')
BEGIN
INSERT INTO Question (Name, Type) VALUES('What factors of your role do you find most challenging?', @performanceFeedback)
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='What factors of your role interest you the most?')
BEGIN
INSERT INTO Question (Name, Type) VALUES('What factors of your role interest you the most?', @performanceFeedback)
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='What do you consider to be your most important aims and tasks in the next quarter/year?')
BEGIN
INSERT INTO Question (Name, Type) VALUES('What do you consider to be your most important aims and tasks in the next quarter/year?', @performanceFeedback)
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='What steps could be taken by you to enable you to be more effective in your current role and how your People Manager can add to that?')
BEGIN
INSERT INTO Question (Name, Type) VALUES('What steps could be taken by you to enable you to be more effective in your current role and how your People Manager can add to that?', @performanceFeedback)
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='What kind of work or role would you like to be doing in one/two/five years time? i.e. think about relationships, who you would like to work with, projects that excite you etc.')
BEGIN
INSERT INTO Question (Name, Type) VALUES('What kind of work or role would you like to be doing in one/two/five years time? i.e. think about relationships, who you would like to work with, projects that excite you etc.', @performanceFeedback)
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='What sort of training/experiences would benefit you in the next year? Not just job-skills - also your natural strengths and personal passions you’d like to develop - you and your work can benefit from these.')
BEGIN
INSERT INTO Question (Name, Type) VALUES('What sort of training/experiences would benefit you in the next year? Not just job-skills - also your natural strengths and personal passions you’d like to develop - you and your work can benefit from these.', @performanceFeedback)
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Peer Feedback')
BEGIN
INSERT INTO Question (Name, Type) VALUES('Peer Feedback', @performanceFeedback)
END

DECLARE @GrowthPlan INT = (SELECT Id FROM QuestionType WHERE Name='GrowthPlan')
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Current Role')
BEGIN
INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES('Current Role', @GrowthPlan, 'Trainee, Associate L1, Associate L2, Sr.Associate L1, Sr. Associate L2, Manager')
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Next Planned Role')
BEGIN
INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES('Next Planned Role', @GrowthPlan, 'Trainee, Associate L1, Associate L2, Sr.Associate L1, Sr. Associate L2, Manager')
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Timeline')
BEGIN
INSERT INTO Question (Name, Type) VALUES('Timeline', @GrowthPlan)
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Replacement (Flight Risk & Reasons)')
BEGIN
INSERT INTO Question (Name, Type) VALUES('Replacement (Flight Risk & Reasons)', @GrowthPlan)
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Competency Status')
BEGIN
INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES('Competency Status', @GrowthPlan, 'Not Applied, Applied, Approved, Rejected')
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Current Performance')
BEGIN
INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES('Current Performance', @GrowthPlan, 'High, Medium, Low')
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Potential')
BEGIN
INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES('Potential', @GrowthPlan, 'High, Medium, Low')
END

DECLARE @StabilityAnalysis INT = (SELECT Id FROM QuestionType WHERE Name='StabilityAnalysis')
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Is the person satisfied with last Performance Review?')
BEGIN
INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES('Is the person satisfied with last Performance Review?', @StabilityAnalysis, '1,2,3,4,5')
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Is the person satisfied with current Compensation?')
BEGIN
INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES('Is the person satisfied with current Compensation?', @StabilityAnalysis, '1,2,3,4,5')
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Is the person satisified with the current work?')
BEGIN
INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES('Is the person satisified with the current work?', @StabilityAnalysis, '1,2,3,4,5')
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Is the person satisified with the growth plan?')
BEGIN
INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES('Is the person satisified with the growth plan?', @StabilityAnalysis, '1,2,3,4,5')
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Is the person satisified with the working environment?')
BEGIN
INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES('Is the person satisified with the working environment?', @StabilityAnalysis, '1,2,3,4,5')
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='Is the person looking for relocation?')
BEGIN
INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES('Is the person looking for relocation?', @StabilityAnalysis, '1,2,3,4,5')
END
IF NOT EXISTS(SELECT 1 FROM Question WHERE Name ='How is the overall morale?')
BEGIN
INSERT INTO Question (Name, Type, DefaultAnswerValues) VALUES('How is the overall morale?', @StabilityAnalysis, '1,2,3,4,5')
END