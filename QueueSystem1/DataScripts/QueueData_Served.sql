CREATE PROCEDURE [dbo].[QueueData_Served]
@WorkDay DATETIME,
@ServiceType VARCHAR(1),
@ServiceNumber INT,
@EndServicingTime DATETIME
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION
	UPDATE QueueData
	SET Serviced = 1, EndServicingTime = @EndServicingTime
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