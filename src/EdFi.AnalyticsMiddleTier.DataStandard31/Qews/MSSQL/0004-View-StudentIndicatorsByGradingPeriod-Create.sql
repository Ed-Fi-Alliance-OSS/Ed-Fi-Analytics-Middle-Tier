-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW [analytics].[qews_StudentIndicatorsByGradingPeriod] AS

	WITH [thresholds] as (

		SELECT
			[GradeAtRisk],
			[GradeEarlyWarning],
			[AttendanceAtRisk],
			[AttendanceEarlyWarning],
			[OffenseAtRisk],
			[ConductAtRisk],
			[ConductEarlyWarning]
		FROM
			[analytics_config].[QuickSightEWS]

	), [gradingPeriods] as (
		
		SELECT
			[SchoolKey],
			[GradingPeriodBeginDateKey],
			[GradingPeriodEndDateKey],
			[GradingPeriodKey]
		FROM
			[analytics].[GradingPeriodDim]


	), [grades] as (

		SELECT
			[StudentSectionDim].[StudentKey],
			CASE WHEN [StudentSectionDim].[Subject] = 'Mathematics' THEN 'Math' 
				 WHEN [StudentSectionDim].[Subject] IN ('English Language Arts', 'Reading', 'Writing') THEN 'English' END as [Subject],
			[ews_StudentSectionGradeFact].[NumericGradeEarned],
			[StudentSectionDim].[SchoolKey],
			[gradingPeriods].[GradingPeriodBeginDateKey],
			[gradingPeriods].[GradingPeriodEndDateKey]
		FROM
			[analytics].[StudentSectionDim] 
		INNER JOIN
			[analytics].[ews_StudentSectionGradeFact] ON
				[ews_StudentSectionGradeFact].[StudentSectionKey] = [StudentSectionDim].[StudentSectionKey]
		INNER JOIN
			[gradingPeriods] ON
				[ews_StudentSectionGradeFact].[GradingPeriodKey] = [gradingPeriods].[GradingPeriodKey]
			AND [ews_StudentSectionGradeFact].[SchoolKey] = [gradingPeriods].[SchoolKey]

	), [averages] as (

		SELECT
			[StudentKey],
			[SchoolKey],
			AVG(CASE WHEN [Subject] = 'Math' THEN [NumericGradeEarned] ELSE NULL END) as [MathGrade],
			AVG(CASE WHEN [Subject] = 'English' THEN [NumericGradeEarned] ELSE NULL END) as [EnglishGrade],
			AVG([NumericGradeEarned]) as [OverallGrade],
			[grades].[GradingPeriodEndDateKey]
		FROM
			[grades]
		GROUP BY
			[StudentKey],
			[SchoolKey],
			[grades].[GradingPeriodEndDateKey]

	), [attendanceData] as (

		SELECT 
			[ews_StudentEarlyWarningFact].[StudentKey],
			[ews_StudentEarlyWarningFact].[SchoolKey],
			(
				SELECT 
					MAX(Absent)
				FROM (VALUES
						 ([ews_StudentEarlyWarningFact].[IsAbsentFromSchoolExcused])
						,([ews_StudentEarlyWarningFact].[IsAbsentFromSchoolUnexcused])
						,([ews_StudentEarlyWarningFact].[IsAbsentFromHomeroomExcused])
						,([ews_StudentEarlyWarningFact].[IsAbsentFromHomeroomUnexcused])
						-- For EWS demo system, only looking at: either marked as absent from school, or from home room.
						-- Those who are customizing may wish to change from home room to any class.
						--,([ews_StudentEarlyWarningFact].[IsAbsentFromAnyClassExcused])
						--,([ews_StudentEarlyWarningFact].[IsAbsentFromAnyClassUnexcused])
					) as value(Absent)
			) as [IsAbsent],
			[ews_StudentEarlyWarningFact].[IsEnrolled],
			[gradingPeriods].[GradingPeriodEndDateKey]
		FROM 
			[analytics].[ews_StudentEarlyWarningFact]
		INNER JOIN
			[gradingPeriods] ON
				[ews_StudentEarlyWarningFact].[DateKey] > [gradingPeriods].[GradingPeriodBeginDateKey]
			AND [ews_StudentEarlyWarningFact].[DateKey] <= [gradingPeriods].[GradingPeriodEndDateKey]
			AND [ews_StudentEarlyWarningFact].[SchoolKey] = [gradingPeriods].[SchoolKey]
		WHERE 
			[ews_StudentEarlyWarningFact].[IsInstructionalDay] = 1
		AND [ews_StudentEarlyWarningFact].[IsEnrolled] = 1

	), [rate] as (

		SELECT
			[StudentKey],
			[SchoolKey],
			[GradingPeriodEndDateKey],
			(CAST(SUM([IsEnrolled]) as DECIMAL) - CAST(SUM([IsAbsent]) as DECIMAL)) / CAST(SUM([IsEnrolled]) as DECIMAL) as [AttendanceRate]
		FROM 
			[attendanceData]
		GROUP BY
			[StudentKey],
			[SchoolKey],
			[GradingPeriodEndDateKey]

	), [offenses] as (

		SELECT
			[ews_StudentEarlyWarningFact].[StudentKey],
			[ews_StudentEarlyWarningFact].[SchoolKey],
			[gradingPeriods].[GradingPeriodEndDateKey],
			SUM(ISNULL([ews_StudentEarlyWarningFact].[CountByDayOfStateOffenses],0)) as [StateOffenses],
			SUM(ISNULL([ews_StudentEarlyWarningFact].[CountByDayOfConductOffenses],0)) as [CodeOfConductOffenses]
		FROM
			[analytics].[ews_StudentEarlyWarningFact]
		INNER JOIN
			[gradingPeriods] ON
				[ews_StudentEarlyWarningFact].[DateKey] > [gradingPeriods].[GradingPeriodBeginDateKey]
			AND [ews_StudentEarlyWarningFact].[DateKey] <= [gradingPeriods].[GradingPeriodEndDateKey]
			AND [ews_StudentEarlyWarningFact].[SchoolKey] = [gradingPeriods].[SchoolKey]
		GROUP BY
			[ews_StudentEarlyWarningFact].[StudentKey],
			[ews_StudentEarlyWarningFact].[SchoolKey],
			[gradingPeriods].[GradingPeriodEndDateKey]

	), [indicators] as (

		SELECT
	
			[rate].[StudentKey],
			[rate].[SchoolKey],
			[DateDim].[CalendarYear],
			[DateDim].[Month],
			[MathGrade],
			[EnglishGrade],
			[OverallGrade],
			[AttendanceRate],

			CASE WHEN [MathGrade] < [thresholds].[GradeAtRisk] OR [EnglishGrade] < [thresholds].[GradeAtRisk] THEN 'At risk'
				WHEN [MathGrade] < [thresholds].[GradeEarlyWarning] OR [EnglishGrade] < [thresholds].[GradeEarlyWarning] Then 'Early warning'
				ELSE 'On track'
			END as [GradeIndicator],

			CASE WHEN [AttendanceRate] < [thresholds].[AttendanceAtRisk] THEN 'At risk'
				 WHEN [AttendanceRate] < [thresholds].[AttendanceEarlyWarning] THEN 'Early warning'
				 ELSE 'On track'
			END as [AttendanceIndicator],

			CASE WHEN [offenses].[StateOffenses] > [thresholds].[OffenseAtRisk] OR [offenses].[CodeOfConductOffenses] > [thresholds].[ConductAtRisk] THEN 'At risk'
				 WHEN [offenses].[CodeOfConductOffenses] > [thresholds].[ConductEarlyWarning] THEN 'Early warning'
				 ELSE 'On track'
			End as [BehaviorIndicator]

		FROM
			[rate] 
		LEFT OUTER JOIN
			[averages] ON
				[rate].[StudentKey] = [averages].[StudentKey] 
			AND [rate].[SchoolKey] = [averages].[SchoolKey]
			AND [rate].[GradingPeriodEndDateKey] = [averages].[GradingPeriodEndDateKey]
		LEFT OUTER JOIN
			[offenses] ON
				[rate].[StudentKey] = [offenses].[StudentKey]
			AND [rate].[SchoolKey] = [offenses].[SchoolKey]
			AND [rate].[GradingPeriodEndDateKey] = [offenses].[GradingPeriodEndDateKey]
		INNER JOIN
			[analytics].[DateDim] ON
				[rate].[GradingPeriodEndDateKey] = [DateDim].[DateKey]
		CROSS APPLY
			[thresholds]

	)
	SELECT
		[StudentKey],
		[SchoolKey],
		[CalendarYear],
		[Month],
		[MathGrade],
		[EnglishGrade],
		[OverallGrade],
		[AttendanceRate],
		[GradeIndicator],
		[AttendanceIndicator],
		[BehaviorIndicator],
		CASE WHEN [GradeIndicator] = 'At risk' OR [AttendanceIndicator] = 'At risk' OR [BehaviorIndicator] = 'At risk' THEN 'At Risk'
			 WHEN [GradeIndicator] = 'Early warning' OR [AttendanceIndicator] = 'Early warning' OR [BehaviorIndicator] = 'Early warning' THEN 'Early warning'
			 ELSE 'On track'
		END as [OverallIndicator]
	FROM
		[indicators]