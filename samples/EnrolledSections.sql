-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Does not return precisely the same data as the PowerBI starter kit v1.
-- This appears to be due to bugs in the Tabular Data Model supporting 
-- the v1 starter kit. For example, there is no English grade in the PowerBI
-- section list, even when Power BI displays an overall English grade 
-- indicator. That indicator is matching with the result from the query
-- below; therefore the problem is clearly in the old solution and not
-- something about this query.


SELECT
	[StudentSectionDim].[Subject],
	[StudentSectionDim].[LocalCourseCode],
	[StudentSectionDim].[CourseTitle],
	[StudentSectionDim].[TeacherName],
	AVG([ews_StudentSectionGradeFact].[NumericGradeEarned]) as [NumericGradeEarned]
FROM
	[analytics].[StudentSectionDim]
INNER JOIN
	[analytics].[ews_StudentSectionGradeFact] ON
		[ews_StudentSectionGradeFact].[StudentSectionKey] = [StudentSectionDim].[StudentSectionKey]
	--AND [StudentSectionDim].[Subject] = 'Mathematics'
	--AND [StudentSectionDim].[Subject] IN ('English Language Arts', 'Reading', 'Writing')
INNER JOIN
	[analytics].[GradingPeriodDim] ON
		[ews_StudentSectionGradeFact].[GradingPeriodKey] = [GradingPeriodDim].[GradingPeriodKey]
INNER JOIN
	[analytics].[MostRecentGradingPeriod] ON
		[ews_StudentSectionGradeFact].[SchoolKey] = [MostRecentGradingPeriod].[SchoolKey]
	AND [GradingPeriodDim].[GradingPeriodBeginDateKey] = [MostRecentGradingPeriod].[GradingPeriodBeginDateKey]

WHERE
	[ews_StudentSectionGradeFact].[StudentKey] = '100085104'

GROUP BY
	[StudentSectionDim].[Subject],
	[StudentSectionDim].[LocalCourseCode],
	[StudentSectionDim].[CourseTitle],
	[StudentSectionDim].[TeacherName]