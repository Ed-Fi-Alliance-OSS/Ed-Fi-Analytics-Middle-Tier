﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'asmt_StudentAssessmentFact')
BEGIN
	DROP VIEW analytics.asmt_StudentAssessmentFact
END
GO

CREATE VIEW analytics.asmt_StudentAssessmentFact AS

	SELECT
        CONCAT(StudentAssessment.AssessmentIdentifier, '-', StudentAssessment.Namespace, '-', StudentAssessment.StudentAssessmentIdentifier, '-', StudentAssessment.StudentUSI) AS StudentAssessmentKey,
        CONCAT(Assessment.AssessmentIdentifier, '-', StudentAssessment.Namespace) AS AssessmentKey,
        Assessment.AssessmentIdentifier,
        StudentAssessment.Namespace,
        StudentAssessment.StudentAssessmentIdentifier,
        StudentAssessment.StudentUSI,
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        School.SchoolId AS SchoolKey,
        CONVERT(varchar, StudentAssessment.AdministrationDate, 112) as AdministrationDate,
        COALESCE(StudentAssessmentScoreResult.Result,'') AS StudentScore,
        COALESCE(ResultDatatypeTypeDescriptorDist.Description,'') AS ResultDataType,
        COALESCE(AssessmentReportingMethodDescriptorDist.Description,'') AS ReportingMethod,
        COALESCE(PerformanceLevelDescriptorDist.Description,'') AS PerformanceResult
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
    WHERE(
        StudentSchoolAssociation.ExitWithdrawDate IS NULL
        OR StudentSchoolAssociation.ExitWithdrawDate >= GETDATE());