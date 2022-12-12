-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


IF EXISTS
          ( SELECT 
                   1
            FROM 
                 INFORMATION_SCHEMA.VIEWS
            WHERE
                    TABLE_SCHEMA = 'analytics'
                    AND
                    TABLE_NAME = 'StudentLocalEducationAgencyDemographicsBridge'
          ) 
    BEGIN
        DROP VIEW 
             analytics.StudentLocalEducationAgencyDemographicsBridge;
END;
GO
CREATE VIEW analytics.StudentLocalEducationAgencyDemographicsBridge
AS
    WITH StudentLocalEducationAgencyDemographics
         AS (SELECT 
                    CONCAT('CohortYear:', CAST(SchoolYearType.SchoolYear AS VARCHAR), '-', Descriptor.CodeValue, '-', CAST(Student.StudentUniqueId AS VARCHAR), '-', CAST(LocalEducationAgency.LocalEducationAgencyId AS VARCHAR)) AS StudentSchoolDemographicBridgeKey, 
                    CONCAT(CAST(Student.StudentUniqueId AS VARCHAR), '-', CAST(LocalEducationAgency.LocalEducationAgencyId AS VARCHAR)) AS StudentLocalEducationAgencyKey, 
                    CONCAT('CohortYear:', CAST(SchoolYearType.SchoolYear AS VARCHAR), '-', Descriptor.CodeValue) AS DemographicKey, 
                    LocalEducationAgency.LocalEducationAgencyId,
                    Student.StudentUSI
             FROM 
                  edfi.StudentEducationOrganizationAssociationCohortYear
             INNER JOIN
                 edfi.SchoolYearType ON
                     StudentEducationOrganizationAssociationCohortYear.SchoolYear = SchoolYearType.SchoolYear
             INNER JOIN
                 edfi.CohortYearTypeDescriptor ON
                     StudentEducationOrganizationAssociationCohortYear.CohortYearTypeDescriptorId = CohortYearTypeDescriptor.CohortYearTypeDescriptorId
             INNER JOIN
                 edfi.Descriptor ON
                     CohortYearTypeDescriptor.CohortYearTypeDescriptorId = Descriptor.DescriptorId
             INNER JOIN
                 edfi.StudentEducationOrganizationAssociation ON
                     StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationCohortYear.StudentUSI
                     AND
                     StudentEducationOrganizationAssociation.EducationOrganizationId = StudentEducationOrganizationAssociationCohortYear.EducationOrganizationId
             INNER JOIN
                 edfi.Student ON
                     Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
             INNER JOIN
                 edfi.LocalEducationAgency ON
                     StudentEducationOrganizationAssociation.EducationOrganizationId = LocalEducationAgency.LocalEducationAgencyId
             UNION ALL
             SELECT 
                    CONCAT('DisabilityDesignation:', Descriptor.CodeValue, '-', Student.StudentUniqueId, '-', LocalEducationAgency.LocalEducationAgencyId) AS StudentSchoolDemographicBridgeKey, 
                    CONCAT(CAST(Student.StudentUniqueId AS VARCHAR), '-', CAST(LocalEducationAgency.LocalEducationAgencyId AS VARCHAR)) AS StudentLocalEducationAgencyKey, 
                    CONCAT('DisabilityDesignation:', Descriptor.CodeValue) AS DemographicKey, 
                    LocalEducationAgency.LocalEducationAgencyId,
                    Student.StudentUSI
             FROM 
                  edfi.StudentEducationOrganizationAssociationDisabilityDesignation
             INNER JOIN
                 edfi.DisabilityDesignationDescriptor ON
                     StudentEducationOrganizationAssociationDisabilityDesignation.DisabilityDesignationDescriptorId = DisabilityDesignationDescriptor.DisabilityDesignationDescriptorId
             INNER JOIN
                 edfi.Descriptor ON
                     DisabilityDesignationDescriptor.DisabilityDesignationDescriptorId = Descriptor.DescriptorId
             INNER JOIN
                 edfi.StudentEducationOrganizationAssociation ON
                     StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationDisabilityDesignation.StudentUSI
                     AND
                     StudentEducationOrganizationAssociation.EducationOrganizationId = StudentEducationOrganizationAssociationDisabilityDesignation.EducationOrganizationId
             INNER JOIN
                 edfi.Student ON
                     Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
             INNER JOIN
                 edfi.LocalEducationAgency ON
                     StudentEducationOrganizationAssociation.EducationOrganizationId = LocalEducationAgency.LocalEducationAgencyId
             UNION ALL
             SELECT 
                    CONCAT('Disability:', Descriptor.CodeValue, '-', Student.StudentUniqueId, '-', LocalEducationAgency.LocalEducationAgencyId) AS StudentSchoolDemographicBridgeKey, 
                    CONCAT(CAST(Student.StudentUniqueId AS VARCHAR), '-', CAST(LocalEducationAgency.LocalEducationAgencyId AS VARCHAR)) AS StudentLocalEducationAgencyKey, 
                    CONCAT('Disability:', Descriptor.CodeValue) AS DemographicKey, 
                    LocalEducationAgency.LocalEducationAgencyId,
                    Student.StudentUSI
             FROM 
                  edfi.StudentEducationOrganizationAssociationDisability
             INNER JOIN
                 edfi.DisabilityDescriptor ON
                     StudentEducationOrganizationAssociationDisability.DisabilityDescriptorId = DisabilityDescriptor.DisabilityDescriptorId
             INNER JOIN
                 edfi.Descriptor ON
                     DisabilityDescriptor.DisabilityDescriptorId = Descriptor.DescriptorId
             INNER JOIN
                 edfi.StudentEducationOrganizationAssociation ON
                     StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationDisability.StudentUSI
                     AND
                     StudentEducationOrganizationAssociation.EducationOrganizationId = StudentEducationOrganizationAssociationDisability.EducationOrganizationId
             INNER JOIN
                 edfi.Student ON
                     Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
             INNER JOIN
                 edfi.LocalEducationAgency ON
                     StudentEducationOrganizationAssociation.EducationOrganizationId = LocalEducationAgency.LocalEducationAgencyId
             UNION ALL
             SELECT 
                    CONCAT('LanguageUse:', Descriptor.CodeValue, '-', Student.StudentUniqueId, '-', LocalEducationAgency.LocalEducationAgencyId) AS StudentSchoolDemographicBridgeKey, 
                    CONCAT(CAST(Student.StudentUniqueId AS VARCHAR), '-', CAST(LocalEducationAgency.LocalEducationAgencyId AS VARCHAR)) AS StudentLocalEducationAgencyKey, 
                    CONCAT('LanguageUse:', Descriptor.CodeValue) AS DemographicKey, 
                    LocalEducationAgency.LocalEducationAgencyId,
                    Student.StudentUSI
             FROM 
                  edfi.StudentEducationOrganizationAssociationLanguageUse
             INNER JOIN
                 edfi.LanguageUseDescriptor ON
                     StudentEducationOrganizationAssociationLanguageUse.LanguageUseDescriptorId = LanguageUseDescriptor.LanguageUseDescriptorId
             INNER JOIN
                 edfi.Descriptor ON
                     LanguageUseDescriptor.LanguageUseDescriptorId = Descriptor.DescriptorId
             INNER JOIN
                 edfi.StudentEducationOrganizationAssociation ON
                     StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationLanguageUse.StudentUSI
                     AND
                     StudentEducationOrganizationAssociation.EducationOrganizationId = StudentEducationOrganizationAssociationLanguageUse.EducationOrganizationId
             INNER JOIN
                 edfi.Student ON
                     Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
             INNER JOIN
                 edfi.LocalEducationAgency ON
                     StudentEducationOrganizationAssociation.EducationOrganizationId = LocalEducationAgency.LocalEducationAgencyId
             UNION ALL
             SELECT 
                    CONCAT('Language:', Descriptor.CodeValue, '-', Student.StudentUniqueId, '-', LocalEducationAgency.LocalEducationAgencyId) AS StudentSchoolDemographicBridgeKey, 
                    CONCAT(CAST(Student.StudentUniqueId AS VARCHAR), '-', CAST(LocalEducationAgency.LocalEducationAgencyId AS VARCHAR)) AS StudentLocalEducationAgencyKey, 
                    CONCAT('Language:', Descriptor.CodeValue) AS DemographicKey, 
                    LocalEducationAgency.LocalEducationAgencyId,
                    Student.StudentUSI
             FROM 
                  edfi.StudentEducationOrganizationAssociationLanguage
             INNER JOIN
                 edfi.LanguageDescriptor ON
                     StudentEducationOrganizationAssociationLanguage.LanguageDescriptorId = LanguageDescriptor.LanguageDescriptorId
             INNER JOIN
                 edfi.Descriptor ON
                     LanguageDescriptor.LanguageDescriptorId = Descriptor.DescriptorId
             INNER JOIN
                 edfi.StudentEducationOrganizationAssociation ON
                     StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationLanguage.StudentUSI
                     AND
                     StudentEducationOrganizationAssociation.EducationOrganizationId = StudentEducationOrganizationAssociationLanguage.EducationOrganizationId
             INNER JOIN
                 edfi.Student ON
                     Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
             INNER JOIN
                 edfi.LocalEducationAgency ON
                     StudentEducationOrganizationAssociation.EducationOrganizationId = LocalEducationAgency.LocalEducationAgencyId
             UNION ALL
             SELECT 
                    CONCAT('Race:', Descriptor.CodeValue, '-', Student.StudentUniqueId, '-', LocalEducationAgency.LocalEducationAgencyId) AS StudentSchoolDemographicBridgeKey, 
                    CONCAT(CAST(Student.StudentUniqueId AS VARCHAR), '-', CAST(LocalEducationAgency.LocalEducationAgencyId AS VARCHAR)) AS StudentLocalEducationAgencyKey, 
                    CONCAT('Race:', Descriptor.CodeValue) AS DemographicKey, 
                    LocalEducationAgency.LocalEducationAgencyId,
                    Student.StudentUSI
             FROM 
                  edfi.StudentEducationOrganizationAssociationRace
             INNER JOIN
                 edfi.RaceDescriptor ON
                     StudentEducationOrganizationAssociationRace.RaceDescriptorId = RaceDescriptor.RaceDescriptorId
             INNER JOIN
                 edfi.Descriptor ON
                     RaceDescriptor.RaceDescriptorId = Descriptor.DescriptorId
             INNER JOIN
                 edfi.StudentEducationOrganizationAssociation ON
                     StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationRace.StudentUSI
                     AND
                     StudentEducationOrganizationAssociation.EducationOrganizationId = StudentEducationOrganizationAssociationRace.EducationOrganizationId
             INNER JOIN
                 edfi.Student ON
                     Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
             INNER JOIN
                 edfi.LocalEducationAgency ON
                     StudentEducationOrganizationAssociation.EducationOrganizationId = LocalEducationAgency.LocalEducationAgencyId
             UNION ALL
             SELECT 
                    CONCAT('TribalAffiliation:', Descriptor.CodeValue, '-', Student.StudentUniqueId, '-', LocalEducationAgency.LocalEducationAgencyId) AS StudentSchoolDemographicBridgeKey, 
                    CONCAT(CAST(Student.StudentUniqueId AS VARCHAR), '-', CAST(LocalEducationAgency.LocalEducationAgencyId AS VARCHAR)) AS StudentLocalEducationAgencyKey, 
                    CONCAT('TribalAffiliation:', Descriptor.CodeValue) AS DemographicKey, 
                    LocalEducationAgency.LocalEducationAgencyId,
                    Student.StudentUSI
             FROM 
                  edfi.StudentEducationOrganizationAssociationTribalAffiliation
             INNER JOIN
                 edfi.TribalAffiliationDescriptor ON
                     StudentEducationOrganizationAssociationTribalAffiliation.TribalAffiliationDescriptorId = TribalAffiliationDescriptor.TribalAffiliationDescriptorId
             INNER JOIN
                 edfi.Descriptor ON
                     TribalAffiliationDescriptor.TribalAffiliationDescriptorId = Descriptor.DescriptorId
             INNER JOIN
                 edfi.StudentEducationOrganizationAssociation ON
                     StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationTribalAffiliation.StudentUSI
                     AND
                     StudentEducationOrganizationAssociation.EducationOrganizationId = StudentEducationOrganizationAssociationTribalAffiliation.EducationOrganizationId
             INNER JOIN
                 edfi.Student ON
                     Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
             INNER JOIN
                 edfi.LocalEducationAgency ON
                     StudentEducationOrganizationAssociation.EducationOrganizationId = LocalEducationAgency.LocalEducationAgencyId
             UNION ALL
             SELECT 
                    CONCAT('StudentCharacteristic:', Descriptor.CodeValue, '-', Student.StudentUniqueId, '-', LocalEducationAgency.LocalEducationAgencyId) AS StudentSchoolDemographicBridgeKey, 
                    CONCAT(CAST(Student.StudentUniqueId AS VARCHAR), '-', CAST(LocalEducationAgency.LocalEducationAgencyId AS VARCHAR)) AS StudentLocalEducationAgencyKey, 
                    CONCAT('StudentCharacteristic:', Descriptor.CodeValue) AS DemographicKey, 
                    LocalEducationAgency.LocalEducationAgencyId,
                    Student.StudentUSI
             FROM 
                  edfi.StudentEducationOrganizationAssociationStudentCharacteristic
             INNER JOIN
                 edfi.StudentCharacteristicDescriptor ON
                     StudentEducationOrganizationAssociationStudentCharacteristic.StudentCharacteristicDescriptorId = StudentCharacteristicDescriptor.StudentCharacteristicDescriptorId
             INNER JOIN
                 edfi.Descriptor ON
                     StudentCharacteristicDescriptor.StudentCharacteristicDescriptorId = Descriptor.DescriptorId
             INNER JOIN
                 edfi.StudentEducationOrganizationAssociation ON
                     StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationStudentCharacteristic.StudentUSI
                     AND
                     StudentEducationOrganizationAssociation.EducationOrganizationId = StudentEducationOrganizationAssociationStudentCharacteristic.EducationOrganizationId
             LEFT JOIN
                 edfi.StudentEducationOrganizationAssociationStudentCharacteristicPeriod ON
                     StudentEducationOrganizationAssociationStudentCharacteristicPeriod.EducationOrganizationId = StudentEducationOrganizationAssociationStudentCharacteristic.EducationOrganizationId
                     AND
                     StudentEducationOrganizationAssociationStudentCharacteristicPeriod.StudentUSI = StudentEducationOrganizationAssociationStudentCharacteristic.StudentUSI
                     AND
                     StudentEducationOrganizationAssociationStudentCharacteristicPeriod.StudentCharacteristicDescriptorId = StudentEducationOrganizationAssociationStudentCharacteristic.StudentCharacteristicDescriptorId
             INNER JOIN
                 edfi.Student ON
                     Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
             INNER JOIN
                 edfi.LocalEducationAgency ON
                     StudentEducationOrganizationAssociation.EducationOrganizationId = LocalEducationAgency.LocalEducationAgencyId
             WHERE
                   StudentEducationOrganizationAssociationStudentCharacteristicPeriod.EndDate IS NULL
                   OR
                     StudentEducationOrganizationAssociationStudentCharacteristicPeriod.EndDate > GETDATE())
         SELECT 
                StudentSchoolDemographicBridgeKey, 
                StudentLocalEducationAgencyKey, 
                DemographicKey
         FROM 
              StudentLocalEducationAgencyDemographics
         WHERE EXISTS
         (
            SELECT 
                   1
            FROM 
                 edfi.StudentSchoolAssociation
            INNER JOIN
                edfi.School ON
                    StudentSchoolAssociation.SchoolId = School.SchoolId
            WHERE
                    School.LocalEducationAgencyId = StudentLocalEducationAgencyDemographics.LocalEducationAgencyId
                    AND
                    StudentSchoolAssociation.StudentUSI = StudentLocalEducationAgencyDemographics.StudentUSI
                    AND (
                        StudentSchoolAssociation.ExitWithdrawDate IS NULL
                        OR
                    StudentSchoolAssociation.ExitWithdrawDate > GETDATE())
           );
              