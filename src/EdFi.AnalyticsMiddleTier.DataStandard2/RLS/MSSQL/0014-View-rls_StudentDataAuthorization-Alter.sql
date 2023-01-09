-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'rls_StudentDataAuthorization')
BEGIN
	DROP VIEW analytics.rls_StudentDataAuthorization
END
GO

CREATE VIEW analytics.rls_StudentDataAuthorization
AS
     SELECT 
         Student.StudentUniqueId AS StudentKey, 
         CAST(Section.SchoolId AS VARCHAR) AS SchoolKey, 
         CAST(Section.Id AS NVARCHAR(50)) AS SectionId, 
         StudentSectionAssociation.BeginDate, 
         StudentSectionAssociation.EndDate,
		CONVERT(varchar, StudentSectionAssociation.BeginDate, 112) as BeginDateKey,
		CONVERT(varchar, StudentSectionAssociation.EndDate, 112) as EndDateKey
     FROM 
         edfi.Student
     INNER JOIN
         edfi.StudentSectionAssociation
         ON Student.StudentUSI = StudentSectionAssociation.StudentUSI
     INNER JOIN
         edfi.Section
         ON StudentSectionAssociation.SchoolId = Section.SchoolId
            AND StudentSectionAssociation.ClassPeriodName = Section.ClassPeriodName
            AND StudentSectionAssociation.ClassroomIdentificationCode = Section.ClassroomIdentificationCode
            AND StudentSectionAssociation.LocalCourseCode = Section.LocalCourseCode
            AND StudentSectionAssociation.TermDescriptorId = Section.TermDescriptorId
            AND StudentSectionAssociation.SchoolYear = Section.SchoolYear
            AND StudentSectionAssociation.UniqueSectionCode = Section.UniqueSectionCode
            AND StudentSectionAssociation.SequenceOfCourse = Section.SequenceOfCourse;
GO