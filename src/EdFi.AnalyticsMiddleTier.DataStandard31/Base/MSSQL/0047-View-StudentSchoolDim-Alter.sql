-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
IF EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.VIEWS
        WHERE TABLE_SCHEMA = 'analytics'
            AND TABLE_NAME = 'StudentSchoolDim'
        )
BEGIN
    DROP VIEW analytics.StudentSchoolDim;
END;
GO

CREATE VIEW analytics.StudentSchoolDim
AS
    SELECT CONCAT (
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
        ,COALESCE(
            LimitedEnglishDescriptorSchool.CodeValue,
            LimitedEnglishDescriptorDist.CodeValue,
            'Not applicable'
        ) AS LimitedEnglishProficiency
        ,COALESCE(
            studentEdOrg.HispanicLatinoEthnicity,
            districtEdOrg.HispanicLatinoEthnicity,
            CAST(0 AS BIT)
        ) AS IsHispanic
        ,COALESCE(
            SexTypeSchool.CodeValue,
            SexTypeDist.CodeValue,
            ''
        ) AS Sex
        ,COALESCE(InternetAccessInResidence.Indicator
                ,InternetAccessInResidenceDistrict.Indicator
                , 'n/a') AS InternetAccessInResidence
        ,COALESCE(InternetAccessTypeInResidence.Indicator
                , InternetAccessTypeInResidenceDistrict.Indicator
                , 'n/a') AS InternetAccessTypeInResidence
        ,COALESCE(InternetPerformance.Indicator
                , InternetPerformanceDistrict.Indicator
                , 'n/a') AS InternetPerformance
        ,COALESCE(DigitalDevice.Indicator
                , DigitalDeviceDistrict.Indicator
                , 'n/a') AS DigitalDevice
        ,COALESCE(DeviceAccess.Indicator
                , DeviceAccessDistrict.Indicator
                , 'n/a') AS DeviceAccess
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
    --InternetAccessInResidence
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetAccessInResidence
        ON studentEdOrg.StudentUSI = InternetAccessInResidence.StudentUSI
            AND studentEdOrg.EducationOrganizationId = InternetAccessInResidence.EducationOrganizationId
            AND InternetAccessInResidence.IndicatorName = 'InternetAccessInResidence'
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetAccessInResidenceDistrict
        ON districtEdOrg.StudentUSI = InternetAccessInResidenceDistrict.StudentUSI
            AND districtEdOrg.EducationOrganizationId = InternetAccessInResidenceDistrict.EducationOrganizationId
            AND InternetAccessInResidenceDistrict.IndicatorName = 'InternetAccessInResidence'
    --InternetAccessTypeInResidence
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetAccessTypeInResidence
        ON studentEdOrg.StudentUSI = InternetAccessTypeInResidence.StudentUSI
            AND studentEdOrg.EducationOrganizationId = InternetAccessTypeInResidence.EducationOrganizationId
            AND InternetAccessTypeInResidence.IndicatorName = 'InternetAccessTypeInResidence'
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetAccessTypeInResidenceDistrict
        ON districtEdOrg.StudentUSI = InternetAccessTypeInResidenceDistrict.StudentUSI
            AND districtEdOrg.EducationOrganizationId = InternetAccessTypeInResidenceDistrict.EducationOrganizationId
            AND InternetAccessTypeInResidenceDistrict.IndicatorName = 'InternetAccessTypeInResidence'
    --InternetPerformance
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetPerformance
        ON studentEdOrg.StudentUSI = InternetPerformance.StudentUSI
            AND studentEdOrg.EducationOrganizationId = InternetPerformance.EducationOrganizationId
            AND InternetPerformance.IndicatorName = 'InternetPerformance'
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetPerformanceDistrict
        ON districtEdOrg.StudentUSI = InternetPerformanceDistrict.StudentUSI
           AND districtEdOrg.EducationOrganizationId = InternetPerformanceDistrict.EducationOrganizationId
           AND InternetPerformanceDistrict.IndicatorName = 'InternetPerformance'
    --DigitalDevice
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS DigitalDevice
        ON studentEdOrg.StudentUSI = DigitalDevice.StudentUSI
            AND studentEdOrg.EducationOrganizationId = DigitalDevice.EducationOrganizationId
            AND DigitalDevice.IndicatorName = 'DigitalDevice'
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS DigitalDeviceDistrict
        ON districtEdOrg.StudentUSI = DigitalDeviceDistrict.StudentUSI
            AND districtEdOrg.EducationOrganizationId = DigitalDeviceDistrict.EducationOrganizationId
            AND DigitalDeviceDistrict.IndicatorName = 'DigitalDevice'
    --DeviceAccess
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS DeviceAccess
        ON studentEdOrg.StudentUSI = DeviceAccess.StudentUSI
            AND studentEdOrg.EducationOrganizationId = DeviceAccess.EducationOrganizationId
            AND DeviceAccess.IndicatorName = 'DeviceAccess'
    LEFT OUTER JOIN edfi.StudentEducationOrganizationAssociationStudentIndicator AS DeviceAccessDistrict
        ON districtEdOrg.StudentUSI = DeviceAccessDistrict.StudentUSI
            AND districtEdOrg.EducationOrganizationId = DeviceAccessDistrict.EducationOrganizationId
            AND DeviceAccessDistrict.IndicatorName = 'DeviceAccess'
    WHERE (
            StudentSchoolAssociation.ExitWithdrawDate IS NULL
            OR StudentSchoolAssociation.ExitWithdrawDate >= GETDATE()
            );
