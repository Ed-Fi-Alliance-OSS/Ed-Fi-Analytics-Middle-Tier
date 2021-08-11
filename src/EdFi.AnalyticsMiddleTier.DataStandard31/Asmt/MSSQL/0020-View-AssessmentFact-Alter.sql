-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
IF EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.VIEWS
        WHERE TABLE_SCHEMA = 'analytics'
            AND TABLE_NAME = 'asmt_AssessmentFact'
        )
BEGIN
    DROP VIEW analytics.asmt_AssessmentFact
END
GO

CREATE VIEW analytics.asmt_AssessmentFact
AS
    SELECT CONCAT (
            Assessment.AssessmentIdentifier
            ,'-'
            ,Assessment.Namespace
            ,'-'
            ,AssessmentAssessedGradeLevel.GradeLevelDescriptorId
            ,'-'
            ,AssessmentScore.AssessmentReportingMethodDescriptorId
            ,'-'
            ,AssessmentAcademicSubject.AcademicSubjectDescriptorId
            ,'-'
            ,ObjectiveAssessment.IdentificationCode
            ,'-'
            ,ObjectiveAssessment.ParentIdentificationCode
            ,'-'
            ,ObjectiveAssessmentScore.AssessmentReportingMethodDescriptorId
            ,'-'
            ,ObjectiveAssessmentLearningStandard.LearningStandardId
            ) AS AssessmentFactKey
        ,CONCAT (
            Assessment.AssessmentIdentifier
            ,'-'
            ,Assessment.Namespace
            ) AS AssessmentKey
        ,Assessment.AssessmentIdentifier
        ,Assessment.Namespace
        ,Assessment.AssessmentTitle AS Title
        ,COALESCE(Assessment.AssessmentVersion, 0) AS Version
        ,COALESCE(CategoryDescriptor.Description, '') AS Category
        ,COALESCE(Descriptor.Description, '') AS AssessedGradeLevel
        ,COALESCE(AcademicSubjectDescriptor.Description, '') AS AcademicSubject
        ,COALESCE(ResultDataTypeDescriptorAssessment.Description, ResultDataTypeDescriptorObjectiveAssessment.Description, '') AS ResultDataType
        ,COALESCE(AssessmentReportingMethodDescriptorDist.Description, ReportingMethodDescriptorObjectiveAssessment.Description, '') AS ReportingMethod
        ,CASE 
            WHEN ObjectiveAssessment.AssessmentIdentifier IS NOT NULL
                THEN CONCAT (
                        ObjectiveAssessment.AssessmentIdentifier
                        ,'-'
                        ,ObjectiveAssessment.IdentificationCode
                        ,'-'
                        ,ObjectiveAssessment.Namespace
                        )
            ELSE ''
            END AS ObjectiveAssessmentKey
        ,COALESCE(ObjectiveAssessment.IdentificationCode, '') AS IdentificationCode
        ,CASE 
            WHEN ObjectiveAssessment.ParentIdentificationCode IS NOT NULL
                THEN CONCAT (
                        ParentAssesment.AssessmentIdentifier
                        ,'-'
                        ,ParentAssesment.IdentificationCode
                        ,'-'
                        ,ParentAssesment.Namespace
                        )
            ELSE ''
            END AS ParentObjectiveAssessmentKey
        ,COALESCE(ObjectiveAssessment.Description, '') AS ObjectiveAssessmentDescription
        ,COALESCE(ObjectiveAssessment.PercentOfAssessment, 0) AS PercentOfAssessment
        ,COALESCE(AssessmentScore.MinimumScore, ObjectiveAssessmentScore.MinimumScore, '') AS MinScore
        ,COALESCE(AssessmentScore.MaximumScore, ObjectiveAssessmentScore.MaximumScore, '') AS MaxScore
        ,COALESCE(ObjectiveAssessmentLearningStandard.LearningStandardId, '') AS LearningStandard
    FROM edfi.Assessment
    LEFT JOIN edfi.AssessmentAssessedGradeLevel
        ON Assessment.AssessmentIdentifier = AssessmentAssessedGradeLevel.AssessmentIdentifier
            AND Assessment.Namespace = AssessmentAssessedGradeLevel.Namespace
    LEFT JOIN edfi.AssessmentScore
        ON Assessment.AssessmentIdentifier = AssessmentScore.AssessmentIdentifier
            AND Assessment.Namespace = AssessmentScore.Namespace
    LEFT JOIN edfi.Descriptor AS AssessmentReportingMethodDescriptorDist
        ON AssessmentScore.AssessmentReportingMethodDescriptorId = AssessmentReportingMethodDescriptorDist.DescriptorId
    LEFT JOIN edfi.Descriptor
        ON Descriptor.DescriptorId = AssessmentAssessedGradeLevel.GradeLevelDescriptorId
    LEFT JOIN edfi.AssessmentAcademicSubject
        ON Assessment.AssessmentIdentifier = AssessmentAcademicSubject.AssessmentIdentifier
            AND Assessment.Namespace = AssessmentAcademicSubject.Namespace
    LEFT JOIN edfi.Descriptor AcademicSubjectDescriptor
        ON AcademicSubjectDescriptor.DescriptorId = AssessmentAcademicSubject.AcademicSubjectDescriptorId
    LEFT JOIN edfi.Descriptor CategoryDescriptor
        ON CategoryDescriptor.DescriptorId = Assessment.AssessmentCategoryDescriptorId
    LEFT JOIN edfi.Descriptor AS ResultDataTypeDescriptorAssessment
        ON AssessmentScore.ResultDatatypeTypeDescriptorId = ResultDataTypeDescriptorAssessment.DescriptorId
    LEFT JOIN edfi.ObjectiveAssessment
        ON Assessment.AssessmentIdentifier = ObjectiveAssessment.AssessmentIdentifier
            AND Assessment.Namespace = ObjectiveAssessment.Namespace
    LEFT JOIN edfi.ObjectiveAssessmentScore
        ON ObjectiveAssessment.AssessmentIdentifier = ObjectiveAssessmentScore.AssessmentIdentifier
            AND ObjectiveAssessment.IdentificationCode = ObjectiveAssessmentScore.IdentificationCode
            AND ObjectiveAssessment.Namespace = ObjectiveAssessmentScore.Namespace
    LEFT JOIN edfi.Descriptor AS ResultDataTypeDescriptorObjectiveAssessment
        ON ObjectiveAssessmentScore.ResultDatatypeTypeDescriptorId = ResultDataTypeDescriptorObjectiveAssessment.DescriptorId
    LEFT JOIN edfi.Descriptor AS ReportingMethodDescriptorObjectiveAssessment
        ON ObjectiveAssessmentScore.AssessmentReportingMethodDescriptorId = ReportingMethodDescriptorObjectiveAssessment.DescriptorId
    LEFT JOIN edfi.ObjectiveAssessment ParentAssesment
        ON ParentAssesment.AssessmentIdentifier = ObjectiveAssessment.AssessmentIdentifier
            AND ParentAssesment.IdentificationCode = ObjectiveAssessment.ParentIdentificationCode
            AND ParentAssesment.Namespace = ObjectiveAssessment.Namespace
    LEFT JOIN edfi.ObjectiveAssessmentLearningStandard
        ON ObjectiveAssessment.AssessmentIdentifier = ObjectiveAssessmentLearningStandard.AssessmentIdentifier
            AND ObjectiveAssessment.IdentificationCode = ObjectiveAssessmentLearningStandard.IdentificationCode
            AND ObjectiveAssessment.Namespace = ObjectiveAssessmentLearningStandard.Namespace;