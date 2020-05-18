-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

--------------------------------
-- MOST RECENT
--------------------------------



/*
Math grades are the average of all edfi.Grade[NumericGradeEarned] for a particular section and grading period, where the corresponding course's edfi.AcademicSubjectType[CodeValue] is "Mathematics". 

At-Risk : English Grade < 65.00  OR  Math Grade < 65.00
Early Warning : English Grade < 72.00  OR  Math Grade < 72.00
On-Track : English Grade > 72  AND  Math Grade > 72

select [StudentUSI] from [edfi].[student] where [FirstName] = 'Aaron' AND [LastSurname] = 'Clayton'

Aaron Botello = 100082604		no English
Aaron Buckingham = 100085104	has both English and Math
Aaron Carmen = 100074057		no English
*/


SELECT
	--[ews_StudentSectionGradeFact].*,
	 --[StudentSectionDim].[Subject]
	AVG([ews_StudentSectionGradeFact].[NumericGradeEarned]) as [NumericGradeEarned]
FROM
	[analytics].[StudentSectionDim] 
INNER JOIN
	[analytics].[MostRecentGradingPeriod] ON
		[StudentSectionDim].[SchoolKey] = [MostRecentGradingPeriod].[SchoolKey]	
INNER JOIN
	[analytics].[ews_StudentSectionGradeFact] ON
		[ews_StudentSectionGradeFact].[StudentSectionKey] = [StudentSectionDim].[StudentSectionKey]
	--AND [StudentSectionDim].[Subject] = 'Mathematics'
	--AND [StudentSectionDim].[Subject] IN ('English Language Arts', 'Reading', 'Writing')
INNER JOIN
	[analytics].[GradingPeriodDim] ON
		[ews_StudentSectionGradeFact].[GradingPeriodKey] = [GradingPeriodDim].[GradingPeriodKey]
	AND [MostRecentGradingPeriod].[GradingPeriodBeginDateKey] = [GradingPeriodDim].[GradingPeriodBeginDateKey]
WHERE
	[ews_StudentSectionGradeFact].[StudentKey] = 100085104


/*
Aaron Buckingham = 100085104
Overall: 80.20
Math: 64
English: 83

In PowerBI, this student is reported with
Overall: 84.25
Math: 64
English: 83

Thus far unable to determine why the overall scores aren't matching between the two. Seen this with several students.

PowerBI / Tabular Data Model solution pulls data for most recent grading period at most granular level (grade type = progress report).
Doing the same thing with the dimensional views.

!! The calculations performed with these views and in this script appear to be the correct ones !!
*/

SELECT MAX([BeginDate]) FROM [edfi].[GradingPeriod]
-- 2012-04-09

SELECT 
	[GradingPeriodBeginDate],
	[LocalCourseCode],
	[BeginDate],
	[NumericGradeEarned]
FROM 
	[edfi].[Grade]
WHERE 
	[StudentUSI] = 100085104
AND [GradeTypeId] = 4 /* Grading Period */
AND [GradingPeriodBeginDate] = '2012-04-09'


/*
GradingPeriodBeginDate	LocalCourseCode	BeginDate	NumericGradeEarned
2012-04-09				LERR08			2012-01-09	83.00  <-- english
2012-04-09				PEDRG8			2012-01-09	95.00
2012-04-09				TSSR08			2012-03-20	75.00
2012-04-09				MHRR08			2012-01-09	64.00  <-- math
2012-04-09				SCIR08			2012-01-09	84.00
*/
select avg(grade)
from (
	select grade from (values (83.0),(95.0),(75.0),(64.0),(84.0)) as value(grade)
) a
/* result: 80.2, just as calculated with the dimensional views */




--------------------------------
-- Trend
--------------------------------

SELECT
	[GradingPeriodDim].[GradingPeriodBeginDateKey],
	[DateDim].[MonthName] + ' ' + CAST([DateDim].[CalendarYear] as nvarchar) as [Month],
	AVG([ews_StudentSectionGradeFact].[NumericGradeEarned]) as [NumericGradeEarned]
FROM
	[analytics].[ews_StudentSectionGradeFact]
INNER JOIN
	[analytics].[GradingPeriodDim] ON
		[ews_StudentSectionGradeFact].[GradingPeriodKey] = [GradingPeriodDim].[GradingPeriodKey]
INNER JOIN
	[analytics].[DateDim] ON
		[GradingPeriodDim].[GradingPeriodEndDateKey] = [DateDim].[DateKey]

INNER JOIN
	[analytics].[StudentSectionDim] ON
		[ews_StudentSectionGradeFact].[StudentSectionKey] = [StudentSectionDim].[StudentSectionKey]
	--AND [StudentSectionDim].[Subject] = 'Mathematics'
	--AND [StudentSectionDim].[Subject] IN ('English Language Arts', 'Reading', 'Writing')
WHERE
	[ews_StudentSectionGradeFact].[StudentKey] = '100085104'
GROUP BY
	[GradingPeriodDim].[GradingPeriodBeginDateKey],
	[DateDim].[CalendarYear],
	[DateDim].[MonthName]
ORDER BY
	[GradingPeriodDim].[GradingPeriodBeginDateKey]



