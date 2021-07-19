﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'SectionDim')
BEGIN
    DROP VIEW analytics.SectionDim
END
GO

CREATE VIEW analytics.SectionDim AS
    SELECT 
        CAST(s.SchoolId AS VARCHAR) AS SchoolKey
		,CONCAT (
			CAST(s.SchoolId AS NVARCHAR)
			,'-'
			,s.LocalCourseCode
			,'-'
			,CAST(s.SchoolYear AS NVARCHAR)
			,'-'
			,s.SectionIdentifier
			,'-'
			,s.SessionName
			) AS SectionKey
		,CONCAT (
			[Descriptor].[Description]
			,'('
			,s.[LocalCourseCode]
			,')'
			,'-'
			,[Course].[CourseTitle]
			,'('
			,SectionClassPeriod.ClassPeriodName
			,')'
			,td.Description
			) AS Description
		,CONCAT (
			s.LocalCourseCode
			,'-'
			,Session.SessionName
			) AS SectionName
        ,s.SessionName
        ,s.LocalCourseCode
        ,s.SchoolYear
        ,eed.Description AS EducationalEnvironmentDescriptor

        -- NOTE: LocalEducationAgencyId was accidentally introduced in a prior release.
        -- Rather than creating a breaking change, it is being left in place while the
        -- correct column name, LocalEducationAgencyKey, is also being introduced
        ,sch.LocalEducationAgencyId
        ,sch.LocalEducationAgencyId as LocalEducationAgencyKey

        ,s.LastModifiedDate
        ,course.CourseTitle
        ,FORMATMESSAGE(
            '%s-%s-%s',
            s.SchoolId
            ,s.SchoolYear
            ,s.SessionName
        ) as SessionKey
    FROM edfi.Section s
    INNER JOIN 
        edfi.CourseOffering
    ON 
        CourseOffering.SchoolId = s.SchoolId
    AND 
        CourseOffering.LocalCourseCode = s.LocalCourseCode
    AND 
        CourseOffering.SchoolYear = s.SchoolYear
    AND
        CourseOffering.SessionName = s.SessionName
	INNER JOIN 
		[edfi].[Course] ON 
		[Course].[CourseCode] = [CourseOffering].[CourseCode]
		AND 
		[Course].[EducationOrganizationId] = [CourseOffering].[EducationOrganizationId]
	LEFT JOIN [edfi].[School] sch ON s.SchoolId = sch.SchoolId
	LEFT OUTER JOIN [edfi].[AcademicSubjectDescriptor] ON [AcademicSubjectDescriptor].[AcademicSubjectDescriptorId] = [Course].[AcademicSubjectDescriptorId]
	LEFT OUTER JOIN [edfi].[Descriptor] ON [AcademicSubjectDescriptor].[AcademicSubjectDescriptorId] = [Descriptor].[DescriptorId]
	LEFT JOIN edfi.Descriptor eed ON eed.DescriptorId = s.EducationalEnvironmentDescriptorId
	LEFT JOIN edfi.Session ON 
		Session.SchoolId = [Course].[EducationOrganizationId]
		AND 
		Session.SchoolYear = CourseOffering.SchoolYear
		AND 
		Session.SessionName = s.SessionName
	LEFT OUTER JOIN [edfi].TermDescriptor ON TermDescriptor.TermDescriptorId = Session.TermDescriptorId
	LEFT OUTER JOIN [edfi].Descriptor td ON TermDescriptor.TermDescriptorId = td.DescriptorId
	LEFT OUTER JOIN edfi.SectionClassPeriod ON 
		SectionClassPeriod.LocalCourseCode = [CourseOffering].[LocalCourseCode]
		AND 
		SectionClassPeriod.SchoolId = [Course].[EducationOrganizationId]
		AND 
		SectionClassPeriod.SchoolYear = CourseOffering.SchoolYear
		AND 
		SectionClassPeriod.SectionIdentifier=s.SectionIdentifier
		AND 
		SectionClassPeriod.SessionName=s.SessionName

GO