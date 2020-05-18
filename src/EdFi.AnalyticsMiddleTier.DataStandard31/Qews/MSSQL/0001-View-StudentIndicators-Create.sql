-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW [analytics].[qews_StudentIndicators] AS

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

	), [grades] as (

		SELECT
			[StudentSectionDim].[StudentKey],
			CASE WHEN [StudentSectionDim].[Subject] = 'Mathematics' THEN 'Math' 
				 WHEN [StudentSectionDim].[Subject] IN ('English Language Arts', 'Reading', 'Writing') THEN 'English' END as [Subject],
			[ews_StudentSectionGradeFact].[NumericGradeEarned],
			[StudentSectionDim].[SchoolKey]
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

	), [averages] as (

		SELECT
			[StudentKey],
			[SchoolKey],
			AVG(CASE WHEN [Subject] = 'Math' THEN [NumericGradeEarned] ELSE NULL END) as [MathGrade],
			AVG(CASE WHEN [Subject] = 'English' THEN [NumericGradeEarned] ELSE NULL END) as [EnglishGrade],
			AVG([NumericGradeEarned]) as [OverallGrade]
		FROM
			[grades]
		GROUP BY
			[StudentKey],
			[SchoolKey]

	), [attendanceData] as (

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
						-- For EWS demo system, only looking at: either marked as absent from school, or from home room.
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

	), [rate] as (

		SELECT
			[StudentKey],
			[SchoolKey],
			(CAST(SUM([IsEnrolled]) as DECIMAL) - CAST(SUM([IsAbsent]) as DECIMAL)) / CAST(SUM([IsEnrolled]) as DECIMAL) as [AttendanceRate]
		FROM 
			[attendanceData] 
		GROUP BY
			[StudentKey],
			[SchoolKey]

	), [totalcounts] as (

		SELECT
			[StudentKey],
			[SchoolKey],
			SUM(ISNULL([CountByDayOfStateOffenses],0)) as [StateOffenses],
			SUM(ISNULL([CountByDayOfConductOffenses],0)) as [CodeOfConductOffenses]
		FROM
			[analytics].[ews_StudentEarlyWarningFact]
		GROUP BY
			[StudentKey],
			[SchoolKey]

	), [indicators] as (

		SELECT
	
			[rate].[StudentKey],
			[rate].[SchoolKey],
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

			CASE WHEN [StateOffenses] > [thresholds].[OffenseAtRisk] OR [CodeOfConductOffenses] > [thresholds].[ConductAtRisk] THEN 'At risk'
					WHEN [CodeOfConductOffenses] > [thresholds].[ConductEarlyWarning] THEN 'Early warning'
					ELSE 'On track'
			End as [BehaviorIndicator]

		FROM
			[rate] 
		LEFT OUTER JOIN
			[averages] ON
				[rate].[StudentKey] = [averages].[StudentKey] 
			AND [rate].[SchoolKey] = [averages].[SchoolKey]
		LEFT OUTER JOIN
			[totalcounts] ON
				[rate].[StudentKey] = [totalcounts].[StudentKey]
			AND [rate].[SchoolKey] = [totalcounts].[SchoolKey]
		CROSS APPLY
			[thresholds]

	)
	SELECT
		[StudentKey],
		[SchoolKey],
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
