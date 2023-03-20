-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW analytics.DateDim AS

	WITH dates as (
		SELECT DISTINCT Date,
			CAST(SchoolYear AS VARCHAR)  as SchoolYear
		FROM edfi.CalendarDateCalendarEvent
	)
	SELECT
		CAST(EXTRACT(YEAR FROM Date) AS VARCHAR(4)) 
			|| 
				CASE 
					WHEN EXTRACT(MONTH FROM Date) BETWEEN 1 AND 9 THEN '0' || CAST(EXTRACT(MONTH FROM Date) as VARCHAR(4))
					ELSE CAST(EXTRACT(MONTH FROM Date) as varchar(2))
				END
			|| 
				CASE 
					WHEN EXTRACT(DAY FROM Date) BETWEEN 1 AND 9 THEN '0' || CAST(EXTRACT(DAY FROM Date) as VARCHAR(4))
					ELSE CAST(EXTRACT(DAY FROM Date) as varchar(2))
				END as DateKey,
		CAST(Date as date) as Date,
		RIGHT(CONCAT('OO',CAST(EXTRACT(DAY FROM Date) AS VARCHAR)), 2) as Day,
		RIGHT(CONCAT('OO',CAST(EXTRACT(MONTH FROM Date) AS VARCHAR)), 2) as Month,
		to_char(Date, 'Month') as MonthName,
		CAST(CASE 
			WHEN EXTRACT(MONTH FROM Date) BETWEEN 1 AND 3 THEN 1
			WHEN EXTRACT(MONTH FROM Date) BETWEEN 4 AND 6 THEN 2
			WHEN EXTRACT(MONTH FROM Date) BETWEEN 7 AND 9 THEN 3
			WHEN EXTRACT(MONTH FROM Date) BETWEEN 10 AND 12 THEN 4
		END AS VARCHAR) as CalendarQuarter,
		CASE 
			WHEN EXTRACT(MONTH FROM Date) BETWEEN 1 AND 3 THEN 'First'
			WHEN EXTRACT(MONTH FROM Date) BETWEEN 4 AND 6 THEN 'Second'
			WHEN EXTRACT(MONTH FROM Date) BETWEEN 7 AND 9 THEN 'Third'
			WHEN EXTRACT(MONTH FROM Date) BETWEEN 10 AND 12 THEN 'Fourth'
		END as CalendarQuarterName,
		CAST(EXTRACT(YEAR FROM Date) AS VARCHAR) as CalendarYear,
		CAST(SchoolYear AS VARCHAR) AS SchoolYear
	FROM dates