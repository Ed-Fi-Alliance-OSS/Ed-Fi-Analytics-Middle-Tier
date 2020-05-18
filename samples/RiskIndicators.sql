-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

--------------------------------
-- Grades At Risk
--------------------------------

DECLARE @GradeAtRiskThreshold DECIMAL(5,2) = 65.0;
DECLARE @GradeEarlyWarningThreshold DECIMAL(5,2) = 72.0;

WITH [grades] as (
	SELECT
		[StudentSectionDim].[StudentKey],
		CASE WHEN [StudentSectionDim].[Subject] = 'Mathematics' THEN 'Math' ELSE 'English' END as [Subject],
		[ews_StudentSectionGradeFact].[NumericGradeEarned]
	FROM
		[analytics].[StudentSectionDim] 
	INNER JOIN
		[analytics].[MostRecentGradingPeriod] ON
			[StudentSectionDim].[SchoolKey] = [MostRecentGradingPeriod].[SchoolKey]	
	INNER JOIN
		[analytics].[ews_StudentSectionGradeFact] ON
			[ews_StudentSectionGradeFact].[StudentSectionKey] = [StudentSectionDim].[StudentSectionKey]
	INNER JOIN
		[analytics].[GradingPeriodDim] ON
			[ews_StudentSectionGradeFact].[GradingPeriodKey] = [GradingPeriodDim].[GradingPeriodKey]
		AND [MostRecentGradingPeriod].[GradingPeriodBeginDateKey] = [GradingPeriodDim].[GradingPeriodBeginDateKey]
	WHERE
		[StudentSectionDim].[Subject] IN ('Mathematics','English Language Arts', 'Reading', 'Writing')
), [averages] as (
	SELECT
		[StudentKey],
		AVG(CASE WHEN [Subject] = 'Math' THEN [NumericGradeEarned] ELSE NULL END) as [MathGrade],
		AVG(CASE WHEN [Subject] = 'English' THEN [NumericGradeEarned] ELSE NULL END) as [EnglishGrade]
	FROM
		[grades]
	GROUP BY
		[StudentKey]
)
SELECT
	CASE WHEN [MathGrade] < @GradeAtRiskThreshold OR [EnglishGrade] < @GradeAtRiskThreshold THEN 'At risk'
		WHEN [MathGrade] < @GradeEarlyWarningThreshold OR [EnglishGrade] < @GradeEarlyWarningThreshold Then 'Early warning'
		ELSE 'On track'
	END as [GradeIndicator]
FROM
	[averages]
WHERE
	[StudentKey] = '100072411'


--------------------------------
-- Attendance
--------------------------------


DECLARE @AttendanceAtRiskThreshold as DECIMAL(5,2) = 0.80;
DECLARE @AttendanceEarlyWarningThreshold as DECIMAL(5,2) = 0.88;


WITH [attendanceData] as (
	SELECT 
		[StudentKey],
		(
			SELECT 
				MAX(Absent)
			FROM (VALUES
					 ([ews_StudentEarlyWarningFact].[IsAbsentFromSchoolExcused])
					,([ews_StudentEarlyWarningFact].[IsAbsentFromSchoolUnexcused])
					,([ews_StudentEarlyWarningFact].[IsAbsentFromHomeroomExcused])
					,([ews_StudentEarlyWarningFact].[IsAbsentFromHomeroomUnexcused])
				) as value(Absent)
		) as [IsAbsent],
		[IsEnrolled],
		[DateKey]
	FROM 
		[analytics].[ews_StudentEarlyWarningFact]
	WHERE 
		[IsInstructionalDay] = 1
	AND [IsEnrolled] = 1
), [rate] as (
	SELECT
		[StudentKey],
		(CAST(SUM([IsEnrolled]) as DECIMAL) - CAST(SUM([IsAbsent]) as DECIMAL)) / CAST(SUM([IsEnrolled]) as DECIMAL) as [AttendanceRate]
	FROM 
		[attendanceData] 
	GROUP BY
		[StudentKey]
)
SELECT
	CASE WHEN [AttendanceRate] < @AttendanceAtRiskThreshold THEN 'At risk'
		 WHEN [AttendanceRate] < @AttendanceEarlyWarningThreshold THEN 'Early warning'
		 ELSE 'On track'
	END as [AttendanceIndicator]
FROM
	[rate]
WHERE
	[StudentKey] = '100072411'


--------------------------------
-- Behavior
--------------------------------

-- *any* state offense can be considered a risk, and there is no early waning
DECLARE @StateOffenseRisk as INT = 0;

DECLARE @CodeOfConductAtRiskThreshold as INT = 5;
DECLARE @CodeOfConductEarlyWarningThreshold as INT = 2;

WITH [totalcounts] as (
	SELECT
		[StudentKey],
		SUM(ISNULL([CountByDayOfStateOffenses],0)) as [StateOffenses],
		SUM(ISNULL([CountByDayOfConductOffenses],0)) as [CodeOfConductOffenses]
	FROM
		[analytics].[ews_StudentEarlyWarningFact]
	GROUP BY
		[StudentKey]
)
SELECT
	CASE WHEN [StateOffenses] > @StateOffenseRisk OR [CodeOfConductOffenses] > @CodeOfConductAtRiskThreshold THEN 'At risk'
		 WHEN [CodeOfConductOffenses] > @CodeOfConductEarlyWarningThreshold THEN 'Early warning'
		 ELSE 'On track'
	End as [BehaviorIndicator]
FROM
	[totalcounts]
WHERE
	[StudentKey] = '100072411'

