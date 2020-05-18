﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'StudentLocalEducationAgencyDim')
BEGIN
	DROP VIEW analytics.StudentLocalEducationAgencyDim
END
GO

CREATE VIEW analytics.StudentLocalEducationAgencyDim
AS
    SELECT 
           CONCAT(Student.StudentUniqueId, '-', LocalEducationAgency.LocalEducationAgencyId) AS StudentLocalEducationAgencyKey,
           Student.StudentUniqueId ​AS StudentKey​,
           CAST(LocalEducationAgency.LocalEducationAgencyId AS VARCHAR) AS LocalEducationAgencyKey, 
           Student.FirstName AS StudentFirstName, 
           COALESCE(Student.MiddleName, '') AS StudentMiddleName, 
           Student.LastSurname AS StudentLastName, 
           COALESCE(LimitedEnglishProficiencyDescriptor.CodeValue, 'Not Applicable') AS LimitedEnglishProficiency, 
           COALESCE(StudentEducationOrganizationAssociation.HispanicLatinoEthnicity, 0) AS IsHispanic, 
           COALESCE(SexDescriptor.CodeValue, '') AS Sex,
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
    WHERE StudentSchoolAssociation.ExitWithdrawDate IS NULL OR StudentSchoolAssociation.ExitWithdrawDate > GETDATE();