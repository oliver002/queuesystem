CREATE PROCEDURE [dbo].[QueueData_Insert]
(
	@WorkDay			DATETIME,
	@ServiceType		VARCHAR(1),
	@StartWaitingTime	DATETIME,
	@Serviced			BIT = 0,
	@Canceled			BIT = 0,
	@StartServicingTime	DATETIME = NULL,
	@EndServicingTime	DATETIME = NULL,
	@ServicedBy			VARCHAR(1) = NULL
)
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION

	DECLARE @ServiceNumber INT
	SET @ServiceNumber = ISNULL((SELECT MAX(ServiceNumber)+1 FROM QueueData WHERE WorkDay = @WorkDay) , 1)

	INSERT QueueData
	(
		WorkDay,			
		ServiceNumber,		
		ServiceType,		
		StartWaitingTime,	
		Serviced,			
		Canceled,			
		StartServicingTime,	
		EndServicingTime,	
		ServicedBy			
	)
	VALUES
	(	
		@WorkDay,			
		@ServiceNumber,		
		@ServiceType,		
		@StartWaitingTime,	
		@Serviced,			
		@Canceled,			
		@StartServicingTime,	
		@EndServicingTime,	
		@ServicedBy	
	)

	COMMIT TRANSACTION

	SELECT * FROM QueueData
	WHERE Id = SCOPE_IDENTITY()
	
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END

GO