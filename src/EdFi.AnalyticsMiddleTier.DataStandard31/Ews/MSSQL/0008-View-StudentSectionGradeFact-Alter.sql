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
                    TABLE_NAME = 'ews_StudentSectionGradeFact'
          ) 
    BEGIN
        DROP VIEW 
             analytics.ews_StudentSectionGradeFact;
END;
GO
CREATE VIEW analytics.ews_StudentSectionGradeFact
AS
    SELECT 
           Student.StudentUniqueId AS StudentKey, 
           CAST(Grade.SchoolId AS VARCHAR) AS SchoolKey, 
           CONCAT(Grade.GradingPeriodDescriptorId, '-', Grade.SchoolId, '-', CONVERT(NVARCHAR, GradingPeriod.BeginDate, 112)) AS GradingPeriodKey, 
           CONCAT(Student.StudentUniqueId, '-', Grade.SchoolId, '-', Grade.LocalCourseCode, '-', Grade.SchoolYear, '-', Grade.SectionIdentifier, '-', Grade.SessionName, '-', CONVERT(NVARCHAR, Grade.BeginDate, 112)) AS StudentSectionKey, 
           CONCAT(Grade.SchoolId, '-', Grade.LocalCourseCode, '-', Grade.SchoolYear, '-', Grade.SectionIdentifier, '-', Grade.SessionName) AS SectionKey, 
           COALESCE(Grade.NumericGradeEarned, ews_LetterGradeTranslation.NumericGradeEarned, 0.00) AS NumericGradeEarned, 
           COALESCE(Grade.LetterGradeEarned, '') AS LetterGradeEarned, 
           GradeType.CodeValue AS GradeType
    FROM 
         edfi.Grade
    INNER JOIN
        edfi.Student ON
            Grade.StudentUSI = edfi.Student.StudentUSI
    INNER JOIN
        edfi.Descriptor AS GradeType ON
            Grade.GradeTypeDescriptorId = GradeType.DescriptorId
    INNER JOIN
        edfi.GradingPeriod ON
            Grade.GradingPeriodDescriptorId = GradingPeriod.GradingPeriodDescriptorId
            AND
            Grade.GradingPeriodSequence = GradingPeriod.PeriodSequence
            AND
            Grade.SchoolId = GradingPeriod.SchoolId
            AND
            Grade.GradingPeriodSchoolYear = GradingPeriod.SchoolYear
    INNER JOIN
        edfi.Descriptor AS GradingPeriodDescriptor ON
            GradingPeriod.GradingPeriodDescriptorId = GradingPeriodDescriptor.DescriptorId
    INNER JOIN
        analytics_config.DescriptorMap ON
            GradeType.DescriptorId = DescriptorMap.DescriptorId
    INNER JOIN
        analytics_config.DescriptorConstant ON
            DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
    LEFT OUTER JOIN
        analytics_config.ews_LetterGradeTranslation ON
            Grade.LetterGradeEarned = ews_LetterGradeTranslation.LetterGradeEarned
    WHERE DescriptorConstant.ConstantName IN('GradeType.GradingPeriod', 'GradeType.Semester', 'GradeType.Final');