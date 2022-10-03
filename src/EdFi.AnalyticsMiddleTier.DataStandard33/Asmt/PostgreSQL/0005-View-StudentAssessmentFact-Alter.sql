-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
DROP VIEW IF EXISTS analytics.asmt_StudentAssessmentFact;

CREATE OR REPLACE VIEW analytics.asmt_StudentAssessmentFact 
AS
SELECT
	CONCAT(
		StudentAssessment.AssessmentIdentifier,
		'-', StudentAssessment.Namespace, 
		'-', StudentAssessment.StudentAssessmentIdentifier, 
		'-', StudentAssessmentScoreResult.AssessmentReportingMethodDescriptorId,
		'-', StudentAssessmentPerformanceLevel.PerformanceLevelDescriptorId,
		'-', StudentAssessmentStudentObjectiveAssessment.IdentificationCode,
		'-', StudentAssessmentStudentObjectiveAssessmentScoreResult.AssessmentReportingMethodDescriptorId,
		'-', StudentAssessmentStudentObjectiveAssessmentPerformanceLevel.PerformanceLevelDescriptorId,
		'-', Student.StudentUniqueId,
		'-', StudentSchoolAssociation.SchoolId,
		'-', TO_CHAR(StudentSchoolAssociation.EntryDate, 'yyyymmdd')
	) AS StudentAssessmentFactKey,
	CONCAT(
		StudentAssessment.AssessmentIdentifier, 
		'-', StudentAssessment.Namespace, 
		'-', StudentAssessment.StudentAssessmentIdentifier, 
		'-', Student.StudentUniqueId
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
    COALESCE(CAST(Student.StudentUniqueId AS VARCHAR), '') AS StudentKey,
    CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey, 
    School.SchoolId AS SchoolKey,
	TO_CHAR(StudentAssessment.AdministrationDate, 'yyyymmdd') AS AdministrationDate,
    COALESCE(WhenAssessedGradeLevelDescriptor.CodeValue,'') as AssessedGradeLevel,
	COALESCE(StudentAssessmentStudentObjectiveAssessmentScoreResult.Result, StudentAssessmentScoreResult.Result, '') AS StudentScore, 
	COALESCE(ResultDescriptor.Description, ResultDatatypeTypeDescriptorDist.Description, '') AS ResultDataType, 
	COALESCE(ReportingMethodDescriptor.Description, AssessmentReportingMethodDescriptorDist.Description, '') AS ReportingMethod, 
	COALESCE(PerformanceLevelDescriptorObj.Description, PerformanceLevelDescriptorDist.Description, '') AS PerformanceResult,
    COALESCE(StudentAssessmentScoreResult.Result, '') AS StudentAssessmentScore, 
	COALESCE(ResultDatatypeTypeDescriptorDist.Description, '') AS StudentAssessmentResultDataType, 
	COALESCE(AssessmentReportingMethodDescriptorDist.Description, '') AS StudentAssessmentReportingMethod, 
	COALESCE(PerformanceLevelDescriptorDist.Description, '') AS StudentAssessmentPerformanceResult
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
    edfi.StudentAssessmentPerformanceLevel ON
        StudentAssessment.AssessmentIdentifier = StudentAssessmentPerformanceLevel.AssessmentIdentifier
    AND
        StudentAssessment.Namespace = StudentAssessmentPerformanceLevel.Namespace
	AND
        StudentAssessment.StudentAssessmentIdentifier = StudentAssessmentPerformanceLevel.StudentAssessmentIdentifier
	AND
		StudentAssessment.StudentUSI = StudentAssessmentPerformanceLevel.StudentUSI
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
        StudentAssessmentPerformanceLevel.PerformanceLevelDescriptorId = PerformanceLevelDescriptor.PerformanceLevelDescriptorId
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
        StudentSchoolAssociation.ExitWithdrawDate >= NOW());