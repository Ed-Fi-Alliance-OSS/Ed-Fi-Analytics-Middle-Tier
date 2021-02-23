-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
DROP VIEW IF EXISTS analytics.asmt_StudentAssessmentFact;

CREATE OR REPLACE VIEW analytics.asmt_StudentAssessmentFact 
AS
	SELECT
        CONCAT(StudentAssessment.AssessmentIdentifier, '-', StudentAssessment.Namespace, '-', StudentAssessment.StudentAssessmentIdentifier, '-', StudentAssessment.StudentUSI) AS StudentAssessmentKey,
		CASE WHEN SASOA.StudentUSI IS NULL THEN NULL ELSE CONCAT(SASOA.StudentUSI, '-', SASOA.IdentificationCode, '-', SASOA.AssessmentIdentifier, '-', SASOA.StudentAssessmentIdentifier, '-', SASOA.Namespace) END AS StudentObjectiveAssessmentKey,
        CASE WHEN SASOA.AssessmentIdentifier IS NULL THEN NULL ELSE CONCAT(SASOA.AssessmentIdentifier, '-', SASOA.IdentificationCode, '-', SASOA.Namespace) END AS ObjectiveAssessmentKey,
		CONCAT(Assessment.AssessmentIdentifier, '-', StudentAssessment.Namespace) AS AssessmentKey,
        Assessment.AssessmentIdentifier,
        StudentAssessment.Namespace,
        StudentAssessment.StudentAssessmentIdentifier,
        StudentAssessment.StudentUSI,
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        School.SchoolId AS SchoolKey,
        CONVERT(varchar, StudentAssessment.AdministrationDate, 112) as AdministrationDate,
        COALESCE(ISNULL(StudentAssessmentScoreResult.Result,SASOASR.Result),'') AS StudentScore,
        COALESCE(ISNULL(ResultDatatypeTypeDescriptorDist.Description,ResultDescriptor.Description),'') AS ResultDataType,
        COALESCE(ISNULL(AssessmentReportingMethodDescriptorDist.Description,ReportingMethodDescriptor.Description),'') AS ReportingMethod,
        COALESCE(ISNULL(PerformanceLevelDescriptorDist.Description,PerformanceLevelDescriptorObj.Description),'') AS PerformanceResult
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
    LEFT JOIN
        edfi.StudentAssessmentScoreResult
            ON StudentAssessment.AssessmentIdentifier = StudentAssessmentScoreResult.AssessmentIdentifier
               AND StudentAssessment.Namespace = StudentAssessmentScoreResult.Namespace
               AND StudentAssessment.StudentAssessmentIdentifier = StudentAssessmentScoreResult.StudentAssessmentIdentifier
               AND StudentAssessment.StudentUSI = StudentAssessmentScoreResult.StudentUSI
    LEFT JOIN
        edfi.AssessmentPerformanceLevel
            ON Assessment.AssessmentIdentifier = AssessmentPerformanceLevel.AssessmentIdentifier
                AND Assessment.Namespace = AssessmentPerformanceLevel.Namespace
                AND AssessmentPerformanceLevel.MaximumScore >= StudentAssessmentScoreResult.Result
                AND AssessmentPerformanceLevel.MinimumScore <= StudentAssessmentScoreResult.Result
    LEFT JOIN
        edfi.ResultDatatypeTypeDescriptor
            ON StudentAssessmentScoreResult.ResultDatatypeTypeDescriptorId = ResultDatatypeTypeDescriptor.ResultDatatypeTypeDescriptorId
    LEFT JOIN
        edfi.Descriptor AS ResultDatatypeTypeDescriptorDist
            ON ResultDatatypeTypeDescriptor.ResultDatatypeTypeDescriptorId = ResultDatatypeTypeDescriptorDist.DescriptorId
    LEFT JOIN
        edfi.AssessmentReportingMethodDescriptor
            ON StudentAssessmentScoreResult.AssessmentReportingMethodDescriptorId = AssessmentReportingMethodDescriptor.AssessmentReportingMethodDescriptorId
    LEFT JOIN
        edfi.Descriptor AS AssessmentReportingMethodDescriptorDist
            ON AssessmentReportingMethodDescriptor.AssessmentReportingMethodDescriptorId = AssessmentReportingMethodDescriptorDist.DescriptorId
    LEFT JOIN
        edfi.PerformanceLevelDescriptor
            ON AssessmentPerformanceLevel.PerformanceLevelDescriptorId = PerformanceLevelDescriptor.PerformanceLevelDescriptorId
    LEFT JOIN
        edfi.Descriptor AS PerformanceLevelDescriptorDist
            ON PerformanceLevelDescriptor.PerformanceLevelDescriptorId = PerformanceLevelDescriptorDist.DescriptorId
	LEFT JOIN
		edfi.StudentAssessmentStudentObjectiveAssessment SASOA
			ON Assessment.AssessmentIdentifier = SASOA.AssessmentIdentifier
            AND 
            Assessment.Namespace = SASOA.Namespace
	LEFT JOIN
        edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult SASOASR ON
            SASOA.StudentUSI = SASOASR.StudentUSI
            AND
            SASOA.IdentificationCode = SASOASR.IdentificationCode
            AND
            SASOA.AssessmentIdentifier = SASOASR.AssessmentIdentifier
            AND
            SASOA.StudentAssessmentIdentifier = SASOASR.StudentAssessmentIdentifier
            AND
            SASOA.Namespace = SASOASR.Namespace
	LEFT JOIN
        edfi.Descriptor AS ResultDescriptor ON
            ResultDescriptor.DescriptorId = SASOASR.ResultDatatypeTypeDescriptorId
	LEFT JOIN
        edfi.Descriptor AS ReportingMethodDescriptor ON
            ReportingMethodDescriptor.DescriptorId = SASOASR.AssessmentReportingMethodDescriptorId
	LEFT JOIN
        edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel SASOAPL ON
            SASOASR.StudentUSI = SASOAPL.StudentUSI
            AND
            SASOASR.IdentificationCode = SASOAPL.IdentificationCode
            AND
            SASOASR.AssessmentIdentifier = SASOAPL.AssessmentIdentifier
            AND
            SASOASR.StudentAssessmentIdentifier = SASOAPL.StudentAssessmentIdentifier
            AND
            SASOASR.Namespace = SASOAPL.Namespace
            AND
            SASOASR.AssessmentReportingMethodDescriptorId = SASOAPL.AssessmentReportingMethodDescriptorId
	LEFT JOIN
        edfi.Descriptor AS PerformanceLevelDescriptorObj ON
            PerformanceLevelDescriptorObj.DescriptorId = SASOAPL.PerformanceLevelDescriptorId
    WHERE(
        StudentSchoolAssociation.ExitWithdrawDate IS NULL
        OR StudentSchoolAssociation.ExitWithdrawDate >= GETDATE());
