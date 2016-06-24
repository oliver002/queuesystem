CREATE PROCEDURE [dbo].[QueueData_GetReportByDate]
	@WorkDay DATETIME
AS
BEGIN

	SELECT 
		COUNT(ID) 'NumberOfServicedPersons',		
		ServicedBy
	FROM
		QueueData q
	WHERE
		WorkDay = @WorkDay
	GROUP BY ServicedBy

END