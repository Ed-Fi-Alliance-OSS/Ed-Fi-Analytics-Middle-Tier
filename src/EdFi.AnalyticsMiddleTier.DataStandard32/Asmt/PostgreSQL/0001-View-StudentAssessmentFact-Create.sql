-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE VIEW analytics.asmt_StudentAssessmentFact AS

	SELECT
        StudentAssessment.StudentAssessmentIdentifier AS StudentAssessmentKey,
        Assessment.AssessmentIdentifier AS AssessmentKey,
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        School.SchoolId AS SchoolKey,
		CAST(EXTRACT(YEAR FROM StudentAssessment.AdministrationDate) AS VARCHAR(4)) 
			|| 
				CASE 
					WHEN EXTRACT(MONTH FROM StudentAssessment.AdministrationDate) BETWEEN 1 AND 9 THEN '0' || CAST(EXTRACT(MONTH FROM StudentAssessment.AdministrationDate) as VARCHAR(4))
					ELSE CAST(EXTRACT(MONTH FROM StudentAssessment.AdministrationDate) as varchar(2))
				END
			|| 
				CASE 
					WHEN EXTRACT(DAY FROM StudentAssessment.AdministrationDate) BETWEEN 1 AND 9 THEN '0' || CAST(EXTRACT(DAY FROM StudentAssessment.AdministrationDate) as VARCHAR(4))
					ELSE CAST(EXTRACT(DAY FROM StudentAssessment.AdministrationDate) as varchar(2))
				END as AdministrationDate,
		
		
        StudentAssessmentScoreResult.Result AS StudentScore,
        ResultDatatypeTypeDescriptorDist.Description AS ResultDataType,
        AssessmentReportingMethodDescriptorDist.Description AS ReportingMethod,
        PerformanceLevelDescriptorDist.Description AS PerformanceResult
    FROM
        edfi.StudentAssessment
    INNER JOIN
        edfi.Assessment
            ON StudentAssessment.AssessmentIdentifier = Assessment.AssessmentIdentifier
            AND StudentAssessment.Namespace = Assessment.Namespace
    INNER JOIN
        edfi.Student
            ON StudentAssessment.StudentUSI = Student.StudentUSI
    INNER JOIN
        edfi.StudentSchoolAssociation 
            ON Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN
        edfi.Descriptor AS EntryGradeLevelDescriptor
            ON StudentSchoolAssociation.EntryGradeLevelDescriptorId = EntryGradeLevelDescriptor.DescriptorId
    INNER JOIN
        edfi.School
            ON StudentSchoolAssociation.SchoolId = School.SchoolId
    INNER JOIN
        edfi.StudentAssessmentScoreResult
            ON StudentAssessment.AssessmentIdentifier = StudentAssessmentScoreResult.AssessmentIdentifier
               AND StudentAssessment.Namespace = StudentAssessmentScoreResult.Namespace
               AND StudentAssessment.StudentAssessmentIdentifier = StudentAssessmentScoreResult.StudentAssessmentIdentifier
               AND StudentAssessment.StudentUSI = StudentAssessmentScoreResult.StudentUSI
    INNER JOIN
        edfi.AssessmentPerformanceLevel
            ON Assessment.AssessmentIdentifier = AssessmentPerformanceLevel.AssessmentIdentifier
                AND Assessment.Namespace = AssessmentPerformanceLevel.Namespace
                AND AssessmentPerformanceLevel.MaximumScore >= StudentAssessmentScoreResult.Result
                AND AssessmentPerformanceLevel.MinimumScore <= StudentAssessmentScoreResult.Result
    INNER JOIN
        edfi.ResultDatatypeTypeDescriptor
            ON StudentAssessmentScoreResult.ResultDatatypeTypeDescriptorId = ResultDatatypeTypeDescriptor.ResultDatatypeTypeDescriptorId
    INNER JOIN
        edfi.Descriptor AS ResultDatatypeTypeDescriptorDist
            ON ResultDatatypeTypeDescriptor.ResultDatatypeTypeDescriptorId = ResultDatatypeTypeDescriptorDist.DescriptorId
    INNER JOIN
        edfi.AssessmentReportingMethodDescriptor
            ON StudentAssessmentScoreResult.AssessmentReportingMethodDescriptorId = AssessmentReportingMethodDescriptor.AssessmentReportingMethodDescriptorId
    INNER JOIN
        edfi.Descriptor AS AssessmentReportingMethodDescriptorDist
            ON AssessmentReportingMethodDescriptor.AssessmentReportingMethodDescriptorId = AssessmentReportingMethodDescriptorDist.DescriptorId
    INNER JOIN
        edfi.PerformanceLevelDescriptor
            ON AssessmentPerformanceLevel.PerformanceLevelDescriptorId = PerformanceLevelDescriptor.PerformanceLevelDescriptorId
    INNER JOIN
        edfi.Descriptor AS PerformanceLevelDescriptorDist
            ON PerformanceLevelDescriptor.PerformanceLevelDescriptorId = PerformanceLevelDescriptorDist.DescriptorId
    WHERE(
        StudentSchoolAssociation.ExitWithdrawDate IS NULL
        OR StudentSchoolAssociation.ExitWithdrawDate >= now());