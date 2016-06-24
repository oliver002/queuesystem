CREATE PROCEDURE [dbo].[QueueDataDiffCounter_GetReportByDate]
	@WorkDay DATETIME
AS
BEGIN

	SELECT 
		COUNT(ID) 'NumberOfServicedPersons',		
		ServicedBy
	FROM
		QueueData q
	WHERE
		q.WorkDay = @WorkDay
		AND q.ServicedBy <> q.ServiceType
	GROUP BY q.ServicedBy	

END
