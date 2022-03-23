﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
IF EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.VIEWS
        WHERE TABLE_SCHEMA = 'analytics'
            AND TABLE_NAME = 'AllStudentSchoolDim'
        )
BEGIN
    DROP VIEW analytics.AllStudentSchoolDim;
END;
GO

CREATE VIEW analytics.AllStudentSchoolDim
AS
    SELECT CONCAT (
            Student.StudentUniqueId
            ,'-'
            ,StudentSchoolAssociation.SchoolId
            ,'-'
            ,CONVERT(varchar, StudentSchoolAssociation.EntryDate, 112)
            ) AS AllStudentSchoolKey
        ,CONCAT (
            Student.StudentUniqueId
            ,'-'
            ,StudentSchoolAssociation.SchoolId
            ) AS StudentSchoolKey
        ,Student.StudentUniqueId AS StudentKey
        ,CAST(StudentSchoolAssociation.SchoolId AS VARCHAR) AS SchoolKey
        ,COALESCE(CAST(StudentSchoolAssociation.SchoolYear AS VARCHAR), 'Unknown') AS SchoolYear
        ,Student.FirstName AS StudentFirstName
        ,COALESCE(Student.MiddleName, '') AS StudentMiddleName
        ,Student.LastSurname AS StudentLastName
        ,Student.BirthDate
        ,CAST(StudentSchoolAssociation.EntryDate AS NVARCHAR) AS EnrollmentDateKey
        ,Descriptor.CodeValue AS GradeLevel
        ,COALESCE(CASE 
                WHEN studentEdOrg.StudentUSI IS NOT NULL
                    THEN LimitedEnglishDescriptorSchool.CodeValue
                ELSE LimitedEnglishDescriptorDist.CodeValue
                END, 'Not applicable') AS LimitedEnglishProficiency
        ,COALESCE(CASE 
                WHEN studentEdOrg.StudentUSI IS NOT NULL
                    THEN studentEdOrg.HispanicLatinoEthnicity
                ELSE districtEdOrg.HispanicLatinoEthnicity
                END, CAST(0 AS BIT)) AS IsHispanic
        ,COALESCE(CASE 
                WHEN studentEdOrg.StudentUSI IS NOT NULL
                    THEN SexTypeSchool.CodeValue
                ELSE SexTypeDist.CodeValue
                END, '') AS Sex
        ,COALESCE(InternetAccessInResidence.Indicator, 'n/a') AS InternetAccessInResidence
        ,COALESCE(InternetAccessTypeInResidence.Indicator, 'n/a') AS InternetAccessTypeInResidence
        ,COALESCE(InternetPerformance.Indicator, 'n/a') AS InternetPerformance
        ,COALESCE(DigitalDevice.Indicator, 'n/a') AS DigitalDevice
        ,COALESCE(DeviceAccess.Indicator, 'n/a') AS DeviceAccess
        ,CAST((CASE WHEN StudentSchoolAssociation.ExitWithdrawDate IS NULL
            OR StudentSchoolAssociation.ExitWithdrawDate > GETDATE()
            THEN 1
            ELSE 0
            END
          ) AS BIT) AS IsEnrolled
        ,COALESCE(cast(StudentSchoolAssociation.ExitWithdrawDate AS VARCHAR(100)), '') AS ExitWithdrawDate
        ,(
            SELECT MAX(MaxLastModifiedDate)
            FROM (
                VALUES (Student.LastModifiedDate)
                    ,(studentEdOrg.LastModifiedDate)
                    ,(districtEdOrg.LastModifiedDate)
                ) AS VALUE(MaxLastModifiedDate)
            ) AS LastModifiedDate
    FROM edfi.Student
    INNER JOIN edfi.StudentSchoolAssociation
        ON Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN edfi.Descriptor
        ON StudentSchoolAssociation.EntryGradeLevelDescriptorId = Descriptor.DescriptorId
    INNER JOIN edfi.School
        ON StudentSchoolAssociation.SchoolId = School.SchoolId
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociation AS studentEdOrg
        ON Student.StudentUSI = studentEdOrg.StudentUSI
            AND StudentSchoolAssociation.SchoolId = studentEdOrg.EducationOrganizationId
    LEFT OUTER JOIN edfi.Descriptor AS LimitedEnglishDescriptorSchool
        ON studentEdOrg.LimitedEnglishProficiencyDescriptorId = LimitedEnglishDescriptorSchool.DescriptorId
    LEFT OUTER JOIN edfi.Descriptor AS SexTypeSchool
        ON studentEdOrg.SexDescriptorId = SexTypeSchool.DescriptorId
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociation AS districtEdOrg
        ON Student.StudentUSI = districtEdOrg.StudentUSI
            AND School.LocalEducationAgencyId = districtEdOrg.EducationOrganizationId
    LEFT OUTER JOIN edfi.Descriptor AS LimitedEnglishDescriptorDist
        ON districtEdOrg.LimitedEnglishProficiencyDescriptorId = LimitedEnglishDescriptorDist.DescriptorId
    LEFT OUTER JOIN edfi.Descriptor AS SexTypeDist
        ON districtEdOrg.SexDescriptorId = SexTypeDist.DescriptorId
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetAccessInResidence
        ON studentEdOrg.StudentUSI = InternetAccessInResidence.StudentUSI
            AND studentEdOrg.EducationOrganizationId = InternetAccessInResidence.EducationOrganizationId
            AND (
                InternetAccessInResidence.StudentUSI IS NULL
                OR InternetAccessInResidence.IndicatorName = 'InternetAccessInResidence'
                )
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetAccessTypeInResidence
        ON studentEdOrg.StudentUSI = InternetAccessTypeInResidence.StudentUSI
            AND studentEdOrg.EducationOrganizationId = InternetAccessTypeInResidence.EducationOrganizationId
            AND (
                InternetAccessTypeInResidence.StudentUSI IS NULL
                OR InternetAccessTypeInResidence.IndicatorName = 'InternetAccessTypeInResidence'
                )
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetPerformance
        ON studentEdOrg.StudentUSI = InternetPerformance.StudentUSI
            AND studentEdOrg.EducationOrganizationId = InternetPerformance.EducationOrganizationId
            AND (
                InternetPerformance.StudentUSI IS NULL
                OR InternetPerformance.IndicatorName = 'InternetPerformance'
                )
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS DigitalDevice
        ON studentEdOrg.StudentUSI = DigitalDevice.StudentUSI
            AND studentEdOrg.EducationOrganizationId = DigitalDevice.EducationOrganizationId
            AND (
                DigitalDevice.StudentUSI IS NULL
                OR DigitalDevice.IndicatorName = 'DigitalDevice'
                )
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS DeviceAccess
        ON studentEdOrg.StudentUSI = DeviceAccess.StudentUSI
            AND studentEdOrg.EducationOrganizationId = DeviceAccess.EducationOrganizationId
            AND (
                DeviceAccess.StudentUSI IS NULL
                OR DeviceAccess.IndicatorName = 'DeviceAccess'
                );