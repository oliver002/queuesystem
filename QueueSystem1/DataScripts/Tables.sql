CREATE TABLE QueueData(
	ID			INT IDENTITY(1,1) NOT NULL,		
	WorkDay		DATETIME NOT NULL,
	ServiceNumber INT NOT NULL,
	ServiceType VARCHAR(1) NOT NULL,
	StartWaitingTime DATETIME NOT NULL,
	Serviced	BIT NOT NULL,
	Canceled	BIT NOT NULL,
	StartServicingTime	DATETIME NULL,
	EndServicingTime	DATETIME NULL,
	ServicedBy	VARCHAR(1) NULL
);