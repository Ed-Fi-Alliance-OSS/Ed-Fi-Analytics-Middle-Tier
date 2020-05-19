-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


WITH attendanceData as (
	SELECT 
		(
			SELECT 
				MAX(Absent)
			FROM (VALUES
					([ews_StudentEarlyWarningFact].[IsAbsentFromSchoolUnexcused])
					,([ews_StudentEarlyWarningFact].[IsAbsentFromHomeroomUnexcused])
					--,([ews_StudentEarlyWarningFact].[IsAbsentFromAnyClassUnexcused])
				) as value(Absent)
		) as [IsUnexcused],
		(
			SELECT 
				MAX(Absent)
			FROM (VALUES
					([ews_StudentEarlyWarningFact].[IsAbsentFromSchoolExcused])
					,([ews_StudentEarlyWarningFact].[IsAbsentFromHomeroomExcused])
					--,([ews_StudentEarlyWarningFact].[IsAbsentFromAnyClassExcused])
				) as value(Absent)
		) as [IsExcused],
		(
			SELECT 
				MAX(Absent)
			FROM (VALUES
					([ews_StudentEarlyWarningFact].[IsTardyToSchool])
					,([ews_StudentEarlyWarningFact].[IsTardyToHomeroom])
					--,([ews_StudentEarlyWarningFact].[IsAbsentFromAnyClassExcused])
				) as value(Absent)
		) as [IsTardy],
		(
			SELECT 
				MAX(Absent)
			FROM (VALUES
					 ([ews_StudentEarlyWarningFact].[IsAbsentFromSchoolExcused])
					,([ews_StudentEarlyWarningFact].[IsAbsentFromSchoolUnexcused])
					,([ews_StudentEarlyWarningFact].[IsAbsentFromHomeroomExcused])
					,([ews_StudentEarlyWarningFact].[IsAbsentFromHomeroomUnexcused])
					--,([ews_StudentEarlyWarningFact].[IsAbsentFromAnyClassExcused])
					--,([ews_StudentEarlyWarningFact].[IsAbsentFromAnyClassUnexcused])
				) as value(Absent)
		) as [IsAbsent],
		[IsEnrolled],
		[DateKey]
	FROM 
		[analytics].[ews_StudentEarlyWarningFact]
	WHERE 
			[StudentKey] = '100106833'
		AND [IsInstructionalDay] = 1
		AND [IsEnrolled] = 1
		AND [DateKey] <= '20111031'
		--AND [DateKey] <= '20110908'
)
SELECT
	SUM([IsUnexcused]) as [UnexcusedAbsences],
	SUM([IsExcused]) as [ExcusedAbsences],
	SUM([IsTardy]) as [Tardies],
	SUM([IsAbsent]) as [DaysAbsent],
	SUM(CASE WHEN [DateKey] <= '20111031' THEN [IsAbsent] ELSE 0 END) as [DaysAbsentPowerBI],
	SUM([IsEnrolled]) as [DaysEnrolled],
	(CAST(SUM([IsEnrolled]) as DECIMAL) - CAST(SUM([IsAbsent]) as DECIMAL)) / CAST(SUM([IsEnrolled]) as DECIMAL) as AttendanceRate,
	-- This is how PowerBI calculats, but this is not right. It is calculating days absent for a month and dividing by 
	-- total number of days in the year.
	(CAST(SUM([IsEnrolled]) as DECIMAL) - CAST(SUM(CASE WHEN [DateKey] <= '20111031' THEN [IsAbsent] ELSE 0 END) as DECIMAL)) / CAST(SUM([IsEnrolled]) as DECIMAL) as AttendanceRatePowerBi
FROM attendanceData 
