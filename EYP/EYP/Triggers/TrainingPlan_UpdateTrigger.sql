CREATE TRIGGER [TrainingPlan_UpdateTrigger]
	ON [dbo].[TrainingPlan]
	FOR UPDATE, INSERT
	AS
	BEGIN
		INSERT INTO TrainingPlanHistory SELECT * FROM inserted
	END
