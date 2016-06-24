CREATE PROCEDURE [dbo].[QueueData_GetNextNumber]
(
	@WorkDay			DATETIME,
	@ServiceType		VARCHAR(1),	
	@StartServicingTime	DATETIME = NULL	
)
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION

	DECLARE @OppositeServiceType VARCHAR(1)
	SET @OppositeServiceType = CASE WHEN @ServiceType = 'A' THEN 'B' ELSE 'A' END
	
	DECLARE @IdToUpdate INT

	IF EXISTS(SELECT * FROM QueueData WHERE WorkDay = @WorkDay AND ServiceType = @ServiceType AND StartServicingTime IS NULL)
	BEGIN
		SELECT 
			@IdToUpdate = Id
		FROM QueueData
		WHERE WorkDay = @WorkDay
			  AND ServiceNumber = (SELECT MIN(ServiceNumber) FROM QueueData WHERE WorkDay = @WorkDay AND ServiceType = @ServiceType AND StartServicingTime IS NULL)
	END ELSE IF EXISTS(SELECT * FROM QueueData WHERE WorkDay = @WorkDay AND ServiceType = @OppositeServiceType AND StartServicingTime IS NULL)
	BEGIN
		SELECT 
			@IdToUpdate = Id
		FROM QueueData
		WHERE WorkDay = @WorkDay
			  AND ServiceNumber = (SELECT MIN(ServiceNumber) FROM QueueData WHERE WorkDay = @WorkDay AND ServiceType = @OppositeServiceType AND StartServicingTime IS NULL)
	END ELSE
	BEGIN
		SELECT * FROM QueueData WHERE Id = -1
		COMMIT TRANSACTION
		RETURN
	END

	UPDATE QueueData
	SET 
		ServicedBy = @ServiceType, -- ServiceType serves this client
		StartServicingTime = @StartServicingTime
	WHERE 
		Id = @IdToUpdate

	SELECT * 
	FROM 
		QueueData
	WHERE 
		Id = @IdToUpdate

	COMMIT TRANSACTION
	
	
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END

GO