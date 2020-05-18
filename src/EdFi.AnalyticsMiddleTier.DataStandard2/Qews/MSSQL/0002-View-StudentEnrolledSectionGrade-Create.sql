﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW [analytics].[qews_StudentEnrolledSectionGrade] AS

	SELECT
		[ews_StudentSectionGradeFact].[StudentKey],
		[ews_StudentSectionGradeFact].[SchoolKey],
		[StudentSectionDim].[Subject],
		[StudentSectionDim].[LocalCourseCode],
		[StudentSectionDim].[CourseTitle],
		[StudentSectionDim].[TeacherName],
		[StudentSectionDim].[SectionKey],
		AVG([ews_StudentSectionGradeFact].[NumericGradeEarned]) as [NumericGradeEarned]
	FROM
		[analytics].[StudentSectionDim]
	INNER JOIN
		[analytics].[ews_StudentSectionGradeFact] ON
			[ews_StudentSectionGradeFact].[StudentSectionKey] = [StudentSectionDim].[StudentSectionKey]
	INNER JOIN
		[analytics].[GradingPeriodDim] ON
			[ews_StudentSectionGradeFact].[GradingPeriodKey] = [GradingPeriodDim].[GradingPeriodKey]
	INNER JOIN
		[analytics].[MostRecentGradingPeriod] ON
			[ews_StudentSectionGradeFact].[SchoolKey] = [MostRecentGradingPeriod].[SchoolKey]
		AND [GradingPeriodDim].[GradingPeriodBeginDateKey] = [MostRecentGradingPeriod].[GradingPeriodBeginDateKey]
	GROUP BY
		[ews_StudentSectionGradeFact].[StudentKey],
		[ews_StudentSectionGradeFact].[SchoolKey],
		[StudentSectionDim].[Subject],
		[StudentSectionDim].[LocalCourseCode],
		[StudentSectionDim].[CourseTitle],
		[StudentSectionDim].[TeacherName],
		[StudentSectionDim].[SectionKey]

