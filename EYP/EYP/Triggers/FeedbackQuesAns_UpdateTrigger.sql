CREATE TRIGGER [FeedbackQuesAns_UpdateTrigger]
	ON [dbo].[FeedbackQuesAns]
	FOR UPDATE, INSERT
	AS
	BEGIN
		INSERT INTO FeedbackQuesAnsHistory SELECT * FROM inserted
	END
