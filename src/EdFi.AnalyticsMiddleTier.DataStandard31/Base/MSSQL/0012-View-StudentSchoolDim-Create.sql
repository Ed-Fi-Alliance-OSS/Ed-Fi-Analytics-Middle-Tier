-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS
(
    SELECT 1
    FROM
        INFORMATION_SCHEMA.VIEWS
    WHERE
        TABLE_SCHEMA = 'analytics'
    AND
        TABLE_NAME = 'StudentSchoolDim'
)
BEGIN
    DROP VIEW analytics.StudentSchoolDim;
END;
GO

CREATE VIEW analytics.StudentSchoolDim
AS
    SELECT
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        Student.StudentUniqueId AS StudentKey,
        CAST(StudentSchoolAssociation.SchoolId AS VARCHAR) AS SchoolKey,
        COALESCE(CAST(StudentSchoolAssociation.SchoolYear AS VARCHAR), 'Unknown') AS SchoolYear,
        Student.FirstName AS StudentFirstName,
        COALESCE(Student.MiddleName, '') AS StudentMiddleName,
        COALESCE(Student.LastSurname, '') AS StudentLastName,
        CAST(StudentSchoolAssociation.EntryDate AS NVARCHAR) AS EnrollmentDateKey,
        Descriptor.CodeValue AS GradeLevel,
        COALESCE(CASE
                    WHEN schoolEdOrg.StudentUSI IS NOT NULL
                    THEN LimitedEnglishDescriptorSchool.CodeValue
                    ELSE LimitedEnglishDescriptorDist.CodeValue
                END, 'Not applicable') AS LimitedEnglishProficiency,
        COALESCE(CASE
                    WHEN schoolEdOrg.StudentUSI IS NOT NULL
                    THEN schoolEdOrg.HispanicLatinoEthnicity
                    ELSE districtEdOrg.HispanicLatinoEthnicity
                END, CAST(0 as BIT)) AS IsHispanic,
        COALESCE(CASE
                    WHEN schoolEdOrg.StudentUSI IS NOT NULL
                    THEN SexTypeSchool.CodeValue
                    ELSE SexTypeDist.CodeValue
                END, '') AS Sex,
        (
            SELECT
                MAX(MaxLastModifiedDate)
            FROM (VALUES
                (Student.LastModifiedDate)
                ,(schoolEdOrg.LastModifiedDate)
                ,(districtEdOrg.LastModifiedDate)
            ) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate
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
        edfi.StudentEducationOrganizationAssociation AS schoolEdOrg ON
            Student.StudentUSI = schoolEdOrg.StudentUSI
            AND StudentSchoolAssociation.SchoolId = schoolEdOrg.EducationOrganizationId
    LEFT OUTER JOIN
        edfi.Descriptor AS LimitedEnglishDescriptorSchool ON
            schoolEdOrg.LimitedEnglishProficiencyDescriptorId = LimitedEnglishDescriptorSchool.DescriptorId
    LEFT OUTER JOIN
        edfi.Descriptor AS SexTypeSchool ON
            schoolEdOrg.SexDescriptorId = SexTypeSchool.DescriptorId
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
    WHERE(
        StudentSchoolAssociation.ExitWithdrawDate IS NULL
        OR StudentSchoolAssociation.ExitWithdrawDate >= GETDATE());
GO
