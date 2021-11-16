﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW analytics.qews_StudentEnrolledSectionGradeTrend AS 

	WITH grades as (

		SELECT
			StudentSectionDim.StudentKey,
			StudentSectionDim.SchoolKey,
			CASE WHEN StudentSectionDim.Subject = 'Mathematics' THEN 'Math' 
				 WHEN StudentSectionDim.Subject IN ('English Language Arts', 'Reading', 'Writing') THEN 'English' END as Subject,
			CONCAT(DateDim.CalendarYear, '-', FORMAT(DateDim.Month, '00')) as Month,
			ews_StudentSectionGradeFact.NumericGradeEarned
		FROM
			analytics.StudentSectionDim 
		INNER JOIN
			analytics.ews_StudentSectionGradeFact ON
				ews_StudentSectionGradeFact.StudentSectionKey = StudentSectionDim.StudentSectionKey
		INNER JOIN
			analytics.GradingPeriodDim ON
				ews_StudentSectionGradeFact.GradingPeriodKey = GradingPeriodDim.GradingPeriodKey
		INNER JOIN
			analytics.DateDim ON
				GradingPeriodDim.GradingPeriodBeginDateKey = DateDim.DateKey

	)
	SELECT
		grades.StudentKey,
		grades.SchoolKey,
		StudentSchoolDim.StudentFirstName 
			+ ' ' + StudentSchoolDim.StudentMiddleName
			+ ' ' + StudentSchoolDim.StudentLastName
			as StudentName,
		grades.Month,
		AVG(CASE WHEN grades.Subject = 'Math' THEN grades.NumericGradeEarned ELSE NULL END) as MathGrade,
		AVG(CASE WHEN grades.Subject = 'English' THEN grades.NumericGradeEarned ELSE NULL END) as EnglishGrade,
		AVG(grades.NumericGradeEarned) as OverallGrade
	FROM
		grades
	INNER JOIN
		analytics.StudentSchoolDim ON
			grades.StudentKey = StudentSchoolDim.StudentKey
	GROUP BY
		grades.StudentKey,
		grades.SchoolKey,
		StudentSchoolDim.StudentFirstName,
		StudentSchoolDim.StudentMiddleName,
		StudentSchoolDim.StudentLastName,
		grades.Month
