-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'StudentLocalEducationAgencyDim')
BEGIN
	DROP VIEW analytics.StudentLocalEducationAgencyDim
END
GO

CREATE VIEW analytics.StudentLocalEducationAgencyDim AS

	SELECT 
           CONCAT(Student.StudentUniqueId, '-', School.LocalEducationAgencyId) AS StudentLocalEducationAgencyKey,
           Student.StudentUniqueId AS StudentKey,
           CAST(School.LocalEducationAgencyId AS VARCHAR) AS LocalEducationAgencyKey, 
           Student.FirstName AS StudentFirstName, 
           COALESCE(Student.MiddleName, '') AS StudentMiddleName, 
           Student.LastSurname AS StudentLastName, 
           COALESCE(LimitedEnglishProficiencyDescriptor.CodeValue, 'Not Applicable') AS LimitedEnglishProficiency, 
           CAST(COALESCE(Student.HispanicLatinoEthnicity, 0) as BIT) AS IsHispanic, 
           COALESCE(SexDescriptor.CodeValue, '') AS Sex,
		   'n/a' as InternetAccessInResidence,
           'n/a' as InternetAccessTypeInResidence,
           'n/a' as InternetPerformance,
           'n/a' as DigitalDevice,
           'n/a' as DeviceAccess,
           ( SELECT
                MAX(MaxLastModifiedDate)
             FROM (VALUES(StudentSchoolAssociation.LastModifiedDate),
                (Student.LastModifiedDate))AS VALUE(MaxLastModifiedDate)) AS LastModifiedDate
    FROM 
         edfi.Student
    INNER JOIN
        edfi.StudentSchoolAssociation ON
            Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN 
        edfi.School
    ON
        StudentSchoolAssociation.SchoolId = School.SchoolId
    INNER JOIN 
        edfi.EducationOrganization
    ON
        School.LocalEducationAgencyId = EducationOrganization.EducationOrganizationId
    LEFT JOIN
        edfi.Descriptor AS LimitedEnglishProficiencyDescriptor ON
            Student.LimitedEnglishProficiencyDescriptorId = LimitedEnglishProficiencyDescriptor.DescriptorId
    LEFT JOIN
        edfi.SexType AS SexDescriptor ON
            Student.SexTypeId = SexDescriptor.SexTypeId
   WHERE ExitWithdrawDate IS NULL OR ExitWithdrawDate > GETDATE();
GO
