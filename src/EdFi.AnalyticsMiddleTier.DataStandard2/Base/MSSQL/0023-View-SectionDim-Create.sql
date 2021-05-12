-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


IF EXISTS
(
    SELECT 1
    FROM [INFORMATION_SCHEMA].[VIEWS]
    WHERE [TABLE_SCHEMA] = 'analytics'
          AND [TABLE_NAME] = 'SectionDim'
)
    BEGIN
        DROP VIEW [analytics].[SectionDim];
END;
GO
CREATE VIEW [analytics].[SectionDim]
AS
     SELECT DISTINCT 
		  CAST([s].[SchoolId] AS VARCHAR) AS [SchoolKey],
          CONCAT(CAST([s].[SchoolId] AS NVARCHAR),'-',[s].[ClassPeriodName],'-',[s].[ClassroomIdentificationCode],'-',[s].[LocalCourseCode],'-',CAST([s].[TermDescriptorId] AS NVARCHAR),'-',CAST(s.[SchoolYear] AS NVARCHAR),'-',s.[UniqueSectionCode],'-',CAST(s.[SequenceOfCourse] AS NVARCHAR)) AS [SectionKey],
          CONCAT([Descriptor].[Description],'(',s.[LocalCourseCode],')','-',[Course].[CourseTitle],'(',s.[ClassPeriodName],')',TermType.Description) as Description,
		  CONCAT([s].[LocalCourseCode],'-',COALESCE([Course].[CourseTitle], '')) AS [SectionName],
		  [Course].[CourseTitle] AS [SessionName],
		  [s].[LocalCourseCode],
		  s.SchoolYear, 
		  EducationalEnvironmentType.Description as EducationalEnvironmentDescriptor,
		  sch.LocalEducationAgencyId
   FROM 
        [edfi].[Section] s
   LEFT JOIN
       [edfi].[School] sch ON
           s.SchoolId = sch.SchoolId
   INNER JOIN [edfi].[CourseOffering]
          ON [CourseOffering].[SchoolId] = s.[SchoolId]
             AND [CourseOffering].[LocalCourseCode] = s.[LocalCourseCode]
    INNER JOIN [edfi].[Course]
          ON [Course].[CourseCode] = [CourseOffering].[CourseCode]
             AND [Course].[EducationOrganizationId] = [CourseOffering].[EducationOrganizationId]
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