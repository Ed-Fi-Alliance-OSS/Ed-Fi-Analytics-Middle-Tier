-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'asmt_AssessmentFact')
BEGIN
	DROP VIEW analytics.asmt_AssessmentFact
END
GO

CREATE VIEW analytics.asmt_AssessmentFact
AS
	SELECT 
       CONCAT(Assessment.AssessmentIdentifier, '-', Assessment.Namespace)  AS AssessmentKey,
       Assessment.AssessmentIdentifier,
       Assessment.Namespace,
       Assessment.AssessmentTitle AS Title,
       COALESCE(Assessment.AssessmentVersion, 0) AS Version,
       COALESCE(CategoryDescriptor.Description, '') AS Category,
       Descriptor.Description AS AssessedGradeLevel,
       COALESCE(AcademicSubjectDescriptor.Description,'') AS AcademicSubject,
       COALESCE(ResultDataTypeDescriptorAssessment.Description,ResultDataTypeDescriptorObjectiveAssessment.Description,'') AS ResultDataType,
       AssessmentReportingMethodDescriptorDist.Description AS ReportingMethod,
       CONCAT(ObjectiveAssessment.AssessmentIdentifier, '-', ObjectiveAssessment.IdentificationCode, '-', ObjectiveAssessment.Namespace) AS ObjectiveAssessmentKey,
       ObjectiveAssessment.IdentificationCode,
       CASE WHEN ObjectiveAssessment.ParentIdentificationCode IS NOT NULL
            THEN CONCAT(ParentAssesment.AssessmentIdentifier, '-', ParentAssesment.IdentificationCode, '-', ParentAssesment.Namespace)
          ELSE ''
          END AS ParentObjectiveAssessmentKey,
       COALESCE(ObjectiveAssessment.Description, '') as ObjectiveAssessmentDescription,
       COALESCE(ObjectiveAssessment.PercentOfAssessment,0) as PercentOfAssessment,
       COALESCE(AssessmentScore.MinimumScore, ObjectiveAssessmentScore.MinimumScore, '') as MinScore,
       COALESCE(AssessmentScore.MaximumScore, ObjectiveAssessmentScore.MaximumScore, '') as MaxScore
    FROM 
         edfi.Assessment
    INNER JOIN
        edfi.AssessmentAssessedGradeLevel ON
            Assessment.AssessmentIdentifier = AssessmentAssessedGradeLevel.AssessmentIdentifier
            AND
            Assessment.Namespace = AssessmentAssessedGradeLevel.Namespace
    INNER JOIN
        edfi.AssessmentScore ON
            Assessment.AssessmentIdentifier = AssessmentScore.AssessmentIdentifier
            AND
            Assessment.Namespace = AssessmentScore.Namespace
    INNER JOIN
        edfi.Descriptor AS AssessmentReportingMethodDescriptorDist
            ON AssessmentScore.AssessmentReportingMethodDescriptorId = AssessmentReportingMethodDescriptorDist.DescriptorId
    INNER JOIN
        edfi.Descriptor ON
            Descriptor.DescriptorId = AssessmentAssessedGradeLevel.GradeLevelDescriptorId
    LEFT JOIN
        edfi.AssessmentAcademicSubject ON
           Assessment.AssessmentIdentifier = AssessmentAcademicSubject.AssessmentIdentifier
           AND
           Assessment.Namespace = AssessmentAcademicSubject.Namespace
    LEFT JOIN
        edfi.Descriptor AcademicSubjectDescriptor ON
            AcademicSubjectDescriptor.DescriptorId = AssessmentAcademicSubject.AcademicSubjectDescriptorId
    LEFT JOIN
        edfi.Descriptor CategoryDescriptor ON
            CategoryDescriptor.DescriptorId = Assessment.AssessmentCategoryDescriptorId
    LEFT JOIN
        edfi.Descriptor AS ResultDataTypeDescriptorAssessment
            ON AssessmentScore.ResultDatatypeTypeDescriptorId = ResultDataTypeDescriptorAssessment.DescriptorId
    LEFT JOIN
        edfi.ObjectiveAssessment ON
            Assessment.AssessmentIdentifier = ObjectiveAssessment.AssessmentIdentifier
            AND
            Assessment.Namespace = ObjectiveAssessment.Namespace
    LEFT JOIN
        edfi.ObjectiveAssessmentScore ON
            ObjectiveAssessment.AssessmentIdentifier = ObjectiveAssessmentScore.AssessmentIdentifier
            AND
            ObjectiveAssessment.IdentificationCode = ObjectiveAssessmentScore.IdentificationCode
            AND
            ObjectiveAssessment.Namespace = ObjectiveAssessmentScore.Namespace
    LEFT JOIN
        edfi.Descriptor AS ResultDataTypeDescriptorObjectiveAssessment ON
            ObjectiveAssessmentScore.ResultDatatypeTypeDescriptorId = ResultDataTypeDescriptorObjectiveAssessment.DescriptorId
    LEFT JOIN
        edfi.ObjectiveAssessment ParentAssesment ON
            ParentAssesment.AssessmentIdentifier = ObjectiveAssessment.AssessmentIdentifier
            AND
            ParentAssesment.IdentificationCode = ObjectiveAssessment.ParentIdentificationCode
            AND
            ParentAssesment.Namespace = ObjectiveAssessment.Namespace;
