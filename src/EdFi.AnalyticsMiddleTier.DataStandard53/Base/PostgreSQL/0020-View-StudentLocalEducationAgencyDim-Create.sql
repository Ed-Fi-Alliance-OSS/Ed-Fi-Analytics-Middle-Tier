-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
DROP VIEW IF EXISTS analytics.StudentLocalEducationAgencyDim;

CREATE OR REPLACE VIEW analytics.StudentLocalEducationAgencyDim
AS
   SELECT 
           CONCAT(Student.StudentUniqueId, '-', LocalEducationAgency.LocalEducationAgencyId) AS StudentLocalEducationAgencyKey,
           Student.StudentUniqueId AS StudentKey,
           CAST(LocalEducationAgency.LocalEducationAgencyId AS VARCHAR) AS LocalEducationAgencyKey, 
           Student.FirstName AS StudentFirstName, 
           COALESCE(Student.MiddleName, '') AS StudentMiddleName, 
           Student.LastSurname AS StudentLastName, 
           COALESCE(LimitedEnglishProficiencyDescriptor.CodeValue, 'Not Applicable') AS LimitedEnglishProficiency, 
           COALESCE(StudentEducationOrganizationAssociation.HispanicLatinoEthnicity, false) AS IsHispanic, 
           COALESCE(SexDescriptor.CodeValue, '') AS Sex,
           COALESCE(InternetAccessInResidence.Indicator,'n/a') as InternetAccessInResidence,
           COALESCE(InternetAccessTypeInResidence.Indicator,'n/a') as InternetAccessTypeInResidence,
           COALESCE(InternetPerformance.Indicator,'n/a') as InternetPerformance,
           COALESCE(DigitalDevice.Indicator,'n/a') as DigitalDevice,
           COALESCE(DeviceAccess.Indicator,'n/a') as DeviceAccess,
           ( SELECT
                MAX(MaxLastModifiedDate)
             FROM (VALUES(StudentSchoolAssociation.LastModifiedDate),
                (Student.LastModifiedDate),
                (StudentEducationOrganizationAssociation.LastModifiedDate))AS VALUE(MaxLastModifiedDate)) AS LastModifiedDate
    FROM 
         edfi.Student
    INNER JOIN
        edfi.StudentSchoolAssociation ON
            Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN
        edfi.StudentEducationOrganizationAssociation ON
            Student.StudentUSI = StudentEducationOrganizationAssociation.StudentUSI
    INNER JOIN
        edfi.LocalEducationAgency ON
            StudentEducationOrganizationAssociation.EducationOrganizationId = LocalEducationAgency.LocalEducationAgencyId
    LEFT JOIN
        edfi.Descriptor AS LimitedEnglishProficiencyDescriptor ON
            StudentEducationOrganizationAssociation.LimitedEnglishProficiencyDescriptorId = LimitedEnglishProficiencyDescriptor.DescriptorId
    LEFT JOIN
        edfi.Descriptor AS SexDescriptor ON
            StudentEducationOrganizationAssociation.SexDescriptorId = SexDescriptor.DescriptorId
    LEFT OUTER JOIN
        edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetAccessInResidence ON
            StudentEducationOrganizationAssociation.StudentUSI = InternetAccessInResidence.StudentUSI
            AND
            StudentEducationOrganizationAssociation.EducationOrganizationId = InternetAccessInResidence.EducationOrganizationId
            AND
            InternetAccessInResidence.IndicatorName = 'InternetAccessInResidence'
    LEFT OUTER JOIN
        edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetAccessTypeInResidence ON
            StudentEducationOrganizationAssociation.StudentUSI = InternetAccessTypeInResidence.StudentUSI
            AND
            StudentEducationOrganizationAssociation.EducationOrganizationId = InternetAccessTypeInResidence.EducationOrganizationId
            AND
            InternetAccessTypeInResidence.IndicatorName = 'InternetAccessTypeInResidence'
    LEFT OUTER JOIN
        edfi.StudentEducationOrganizationAssociationStudentIndicator AS InternetPerformance ON
            StudentEducationOrganizationAssociation.StudentUSI = InternetPerformance.StudentUSI
            AND
            StudentEducationOrganizationAssociation.EducationOrganizationId = InternetPerformance.EducationOrganizationId
            AND
            InternetPerformance.IndicatorName = 'InternetPerformance'
    LEFT OUTER JOIN
        edfi.StudentEducationOrganizationAssociationStudentIndicator AS DigitalDevice ON
            StudentEducationOrganizationAssociation.StudentUSI = DigitalDevice.StudentUSI
            AND
            StudentEducationOrganizationAssociation.EducationOrganizationId = DigitalDevice.EducationOrganizationId
            AND
            DigitalDevice.IndicatorName = 'DigitalDevice'
    LEFT OUTER JOIN
        edfi.StudentEducationOrganizationAssociationStudentIndicator AS DeviceAccess ON
            StudentEducationOrganizationAssociation.StudentUSI = DeviceAccess.StudentUSI
            AND
            StudentEducationOrganizationAssociation.EducationOrganizationId = DeviceAccess.EducationOrganizationId
            AND
            DeviceAccess.IndicatorName = 'DeviceAccess'
   WHERE
        StudentSchoolAssociation.ExitWithdrawDate IS NULL OR StudentSchoolAssociation.ExitWithdrawDate > NOW();