-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS
          ( SELECT 
                   1
            FROM 
                 INFORMATION_SCHEMA.VIEWS
            WHERE
                    TABLE_SCHEMA = 'analytics'
                    AND
                    TABLE_NAME = 'asmt_StudentAssessmentFact'
          ) 
    BEGIN
        DROP VIEW 
             analytics.asmt_StudentAssessmentFact;
END;
GO
CREATE VIEW analytics.asmt_StudentAssessmentFact
AS
SELECT
	CONCAT(
		StudentAssessment.AssessmentIdentifier,
		'-', StudentAssessment.Namespace, 
		'-', StudentAssessment.StudentAssessmentIdentifier, 
		'-', StudentAssessmentScoreResult.AssessmentReportingMethodDescriptorId,
		'-', AssessmentPerformanceLevel.PerformanceLevelDescriptorId,
		'-', StudentAssessmentStudentObjectiveAssessment.IdentificationCode,
		'-', StudentAssessmentStudentObjectiveAssessmentScoreResult.AssessmentReportingMethodDescriptorId,
		'-', StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.PerformanceLevelDescriptorId,
		'-', Student.StudentUniqueId,
		'-', StudentSchoolAssociation.SchoolId,
		'-', CONVERT(NVARCHAR, StudentSchoolAssociation.EntryDate, 112)
	) AS StudentAssessmentFactKey,
	CONCAT(
		StudentAssessment.AssessmentIdentifier, 
		'-', StudentAssessment.Namespace, 
		'-', StudentAssessment.StudentAssessmentIdentifier, 
		'-', StudentAssessment.StudentUSI
	) AS StudentAssessmentKey,
	CASE WHEN StudentAssessmentStudentObjectiveAssessment.StudentUSI IS NULL
		THEN ''
        ELSE CONCAT(
			StudentAssessmentStudentObjectiveAssessment.StudentUSI, 
			'-', StudentAssessmentStudentObjectiveAssessment.IdentificationCode, 
			'-', StudentAssessmentStudentObjectiveAssessment.AssessmentIdentifier, 
			'-', StudentAssessmentStudentObjectiveAssessment.StudentAssessmentIdentifier, 
			'-', StudentAssessmentStudentObjectiveAssessment.Namespace
	)
    END AS StudentObjectiveAssessmentKey,
    CASE WHEN StudentAssessmentStudentObjectiveAssessment.AssessmentIdentifier IS NULL
        THEN ''
        ELSE CONCAT(
			StudentAssessmentStudentObjectiveAssessment.AssessmentIdentifier, 
			'-', StudentAssessmentStudentObjectiveAssessment.IdentificationCode, 
			'-', StudentAssessmentStudentObjectiveAssessment.Namespace
		)
    END AS ObjectiveAssessmentKey, 
    CONCAT(
		Assessment.AssessmentIdentifier, 
		'-', StudentAssessment.Namespace
	) AS AssessmentKey, 
    Assessment.AssessmentIdentifier, 
    StudentAssessment.Namespace, 
    StudentAssessment.StudentAssessmentIdentifier, 
    StudentAssessment.StudentUSI, 
    CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey, 
    School.SchoolId AS SchoolKey, 
    CONVERT(VARCHAR, StudentAssessment.AdministrationDate, 112) AS AdministrationDate, 
    COALESCE(WhenAssessedGradeLevelDescriptor.CodeValue,'') as AssessedGradeLevel,
    COALESCE(StudentAssessmentScoreResult.Result, StudentAssessmentStudentObjectiveAssessmentScoreResult.Result, '') AS StudentScore, 
    COALESCE(ResultDatatypeTypeDescriptorDist.Description, ResultDescriptor.Description, '') AS ResultDataType, 
    COALESCE(AssessmentReportingMethodDescriptorDist.Description, ReportingMethodDescriptor.Description, '') AS ReportingMethod, 
    COALESCE(PerformanceLevelDescriptorDist.Description, PerformanceLevelDescriptorObj.Description, '') AS PerformanceResult
FROM

	edfi.StudentAssessment
INNER JOIN
    edfi.Assessment ON
        StudentAssessment.AssessmentIdentifier = Assessment.AssessmentIdentifier
    AND
        StudentAssessment.Namespace = Assessment.Namespace
INNER JOIN
    edfi.Student ON
        StudentAssessment.StudentUSI = Student.StudentUSI
INNER JOIN
    edfi.StudentSchoolAssociation ON
        Student.StudentUSI = StudentSchoolAssociation.StudentUSI
INNER JOIN
    edfi.Descriptor AS EntryGradeLevelDescriptor ON
        StudentSchoolAssociation.EntryGradeLevelDescriptorId = EntryGradeLevelDescriptor.DescriptorId
INNER JOIN
    edfi.School ON
        StudentSchoolAssociation.SchoolId = School.SchoolId
LEFT JOIN edfi.Descriptor AS WhenAssessedGradeLevelDescriptor
    ON StudentAssessment.WhenAssessedGradeLevelDescriptorId = WhenAssessedGradeLevelDescriptor.DescriptorId
LEFT JOIN
    edfi.StudentAssessmentScoreResult ON
        StudentAssessment.AssessmentIdentifier = StudentAssessmentScoreResult.AssessmentIdentifier
    AND
        StudentAssessment.Namespace = StudentAssessmentScoreResult.Namespace
    AND
        StudentAssessment.StudentAssessmentIdentifier = StudentAssessmentScoreResult.StudentAssessmentIdentifier
    AND
        StudentAssessment.StudentUSI = StudentAssessmentScoreResult.StudentUSI
LEFT JOIN
    edfi.AssessmentPerformanceLevel ON
        StudentAssessment.AssessmentIdentifier = AssessmentPerformanceLevel.AssessmentIdentifier
    AND
        StudentAssessment.Namespace = AssessmentPerformanceLevel.Namespace
	AND
        StudentAssessmentScoreResult.AssessmentReportingMethodDescriptorId = AssessmentPerformanceLevel.AssessmentReportingMethodDescriptorId
    AND
        AssessmentPerformanceLevel.MaximumScore >= StudentAssessmentScoreResult.Result
	AND
        AssessmentPerformanceLevel.MinimumScore <= StudentAssessmentScoreResult.Result
LEFT JOIN
    edfi.ResultDatatypeTypeDescriptor ON
        StudentAssessmentScoreResult.ResultDatatypeTypeDescriptorId = ResultDatatypeTypeDescriptor.ResultDatatypeTypeDescriptorId
LEFT JOIN
    edfi.Descriptor AS ResultDatatypeTypeDescriptorDist ON
        ResultDatatypeTypeDescriptor.ResultDatatypeTypeDescriptorId = ResultDatatypeTypeDescriptorDist.DescriptorId
LEFT JOIN
    edfi.AssessmentReportingMethodDescriptor ON
        StudentAssessmentScoreResult.AssessmentReportingMethodDescriptorId = AssessmentReportingMethodDescriptor.AssessmentReportingMethodDescriptorId
LEFT JOIN
    edfi.Descriptor AS AssessmentReportingMethodDescriptorDist ON
        AssessmentReportingMethodDescriptor.AssessmentReportingMethodDescriptorId = AssessmentReportingMethodDescriptorDist.DescriptorId
LEFT JOIN
    edfi.PerformanceLevelDescriptor ON
        AssessmentPerformanceLevel.PerformanceLevelDescriptorId = PerformanceLevelDescriptor.PerformanceLevelDescriptorId
LEFT JOIN
    edfi.Descriptor AS PerformanceLevelDescriptorDist ON
        PerformanceLevelDescriptor.PerformanceLevelDescriptorId = PerformanceLevelDescriptorDist.DescriptorId
LEFT JOIN
    edfi.StudentAssessmentStudentObjectiveAssessment ON
        StudentAssessment.AssessmentIdentifier = StudentAssessmentStudentObjectiveAssessment.AssessmentIdentifier
    AND
        StudentAssessment.Namespace = StudentAssessmentStudentObjectiveAssessment.Namespace
    AND
        StudentAssessment.StudentAssessmentIdentifier = StudentAssessmentStudentObjectiveAssessment.StudentAssessmentIdentifier
    AND
        StudentAssessment.StudentUSI = StudentAssessmentStudentObjectiveAssessment.StudentUSI
LEFT JOIN
    edfi.StudentAssessmentStudentObjectiveAssessmentScoreResult ON
		StudentAssessmentStudentObjectiveAssessment.AssessmentIdentifier = StudentAssessmentStudentObjectiveAssessmentScoreResult.AssessmentIdentifier
    AND
        StudentAssessmentStudentObjectiveAssessment.IdentificationCode = StudentAssessmentStudentObjectiveAssessmentScoreResult.IdentificationCode
    AND
		StudentAssessmentStudentObjectiveAssessment.Namespace = StudentAssessmentStudentObjectiveAssessmentScoreResult.Namespace
    AND
		StudentAssessmentStudentObjectiveAssessment.StudentAssessmentIdentifier = StudentAssessmentStudentObjectiveAssessmentScoreResult.StudentAssessmentIdentifier
    AND
		StudentAssessmentStudentObjectiveAssessment.StudentUSI = StudentAssessmentStudentObjectiveAssessmentScoreResult.StudentUSI
LEFT JOIN
    edfi.Descriptor AS ResultDescriptor ON
        ResultDescriptor.DescriptorId = StudentAssessmentStudentObjectiveAssessmentScoreResult.ResultDatatypeTypeDescriptorId
LEFT JOIN
    edfi.Descriptor AS ReportingMethodDescriptor ON
        ReportingMethodDescriptor.DescriptorId = StudentAssessmentStudentObjectiveAssessmentScoreResult.AssessmentReportingMethodDescriptorId
LEFT JOIN
    edfi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel ON
        StudentAssessmentStudentObjectiveAssessment.StudentUSI = StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.StudentUSI
    AND
        StudentAssessmentStudentObjectiveAssessment.IdentificationCode = StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.IdentificationCode
    AND
        StudentAssessmentStudentObjectiveAssessment.AssessmentIdentifier = StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.AssessmentIdentifier
    AND
        StudentAssessmentStudentObjectiveAssessment.StudentAssessmentIdentifier = StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.StudentAssessmentIdentifier
    AND
        StudentAssessmentStudentObjectiveAssessment.Namespace = StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.Namespace
LEFT JOIN
    edfi.Descriptor AS PerformanceLevelDescriptorObj ON
        PerformanceLevelDescriptorObj.DescriptorId = StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.PerformanceLevelDescriptorId
WHERE(
        StudentSchoolAssociation.ExitWithdrawDate IS NULL
	OR
        StudentSchoolAssociation.ExitWithdrawDate >= GETDATE());