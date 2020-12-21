﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE VIEW analytics.asmt_AssessmentDim
AS
	SELECT 
       Assessment.AssessmentIdentifier AS AssessmentKey, 
       Assessment.AssessmentTitle AS Title, 
       COALESCE(Assessment.AssessmentVersion,0) AS Version, 
       Descriptor.CodeValue AS Category, 
       Descriptor.Description AS AssessedGradeLevel, 
       COALESCE(AssessmentScore.MinimumScore, '') AS MinScore, 
       COALESCE(AssessmentScore.MaximumScore,'') AS MaxScore
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
            Descriptor.DescriptorId = AssessmentAssessedGradeLevel.GradeLevelDescriptorId;