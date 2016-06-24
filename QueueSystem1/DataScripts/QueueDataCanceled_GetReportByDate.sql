CREATE PROCEDURE [dbo].[QueueDataCanceled_GetReportByDate]
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
		AND q.Canceled = 1		
	GROUP BY q.ServicedBy	

END
