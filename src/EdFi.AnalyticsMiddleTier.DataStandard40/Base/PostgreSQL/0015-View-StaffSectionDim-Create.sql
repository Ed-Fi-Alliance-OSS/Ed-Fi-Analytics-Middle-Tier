-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW analytics.StaffSectionDim AS

    SELECT
        CONCAT (
            s.StaffUniqueId
            ,'-'
            ,CAST(StaffSectionAssociation.SchoolId AS VARCHAR)
            ,'-'
            ,StaffSectionAssociation.LocalCourseCode
            ,'-'
            ,CAST(StaffSectionAssociation.SchoolYear AS VARCHAR)
            ,'-'
            ,StaffSectionAssociation.SectionIdentifier
            ,'-'
            ,StaffSectionAssociation.SessionName
        ) AS StaffSectionKey
        ,s.StaffUniqueId AS UserKey
        ,CAST(StaffSectionAssociation.SchoolId AS VARCHAR) AS SchoolKey
        ,CONCAT (
            CAST(StaffSectionAssociation.SchoolId AS VARCHAR)
            ,'-'
            ,StaffSectionAssociation.LocalCourseCode
            ,'-'
            ,CAST(StaffSectionAssociation.SchoolYear AS VARCHAR)
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
        ,COALESCE(s.HispanicLatinoEthnicity, FALSE) AS HispanicLatinoEthnicity
        ,COALESCE(d.ShortDescription, '') AS HighestCompletedLevelOfEducation
        ,COALESCE(s.YearsOfPriorProfessionalExperience, '0') AS YearsOfPriorProfessionalExperience
        ,COALESCE(s.YearsOfPriorTeachingExperience, '0') AS YearsOfPriorTeachingExperience
        ,COALESCE(s.HighlyQualifiedTeacher, FALSE) AS HighlyQualifiedTeacher
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
            ,(
                SELECT STRING_AGG(CAST(t2.RaceDescriptorID AS VARCHAR(100)), ',')
                FROM edfi.StaffRace t2
                WHERE t2.StaffUSI = t1.StaffUSI
                ) AS Race
        FROM edfi.StaffRace t1
        ) AS RaceDisp ON S.StaffUSI = RaceDisp.StaffUSI
    LEFT JOIN edfi.Descriptor AS RT ON RaceDisp.Race = CAST(RT.DescriptorId AS VARCHAR(100))
    LEFT JOIN edfi.Descriptor AS d ON s.HighestCompletedLevelOfEducationDescriptorId = d.DescriptorId
    WHERE StaffSectionAssociation.EndDate IS NULL
        OR StaffSectionAssociation.EndDate > NOW();
