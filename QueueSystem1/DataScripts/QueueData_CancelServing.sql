CREATE PROCEDURE [dbo].[QueueData_CancelServing]
	@WorkDay DATETIME,
	@ServiceType VARCHAR(1),
	@ServiceNumber INT
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	UPDATE QueueData
	SET Canceled = 1
	WHERE
			WorkDay = @WorkDay AND
			ServiceType = @ServiceType AND
			ServiceNumber = @ServiceNumber

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH


END