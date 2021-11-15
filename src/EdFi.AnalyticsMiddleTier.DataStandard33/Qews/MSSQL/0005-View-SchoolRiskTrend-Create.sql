-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW analytics.qews_SchoolRiskTrend AS

	WITH risk as (

		SELECT
			StudentIndicatorsByGradingPeriod.SchoolKey,
			StudentIndicatorsByGradingPeriod.StudentKey,
			StudentIndicatorsByGradingPeriod.CalendarYear,
			StudentIndicatorsByGradingPeriod.Month,
			CASE WHEN StudentIndicatorsByGradingPeriod.GradeIndicator = 'At risk'
					OR StudentIndicatorsByGradingPeriod.AttendanceIndicator = 'At risk'
					OR StudentIndicatorsByGradingPeriod.BehaviorIndicator = 'At risk'
				THEN 1
				ELSE 0
				END as AtRisk,
			CASE WHEN StudentIndicatorsByGradingPeriod.GradeIndicator = 'Early warning'
					OR StudentIndicatorsByGradingPeriod.AttendanceIndicator = 'Early warning'
					OR StudentIndicatorsByGradingPeriod.BehaviorIndicator = 'Early warning'
				THEN 1
				ELSE 0
				END as EarlyWarning,
			1 as Enrolled
		FROM
			analytics.qews_StudentIndicatorsByGradingPeriod as StudentIndicatorsByGradingPeriod

	), riskByGradingPeriod as (

		SELECT
			risk.SchoolKey,
			risk.CalendarYear,
			risk.Month,
			SUM(Enrolled) as Enrolled,
			SUM(AtRisk) as AtRisk,
			SUM(EarlyWarning) as EarlyWarning
		FROM
			risk
		GROUP BY
			risk.SchoolKey,
			risk.CalendarYear,
			risk.Month

	)
	SELECT
		SchoolKey,
		CONCAT(CalendarYear,'-',FORMAT(Month, '00')) as YearMonth,
		1.0 - (CAST(Enrolled as DECIMAL) - CAST(EarlyWarning as DECIMAL))/CAST(Enrolled as DECIMAL) as PercentEarlyWarning,
		1.0 - (CAST(Enrolled as DECIMAL) - CAST(AtRisk as DECIMAL))/CAST(Enrolled as DECIMAL) as PercentAtRisk,
		Enrolled,
		EarlyWarning,
		AtRisk
	FROM
		riskByGradingPeriod
