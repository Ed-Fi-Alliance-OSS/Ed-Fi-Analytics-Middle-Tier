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
		  CAST([ssa].[SchoolId] AS VARCHAR) AS [SchoolKey],
          CAST([ssa].[SchoolId] AS NVARCHAR) + '-' + [ssa].[ClassPeriodName] + '-' + [ssa].[ClassroomIdentificationCode] + '-' + [ssa].[LocalCourseCode] + '-' + CAST([ssa].[TermDescriptorId] AS NVARCHAR) + '-' + CAST([ssa].[SchoolYear] AS NVARCHAR) + '-' + [ssa].[UniqueSectionCode] + '-' + CAST([ssa].[SequenceOfCourse] AS NVARCHAR) AS [SectionKey],
		  CONCAT([ssa].[LocalCourseCode],'-',ISNULL([Course].[CourseTitle], '')) AS [SectionName],
		  ISNULL([Course].[CourseTitle], '') AS [SessionName],
		  [ssa].[LocalCourseCode],
		  ssa.SchoolYear, 
		  s.ClassroomIdentificationCode as EducationalEnvironmentTypeId,
		  sch.LocalEducationAgencyId
   FROM 
        [edfi].[Section] s
   INNER JOIN
		[edfi].StudentSectionAssociation ssa ON
			ssa.[SchoolId] = s.SchoolId  
			AND ssa.[ClassPeriodName] = s.ClassPeriodName 
			AND ssa.[ClassroomIdentificationCode] = s.ClassroomIdentificationCode 
   LEFT JOIN
       [edfi].[School] sch ON
           s.SchoolId = sch.SchoolId
   INNER JOIN [edfi].[CourseOffering]
          ON [CourseOffering].[SchoolId] = [ssa].[SchoolId]
             AND [CourseOffering].[LocalCourseCode] = [ssa].[LocalCourseCode]
    INNER JOIN [edfi].[Course]
          ON [Course].[CourseCode] = [CourseOffering].[CourseCode]
             AND [Course].[EducationOrganizationId] = [CourseOffering].[EducationOrganizationId]

GO