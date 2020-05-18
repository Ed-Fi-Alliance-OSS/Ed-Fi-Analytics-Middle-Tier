-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW [analytics].[qews_StudentAttendanceTrend] AS 

	WITH [attendanceData] as (
		SELECT
			[StudentKey],
			[SchoolKey],
			(
				SELECT 
					MAX(Absent)
				FROM (VALUES
						 ([ews_StudentEarlyWarningFact].[IsAbsentFromSchoolExcused])
						,([ews_StudentEarlyWarningFact].[IsAbsentFromSchoolUnexcused])
						,([ews_StudentEarlyWarningFact].[IsAbsentFromHomeroomExcused])
						,([ews_StudentEarlyWarningFact].[IsAbsentFromHomeroomUnexcused])
						-- For QuickSightEWS demo system, only looking at: either marked as absent from school, or from home room.
						-- Those who are customizing may wish to change from home room to any class.
						--,([ews_StudentEarlyWarningFact].[IsAbsentFromAnyClassExcused])
						--,([ews_StudentEarlyWarningFact].[IsAbsentFromAnyClassUnexcused])
					) as value(Absent)
			) as [IsAbsent],
			[IsEnrolled],
			[DateKey]
		FROM 
			[analytics].[ews_StudentEarlyWarningFact]
		WHERE 
			[IsInstructionalDay] = 1
		AND [IsEnrolled] = 1
	)
	SELECT
		[attendanceData].[StudentKey],
		[attendanceData].[SchoolKey],
		[StudentSchoolDim].[StudentFirstName] 
			+ ' ' + [StudentSchoolDim].[StudentMiddleName]
			+ ' ' + [StudentSchoolDim].[StudentLastName]
			as [StudentName],
		CONCAT([DateDim].[CalendarYear], '-', FORMAT([DateDim].[Month], '00')) as [YearMonth],
		(CAST(SUM([IsEnrolled]) as DECIMAL) - CAST(SUM([IsAbsent]) as DECIMAL)) / CAST(SUM([IsEnrolled]) as DECIMAL) as AttendanceRate
	FROM 
		[attendanceData]
	INNER JOIN
		[analytics].[DateDim] ON
			[attendanceData].[DateKey] = [DateDim].[DateKey]
	INNER JOIN
		[analytics].[StudentSchoolDim] ON
			[attendanceData].[StudentKey] = [StudentSchoolDim].[StudentKey]
	GROUP BY
		[attendanceData].[StudentKey],
		[attendanceData].[SchoolKey],
		[StudentSchoolDim].[StudentFirstName],
		[StudentSchoolDim].[StudentMiddleName],
		[StudentSchoolDim].[StudentLastName],
		[DateDim].[CalendarYear],
		[DateDim].[Month]