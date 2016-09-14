CREATE TRIGGER [Issue_UpdateTrigger]
	ON [dbo].[Issue]
	FOR UPDATE, INSERT
	AS
	BEGIN
		INSERT INTO IssueHistory SELECT * FROM inserted
	END
