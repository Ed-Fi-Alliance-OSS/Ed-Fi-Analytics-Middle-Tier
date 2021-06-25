-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
IF EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.VIEWS
        WHERE TABLE_SCHEMA = 'analytics'
            AND TABLE_NAME = 'StaffSectionDim'
        )
BEGIN
    DROP VIEW analytics.StaffSectionDim;
END;
GO

CREATE VIEW analytics.StaffSectionDim
AS
SELECT CONCAT (
        s.StaffUniqueId
        ,'-'
        ,CAST(StaffSectionAssociation.SchoolId AS NVARCHAR)
        ,'-'
        ,StaffSectionAssociation.LocalCourseCode
        ,'-'
        ,CAST(StaffSectionAssociation.SchoolYear AS NVARCHAR)
        ,'-'
        ,StaffSectionAssociation.SectionIdentifier
        ,'-'
        ,StaffSectionAssociation.SessionName
        ) AS StaffSectionKey
    ,s.StaffUniqueId AS UserKey
    ,CAST(StaffSectionAssociation.SchoolId AS VARCHAR) AS SchoolKey
    ,CONCAT (
        CAST(StaffSectionAssociation.SchoolId AS NVARCHAR)
        ,'-'
        ,StaffSectionAssociation.LocalCourseCode
        ,'-'
        ,CAST(StaffSectionAssociation.SchoolYear AS NVARCHAR)
        ,'-'
        ,StaffSectionAssociation.SectionIdentifier
        ,'-'
        ,StaffSectionAssociation.SessionName
        ) AS SectionKey
    ,COALESCE(s.PersonalTitlePrefix, '') AS PersonalTitlePrefix
    ,s.FirstName as StaffFirstName
    ,COALESCE(s.MiddleName, '') AS StaffMiddleName
    ,s.LastSurname as StaffLastName
    ,COALESCE(sem.ElectronicMailAddress, '') AS ElectronicMailAddress
    ,COALESCE(st.ShortDescription, '') AS Sex
    ,COALESCE(CAST(s.BirthDate AS VARCHAR(100)), '') AS BirthDate
    ,(
        CASE 
            WHEN RT.ShortDescription IS NULL
                THEN (
                        CASE 
                            WHEN RaceDisp.Race IS NULL
                                THEN 'Unknown'
                            ELSE 'Multiracial'
                            END
                        )
            ELSE RT.ShortDescription
            END
        ) AS Race
    ,COALESCE(s.HispanicLatinoEthnicity, 0) AS HispanicLatinoEthnicity
    ,COALESCE(d.ShortDescription, '') AS HighestCompletedLevelOfEducation
    ,COALESCE(s.YearsOfPriorProfessionalExperience, '0') AS YearsOfPriorProfessionalExperience
    ,COALESCE(s.YearsOfPriorTeachingExperience, '0') AS YearsOfPriorTeachingExperience
    ,COALESCE(s.HighlyQualifiedTeacher, 0) AS HighlyQualifiedTeacher
    ,COALESCE(s.LoginId, '') AS LoginId
    ,(
        SELECT MAX(MaxLastModifiedDate)
        FROM (
            VALUES (s.LastModifiedDate)
                ,(StaffSectionAssociation.LastModifiedDate)
            ) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate
FROM edfi.Staff s
INNER JOIN edfi.StaffSectionAssociation ON StaffSectionAssociation.StaffUSI = s.StaffUSI
LEFT JOIN edfi.StaffElectronicMail AS sem ON s.StaffUSI = sem.StaffUSI
LEFT JOIN edfi.Descriptor AS st ON s.SexDescriptorId = st.DescriptorId
LEFT JOIN (
    SELECT DISTINCT t1.StaffUSI
        ,STUFF((
                SELECT CAST(t2.RaceDescriptorID AS VARCHAR(100))
                FROM edfi.StaffRace t2
                WHERE t2.StaffUSI = t1.StaffUSI
                FOR XML PATH('')
                ), 1, 0, '') AS Race
    FROM edfi.StaffRace t1
    ) AS RaceDisp ON S.StaffUSI = RaceDisp.StaffUSI
LEFT JOIN edfi.Descriptor AS RT ON RaceDisp.Race = RT.DescriptorId
LEFT JOIN edfi.Descriptor AS d ON s.HighestCompletedLevelOfEducationDescriptorId = d.DescriptorId
WHERE StaffSectionAssociation.EndDate IS NULL
    OR StaffSectionAssociation.EndDate > GETDATE();
GO


