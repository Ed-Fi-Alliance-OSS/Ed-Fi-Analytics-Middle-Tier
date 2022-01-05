﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
DROP VIEW IF EXISTS analytics.StudentSchoolDim;

CREATE OR REPLACE VIEW analytics.StudentSchoolDim
AS
SELECT
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        Student.StudentUniqueId AS StudentKey,
        CAST(StudentSchoolAssociation.SchoolId AS VARCHAR) AS SchoolKey,
        COALESCE(CAST(StudentSchoolAssociation.SchoolYear AS VARCHAR), 'Unknown') AS SchoolYear,
        Student.FirstName AS StudentFirstName,
        COALESCE(Student.MiddleName, '') AS StudentMiddleName,
        COALESCE(Student.LastSurname, '') AS StudentLastName,
        CAST(StudentSchoolAssociation.EntryDate AS VARCHAR) AS EnrollmentDateKey,
        Descriptor.CodeValue AS GradeLevel,
        COALESCE(CASE
                    WHEN studentEdOrg.StudentUSI IS NOT NULL
                    THEN LimitedEnglishDescriptorSchool.CodeValue
                    ELSE LimitedEnglishDescriptorDist.CodeValue
                END, 'Not applicable') AS LimitedEnglishProficiency,
        COALESCE(CASE
                    WHEN studentEdOrg.StudentUSI IS NOT NULL
                    THEN studentEdOrg.HispanicLatinoEthnicity
                    ELSE districtEdOrg.HispanicLatinoEthnicity
                END, FALSE) AS IsHispanic,
        COALESCE(CASE
                    WHEN studentEdOrg.StudentUSI IS NOT NULL
                    THEN SexTypeSchool.CodeValue
                    ELSE SexTypeDist.CodeValue
                END, '') AS Sex,
        CASE WHEN InternetAccessInResidence.Indicator IS NOT NULL THEN 'Internet Access In Residence' ELSE 'n/a' END as InternetAccessInResidence,
        CASE WHEN InternetAccessTypeInResidence.Indicator IS NOT NULL THEN 'Internet Access Type In Residence' ELSE 'n/a' END as InternetAccessInResidence,
        CASE WHEN InternetPerformance.Indicator IS NOT NULL THEN 'Internet Performance In Residence' ELSE 'n/a' END as InternetAccessInResidence,
        CASE WHEN DigitalDevice.Indicator IS NOT NULL THEN 'Digital Device' ELSE 'n/a' END as InternetAccessInResidence,
        CASE WHEN DeviceAccess.Indicator IS NOT NULL THEN 'Device Access' ELSE 'n/a' END as InternetAccessInResidence,
        (
            SELECT
                MAX(MaxLastModifiedDate)
            FROM (VALUES
                (Student.LastModifiedDate)
                ,(studentEdOrg.LastModifiedDate)
                ,(districtEdOrg.LastModifiedDate)
            ) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate,
        Student.BirthDate
    FROM
        edfi.Student
    INNER JOIN
        edfi.StudentSchoolAssociation ON
            Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN
        edfi.Descriptor ON
            StudentSchoolAssociation.EntryGradeLevelDescriptorId = Descriptor.DescriptorId
    INNER JOIN
        edfi.School ON
            StudentSchoolAssociation.SchoolId = School.SchoolId
    LEFT OUTER JOIN
        edfi.StudentEducationOrganizationAssociation AS studentEdOrg ON
            Student.StudentUSI = studentEdOrg.StudentUSI
            AND StudentSchoolAssociation.SchoolId = studentEdOrg.EducationOrganizationId
    LEFT OUTER JOIN
        edfi.Descriptor AS LimitedEnglishDescriptorSchool ON
            studentEdOrg.LimitedEnglishProficiencyDescriptorId = LimitedEnglishDescriptorSchool.DescriptorId
    LEFT OUTER JOIN
        edfi.Descriptor AS SexTypeSchool ON
            studentEdOrg.SexDescriptorId = SexTypeSchool.DescriptorId
    LEFT OUTER JOIN
        edfi.StudentEducationOrganizationAssociation AS districtEdOrg ON
            Student.StudentUSI = districtEdOrg.StudentUSI
            AND School.LocalEducationAgencyId = districtEdOrg.EducationOrganizationId
    LEFT OUTER JOIN
        edfi.Descriptor AS LimitedEnglishDescriptorDist ON
            districtEdOrg.LimitedEnglishProficiencyDescriptorId = LimitedEnglishDescriptorDist.DescriptorId
    LEFT OUTER JOIN
        edfi.Descriptor AS SexTypeDist ON
            districtEdOrg.SexDescriptorId = SexTypeDist.DescriptorId
    LEFT OUTER JOIN
        edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetAccessInResidence ON
            studentEdOrg.StudentUSI = InternetAccessInResidence.StudentUSI
            AND
            studentEdOrg.EducationOrganizationId = InternetAccessInResidence.EducationOrganizationId
            AND
            InternetAccessInResidence.IndicatorName = 'Internet Access In Residence'
    LEFT OUTER JOIN
        edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetAccessTypeInResidence ON
            studentEdOrg.StudentUSI = InternetAccessTypeInResidence.StudentUSI
            AND
            studentEdOrg.EducationOrganizationId = InternetAccessTypeInResidence.EducationOrganizationId
            AND
            InternetAccessTypeInResidence.IndicatorName = 'Internet Access Type In Residence'
    LEFT OUTER JOIN
        edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetPerformance ON
            studentEdOrg.StudentUSI = InternetPerformance.StudentUSI
            AND
            studentEdOrg.EducationOrganizationId = InternetPerformance.EducationOrganizationId
            AND
            InternetPerformance.IndicatorName = 'Internet Performance In Residence'
    LEFT OUTER JOIN
        edfi.StudentEducationOrganizationAssociationStudentIndicator AS DigitalDevice ON
            studentEdOrg.StudentUSI = DigitalDevice.StudentUSI
            AND
            studentEdOrg.EducationOrganizationId = DigitalDevice.EducationOrganizationId
            AND
            DigitalDevice.IndicatorName = 'Digital Device'
    LEFT OUTER JOIN
        edfi.StudentEducationOrganizationAssociationStudentIndicator AS DeviceAccess ON
            studentEdOrg.StudentUSI = DeviceAccess.StudentUSI
            AND
            studentEdOrg.EducationOrganizationId = DeviceAccess.EducationOrganizationId
            AND
            DeviceAccess.IndicatorName = 'Device Access'
    WHERE(
        StudentSchoolAssociation.ExitWithdrawDate IS NULL OR StudentSchoolAssociation.ExitWithdrawDate >= now());
