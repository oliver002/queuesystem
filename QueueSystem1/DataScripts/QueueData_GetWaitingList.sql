CREATE PROCEDURE [dbo].[QueueData_GetWaitingList]
	@WorkDay DATETIME
AS
BEGIN

	SELECT 
		ServiceType,
		ServiceNumber
	FROM
		QueueData q
	WHERE
		q.WorkDay = @WorkDay
		AND q.ServicedBy IS NULL		
	ORDER BY ServiceType, ServiceNumber

END