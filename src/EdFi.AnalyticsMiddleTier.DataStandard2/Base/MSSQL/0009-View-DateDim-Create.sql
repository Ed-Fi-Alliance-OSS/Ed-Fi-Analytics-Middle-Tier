-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW [analytics].[DateDim] AS

	WITH dates as (
		SELECT
			DISTINCT [Date],
			'Unknown' as SchoolYear
		FROM [edfi].[CalendarDateCalendarEvent]
	)
	SELECT
		CONVERT(varchar, [Date], 112) as [DateKey],
		CAST(CONVERT(varchar, [Date], 1) as DATETIME) as [Date],
		DAY([Date]) as [Day],
		MONTH([Date]) as [Month],
		DATENAME(month, [Date]) as [MonthName],
		CASE 
			WHEN MONTH([Date]) BETWEEN 1 AND 3 THEN 1
			WHEN MONTH([Date]) BETWEEN 4 AND 6 THEN 2
			WHEN MONTH([Date]) BETWEEN 7 AND 9 THEN 3
			WHEN MONTH([Date]) BETWEEN 10 AND 12 THEN 4
		END as [CalendarQuarter],
		CASE 
			WHEN MONTH([Date]) BETWEEN 1 AND 3 THEN 'First'
			WHEN MONTH([Date]) BETWEEN 4 AND 6 THEN 'Second'
			WHEN MONTH([Date]) BETWEEN 7 AND 9 THEN 'Third'
			WHEN MONTH([Date]) BETWEEN 10 AND 12 THEN 'Fourth'
		END as [CalendarQuarterName],
		YEAR([Date]) as [CalendarYear],
		SchoolYear
	FROM dates