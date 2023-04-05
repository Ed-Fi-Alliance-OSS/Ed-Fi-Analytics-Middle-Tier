-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'ews_StudentSectionGradeFact')
BEGIN
	DROP VIEW analytics.ews_StudentSectionGradeFact
END
GO

CREATE VIEW analytics.ews_StudentSectionGradeFact
AS
     SELECT 
         Student.StudentUniqueId AS StudentKey, 
         CAST(Grade.SchoolId AS VARCHAR) AS SchoolKey, 
         CAST(Grade.GradingPeriodDescriptorId AS NVARCHAR) + '-' + CAST(Grade.SchoolId AS NVARCHAR) + '-' + CONVERT(NVARCHAR, Grade.GradingPeriodBeginDate, 112) AS GradingPeriodKey, 
         CAST(Student.StudentUniqueId AS NVARCHAR) + '-' + CAST(Grade.SchoolId AS NVARCHAR) + '-' + Grade.ClassPeriodName + '-' + Grade.ClassroomIdentificationCode + '-' + Grade.LocalCourseCode + '-' + CAST(Grade.TermDescriptorId AS NVARCHAR) + '-' + CAST(Grade.SchoolYear AS NVARCHAR) + '-' + Grade.UniqueSectionCode + '-' + CAST(Grade.SequenceOfCourse AS NVARCHAR) + '-' + CONVERT(NVARCHAR, Grade.BeginDate, 112) AS StudentSectionKey, 
         CAST(Grade.SchoolId AS NVARCHAR) + '-' + Grade.ClassPeriodName + '-' + Grade.ClassroomIdentificationCode + '-' + Grade.LocalCourseCode + '-' + CAST(Grade.TermDescriptorId AS NVARCHAR) + '-' + CAST(Grade.SchoolYear AS NVARCHAR) + '-' + Grade.UniqueSectionCode + '-' + CAST(Grade.SequenceOfCourse AS NVARCHAR) AS SectionKey, 
         COALESCE(Grade.NumericGradeEarned, ews_LetterGradeTranslation.NumericGradeEarned, 0.00) AS NumericGradeEarned, 
         COALESCE(Grade.LetterGradeEarned, '') AS LetterGradeEarned, 
         GradeType.CodeValue AS GradeType
     FROM 
         edfi.Grade
     INNER JOIN
         edfi.GradeType
         ON Grade.GradeTypeId = GradeType.GradeTypeId
     INNER JOIN
         edfi.GradingPeriod
         ON Grade.GradingPeriodDescriptorId = GradingPeriod.GradingPeriodDescriptorId
            AND Grade.SchoolId = GradingPeriod.SchoolId
            AND Grade.GradingPeriodBeginDate = GradingPeriod.BeginDate
     INNER JOIN
         edfi.Descriptor AS GradingPeriodDescriptor
         ON GradingPeriod.GradingPeriodDescriptorId = GradingPeriodDescriptor.DescriptorId
     INNER JOIN
         analytics_config.TypeMap
         ON GradeType.GradeTypeId = TypeMap.TypeId
     INNER JOIN
         analytics_config.DescriptorConstant
         ON DescriptorConstant.DescriptorConstantId = TypeMap.DescriptorConstantId
     INNER JOIN
         edfi.Student
         ON Student.StudentUSI = grade.StudentUSI
     LEFT OUTER JOIN
         analytics_config.ews_LetterGradeTranslation
         ON Grade.LetterGradeEarned = ews_LetterGradeTranslation.LetterGradeEarned
     WHERE DescriptorConstant.ConstantName IN('GradeType.GradingPeriod', 'GradeType.Semester', 'GradeType.Final');
GO