-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'asmt_ObjectiveAssessmentDim')
BEGIN
	DROP VIEW analytics.asmt_ObjectiveAssessmentDim
END
GO

CREATE VIEW analytics.asmt_ObjectiveAssessmentDim
AS
	SELECT 
       CONCAT(ObjectiveAssessment.AssessmentIdentifier, '-', ObjectiveAssessment.IdentificationCode, '-', ObjectiveAssessment.Namespace) AS ObjectiveAssessmentKey, 
       CONCAT(Assessment.AssessmentIdentifier, '-', Assessment.Namespace) AS AssessmentKey, 
       ObjectiveAssessment.IdentificationCode, 
       CASE WHEN ObjectiveAssessment.ParentIdentificationCode IS NOT NULL
            THEN CONCAT(ParentAssesment.AssessmentIdentifier, '-', ParentAssesment.IdentificationCode, '-', ParentAssesment.Namespace)
          ELSE ''
          END AS ParentObjectiveAssessmentKey,
       ISNULL(ObjectiveAssessment.Description, '') as Description, 
       ObjectiveAssessment.Namespace, 
       COALESCE(ObjectiveAssessment.PercentOfAssessment,0) as PercentOfAssessment, 
       COALESCE(Descriptor.CodeValue,'') AS AcademicSubject, 
       COALESCE(ObjectiveAssessmentScore.MinimumScore, '') as MinimumScore, 
       COALESCE(ObjectiveAssessmentScore.MaximumScore, '') as MaximumScore
    FROM 
         edfi.Assessment
    INNER JOIN
        edfi.ObjectiveAssessment ON
            Assessment.AssessmentIdentifier = ObjectiveAssessment.AssessmentIdentifier
            AND
            Assessment.Namespace = ObjectiveAssessment.Namespace
    INNER JOIN
        edfi.ObjectiveAssessmentScore ON
            ObjectiveAssessment.AssessmentIdentifier = ObjectiveAssessmentScore.AssessmentIdentifier
            AND
            ObjectiveAssessment.IdentificationCode = ObjectiveAssessmentScore.IdentificationCode
            AND
            ObjectiveAssessment.Namespace = ObjectiveAssessmentScore.Namespace
    LEFT JOIN
        edfi.Descriptor ON
            edfi.ObjectiveAssessment.AcademicSubjectDescriptorId = edfi.Descriptor.DescriptorId
    LEFT JOIN
        edfi.ObjectiveAssessment AS ParentAssesment ON
            ParentAssesment.AssessmentIdentifier = ObjectiveAssessment.AssessmentIdentifier
            AND
            ParentAssesment.IdentificationCode = ObjectiveAssessment.ParentIdentificationCode
            AND
            ParentAssesment.Namespace = ObjectiveAssessment.Namespace;