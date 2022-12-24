﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
IF EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.VIEWS
        WHERE TABLE_SCHEMA = 'analytics'
            AND TABLE_NAME = 'SectionDim'
        )
BEGIN
    DROP VIEW analytics.SectionDim
END
GO

CREATE VIEW [analytics].[SectionDim]
AS
SELECT CAST(s.SchoolId AS VARCHAR) AS SchoolKey
    ,CONCAT (
        CAST(s.SchoolId AS NVARCHAR)
        ,'-'
        ,[s].[ClassPeriodName]
        ,'-'
        ,[s].[ClassroomIdentificationCode]
        ,'-'
        ,s.[LocalCourseCode]
        ,'-'
        ,CAST([s].[TermDescriptorId] AS NVARCHAR)
        ,'-'
        ,CAST(s.[SchoolYear] AS NVARCHAR)
        ,'-'
        ,s.[UniqueSectionCode]
        ,'-'
        ,CAST(s.[SequenceOfCourse] AS NVARCHAR)
        ) AS [SectionKey]
    ,CONCAT (
        [Descriptor].[Description]
        ,'-('
        ,s.[LocalCourseCode]
        ,')'
        ,'-'
        ,[Course].[CourseTitle]
        ,'-('
        ,s.[ClassPeriodName]
        ,')-'
        ,TermType.Description
        ) AS Description
    ,CONCAT (
        [s].[LocalCourseCode]
        ,'-'
        ,COALESCE([Course].[CourseTitle], '')
        ) AS [SectionName]
    ,Session.SessionName
    ,[CourseOffering].[LocalCourseCode]
    ,CAST(s.SchoolYear AS VARCHAR) as SchoolYear
    ,EducationalEnvironmentType.Description AS EducationalEnvironmentDescriptor
    ,COALESCE(CAST(sch.LocalEducationAgencyId AS VARCHAR),'') AS LocalEducationAgencyKey
    ,s.LastModifiedDate
    ,course.CourseTitle
    ,CONCAT (
        s.SchoolId
        ,'-'
        ,s.SchoolYear
        ,'-'
        ,s.TermDescriptorId
        ) AS SessionKey
FROM [edfi].[Section] s
INNER JOIN [edfi].[CourseOffering]
    ON [CourseOffering].[SchoolId] = s.[SchoolId]
        AND [CourseOffering].[LocalCourseCode] = s.[LocalCourseCode]
        AND CourseOffering.TermDescriptorId = s.TermDescriptorId
        AND CourseOffering.SchoolYear = s.SchoolYear
INNER JOIN [edfi].[Course]
    ON [Course].[CourseCode] = [CourseOffering].[CourseCode]
        AND [Course].[EducationOrganizationId] = [CourseOffering].[EducationOrganizationId]
INNER JOIN edfi.Session
    ON Session.SchoolId = s.SchoolId
        AND Session.SchoolYear = s.SchoolYear
        AND Session.TermDescriptorId = s.TermDescriptorId
LEFT JOIN [edfi].[School] sch
    ON sch.SchoolId = [Course].[EducationOrganizationId]
LEFT OUTER JOIN [edfi].[AcademicSubjectDescriptor]
    ON [AcademicSubjectDescriptor].[AcademicSubjectDescriptorId] = [Course].[AcademicSubjectDescriptorId]
LEFT OUTER JOIN [edfi].[Descriptor]
    ON [AcademicSubjectDescriptor].[AcademicSubjectDescriptorId] = [Descriptor].[DescriptorId]
LEFT OUTER JOIN [edfi].TermDescriptor
    ON TermDescriptor.TermDescriptorId = s.TermDescriptorId
LEFT OUTER JOIN [edfi].TermType
    ON TermDescriptor.TermTypeId = TermType.TermTypeId
LEFT OUTER JOIN [edfi].EducationalEnvironmentType
    ON EducationalEnvironmentType.EducationalEnvironmentTypeId = s.EducationalEnvironmentTypeId
GO


