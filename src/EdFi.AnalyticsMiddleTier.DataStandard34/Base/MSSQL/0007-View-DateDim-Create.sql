-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'DateDim')
BEGIN
	DROP VIEW analytics.DateDim
END
GO
CREATE VIEW analytics.DateDim AS

	WITH dates as (
		SELECT DISTINCT Date,
			CAST(SchoolYear AS VARCHAR)  as SchoolYear
		FROM edfi.CalendarDateCalendarEvent
	)
	SELECT
		CONVERT(varchar, Date, 112) as DateKey,
		CAST(CONVERT(varchar, Date, 1) as DATETIME) as Date,
		RIGHT(CONCAT('00', CAST(DAY([Date]) AS VARCHAR)), 2) as [Day],
		RIGHT(CONCAT('00', CAST(MONTH([Date]) AS VARCHAR)), 2) as [Month],
		DATENAME(month, Date) as MonthName,
		CAST(CASE 
			WHEN MONTH(Date) BETWEEN 1 AND 3 THEN 1
			WHEN MONTH(Date) BETWEEN 4 AND 6 THEN 2
			WHEN MONTH(Date) BETWEEN 7 AND 9 THEN 3
			WHEN MONTH(Date) BETWEEN 10 AND 12 THEN 4
		END AS VARCHAR) as CalendarQuarter,
		CASE 
			WHEN MONTH(Date) BETWEEN 1 AND 3 THEN 'First'
			WHEN MONTH(Date) BETWEEN 4 AND 6 THEN 'Second'
			WHEN MONTH(Date) BETWEEN 7 AND 9 THEN 'Third'
			WHEN MONTH(Date) BETWEEN 10 AND 12 THEN 'Fourth'
		END as CalendarQuarterName,
		CAST(YEAR(Date) AS VARCHAR) as CalendarYear,
		CAST(SchoolYear AS VARCHAR) AS SchoolYear
	FROM dates