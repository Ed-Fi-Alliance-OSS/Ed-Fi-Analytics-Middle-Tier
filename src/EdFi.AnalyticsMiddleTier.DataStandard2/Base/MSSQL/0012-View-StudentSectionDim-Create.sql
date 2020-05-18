-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


IF EXISTS
(
    SELECT 1
    FROM [INFORMATION_SCHEMA].[VIEWS]
    WHERE [TABLE_SCHEMA] = 'analytics'
          AND [TABLE_NAME] = 'StudentSectionDim'
)
    BEGIN
        DROP VIEW [analytics].[StudentSectionDim];
END;
GO
CREATE VIEW [analytics].[StudentSectionDim]
AS
     SELECT CAST([Student].[StudentUniqueId] AS NVARCHAR) + '-' + CAST([StudentSectionAssociation].[SchoolId] AS NVARCHAR) + '-' + [StudentSectionAssociation].[ClassPeriodName] + '-' + [StudentSectionAssociation].[ClassroomIdentificationCode] + '-' + [StudentSectionAssociation].[LocalCourseCode] + '-' + CAST([StudentSectionAssociation].[TermDescriptorId] AS NVARCHAR) + '-' + CAST([StudentSectionAssociation].[SchoolYear] AS NVARCHAR) + '-' + [StudentSectionAssociation].[UniqueSectionCode] + '-' + CAST([StudentSectionAssociation].[SequenceOfCourse] AS NVARCHAR) + '-' + CONVERT(NVARCHAR, [StudentSectionAssociation].[BeginDate], 112) AS [StudentSectionKey],
            [Student].[StudentUniqueId] AS [StudentKey],
            CAST([StudentSectionAssociation].[SchoolId] AS NVARCHAR) + '-' + [StudentSectionAssociation].[ClassPeriodName] + '-' + [StudentSectionAssociation].[ClassroomIdentificationCode] + '-' + [StudentSectionAssociation].[LocalCourseCode] + '-' + CAST([StudentSectionAssociation].[TermDescriptorId] AS NVARCHAR) + '-' + CAST([StudentSectionAssociation].[SchoolYear] AS NVARCHAR) + '-' + [StudentSectionAssociation].[UniqueSectionCode] + '-' + CAST([StudentSectionAssociation].[SequenceOfCourse] AS NVARCHAR) AS [SectionKey],
            [StudentSectionAssociation].[LocalCourseCode],
            ISNULL([AcademicSubjectType].[CodeValue], '') AS [Subject],
            ISNULL([Course].[CourseTitle], '') AS [CourseTitle],

            -- There could be multiple teachers for a section - reduce those to a single string.
            -- Unfortunately this means that the Staff and StaffSectionAssociation
            -- LastModifiedDate values can't be used to calculate this record's LastModifiedDate
            ISNULL(STUFF(
     (
         SELECT N', ' + ISNULL([Staff].[FirstName], '') + ' ' + ISNULL([Staff].[LastSurname], '')
         FROM [edfi].[StaffSectionAssociation]
              LEFT OUTER JOIN [edfi].[Staff]
              ON [StaffSectionAssociation].[StaffUSI] = [Staff].[StaffUSI]
         WHERE [StudentSectionAssociation].[SchoolId] = [StaffSectionAssociation].[SchoolId]
               AND [StudentSectionAssociation].[ClassPeriodName] = [StaffSectionAssociation].[ClassPeriodName]
               AND [StudentSectionAssociation].[ClassroomIdentificationCode] = [StaffSectionAssociation].[ClassroomIdentificationCode]
               AND [StudentSectionAssociation].[LocalCourseCode] = [StaffSectionAssociation].[LocalCourseCode]
               AND [StudentSectionAssociation].[TermDescriptorId] = [StaffSectionAssociation].[TermDescriptorId]
               AND [StudentSectionAssociation].[SchoolYear] = [StaffSectionAssociation].[SchoolYear]
               AND [StudentSectionAssociation].[UniqueSectionCode] = [StaffSectionAssociation].[UniqueSectionCode]
               AND [StudentSectionAssociation].[SequenceOfCourse] = [StaffSectionAssociation].[SequenceOfCourse] FOR XML PATH('')
     ), 1, 1, N''), '') AS [TeacherName],
            CONVERT(NVARCHAR, [StudentSectionAssociation].[BeginDate], 112) AS [StudentSectionStartDateKey],
            CONVERT(NVARCHAR, [StudentSectionAssociation].[EndDate], 112) AS [StudentSectionEndDateKey],
            CAST([StudentSectionAssociation].[SchoolId] AS VARCHAR) AS [SchoolKey],
            CAST(StudentSectionAssociation.SchoolYear AS NVARCHAR) AS SchoolYear,
     (
         SELECT MAX([MaxLastModifiedDate])
         FROM(VALUES([StudentSectionAssociation].[LastModifiedDate]), ([Course].[LastModifiedDate]), ([CourseOffering].[LastModifiedDate]), ([AcademicSubjectType].[LastModifiedDate])) AS VALUE([MaxLastModifiedDate])
     ) AS [LastModifiedDate]
     FROM [edfi].[StudentSectionAssociation]
          INNER JOIN [edfi].[Student]
          ON [StudentSectionAssociation].[StudentUSI] = [Student].[StudentUSI]
          INNER JOIN [edfi].[CourseOffering]
          ON [CourseOffering].[SchoolId] = [StudentSectionAssociation].[SchoolId]
             AND [CourseOffering].[LocalCourseCode] = [StudentSectionAssociation].[LocalCourseCode]
             AND [CourseOffering].[TermDescriptorId] = [StudentSectionAssociation].[TermDescriptorId]
             AND [CourseOffering].[SchoolYear] = [StudentSectionAssociation].[SchoolYear]
          INNER JOIN [edfi].[Course]
          ON [Course].[CourseCode] = [CourseOffering].[CourseCode]
             AND [Course].[EducationOrganizationId] = [CourseOffering].[EducationOrganizationId]
          LEFT OUTER JOIN [edfi].[AcademicSubjectDescriptor]
          ON [AcademicSubjectDescriptor].[AcademicSubjectDescriptorId] = [Course].[AcademicSubjectDescriptorId]
          LEFT OUTER JOIN [edfi].[AcademicSubjectType]
          ON [AcademicSubjectType].[AcademicSubjectTypeId] = [AcademicSubjectDescriptor].[AcademicSubjectTypeId];
GO