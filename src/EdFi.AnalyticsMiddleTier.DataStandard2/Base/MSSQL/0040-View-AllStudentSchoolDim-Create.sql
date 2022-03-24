-- SPDX-License-Identifier: Apache-2.0
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
    DROP VIEW analytics.AllStudentSchoolDim
END
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
        ,COALESCE(LimitedEnglishDescriptor.CodeValue, 'Not applicable') AS LimitedEnglishProficiency
        ,Student.HispanicLatinoEthnicity AS IsHispanic
        ,SexType.CodeValue AS Sex
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
                    ,(StudentSchoolAssociation.LastModifiedDate)
                ) AS VALUE(MaxLastModifiedDate)
            ) AS LastModifiedDate
    FROM edfi.Student
    INNER JOIN edfi.StudentSchoolAssociation
        ON Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN edfi.Descriptor
        ON StudentSchoolAssociation.EntryGradeLevelDescriptorId = Descriptor.DescriptorId
    LEFT OUTER JOIN edfi.Descriptor AS LimitedEnglishDescriptor
        ON Student.LimitedEnglishProficiencyDescriptorId = LimitedEnglishDescriptor.DescriptorId
    INNER JOIN edfi.SexType
        ON Student.SexTypeId = SexType.SexTypeId;