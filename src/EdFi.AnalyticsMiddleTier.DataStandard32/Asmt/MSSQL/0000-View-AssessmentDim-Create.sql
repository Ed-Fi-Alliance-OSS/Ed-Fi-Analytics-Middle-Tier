-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'asmt_AssessmentDim')
BEGIN
	DROP VIEW analytics.asmt_AssessmentDim
END
GO

CREATE VIEW analytics.asmt_AssessmentDim
AS
	SELECT 
       Assessment.AssessmentIdentifier AS AssessmentKey, 
       Assessment.AssessmentTitle AS Title, 
       COALESCE(Assessment.AssessmentVersion, 0) AS Version, 
       COALESCE(CategoryDescriptor.Description, '') AS Category, 
       Descriptor.Description AS AssessedGradeLevel, 
       COALESCE(AcademicSubjectDescriptor.Description,'') AS AcademicSubject, 
       COALESCE(AssessmentScore.MinimumScore, '') AS MinScore, 
       COALESCE(AssessmentScore.MaximumScore, '') AS MaxScore
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
            CategoryDescriptor.DescriptorId = Assessment.AssessmentCategoryDescriptorId;