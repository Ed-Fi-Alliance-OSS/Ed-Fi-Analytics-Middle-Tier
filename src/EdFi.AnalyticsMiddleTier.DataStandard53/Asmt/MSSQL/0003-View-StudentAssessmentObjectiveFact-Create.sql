-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'asmt_StudentAssessmentObjectiveFact')
BEGIN
	DROP VIEW analytics.asmt_StudentAssessmentObjectiveFact
END
GO

CREATE VIEW analytics.asmt_StudentAssessmentObjectiveFact
AS
	SELECT CONCAT(SASOA.StudentUSI, '-', SASOA.IdentificationCode, '-', SASOA.AssessmentIdentifier, '-', SASOA.StudentAssessmentIdentifier, '-', SASOA.Namespace) AS StudentObjectiveAssessmentKey, 
       Assessment.AssessmentIdentifier AS AssessmentKey, 
       CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey, 
       CAST(School.SchoolId AS VARCHAR) AS SchoolKey, 
       Result AS StudentScore, 
       ResultDescriptor.Description AS ResultDataType, 
       ReportingMethodDescriptor.Description AS ReportingMethod, 
       COALESCE(PerformanceLevelDescriptor.Description, '') AS PerformanceResult
    FROM 
         edfi.StudentAssessmentStudentObjectiveAssessment SASOA
    INNER JOIN
        edfi.Assessment ON
            Assessment.AssessmentIdentifier = SASOA.AssessmentIdentifier
            AND 
            Assessment.Namespace = SASOA.Namespace
    INNER JOIN
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
    INNER JOIN
        edfi.Descriptor AS ResultDescriptor ON
            ResultDescriptor.DescriptorId = SASOASR.ResultDatatypeTypeDescriptorId
    INNER JOIN
        edfi.Descriptor AS ReportingMethodDescriptor ON
            ReportingMethodDescriptor.DescriptorId = SASOASR.AssessmentReportingMethodDescriptorId
    INNER JOIN
        edfi.Student ON
            Student.StudentUSI = SASOA.StudentUSI
    INNER JOIN
        edfi.StudentSchoolAssociation ON
            Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN
        edfi.School ON
            StudentSchoolAssociation.SchoolId = School.SchoolId
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
        edfi.Descriptor AS PerformanceLevelDescriptor ON
            PerformanceLevelDescriptor.DescriptorId = SASOAPL.PerformanceLevelDescriptorId
    WHERE(
        StudentSchoolAssociation.ExitWithdrawDate IS NULL
        OR StudentSchoolAssociation.ExitWithdrawDate >= GETDATE());