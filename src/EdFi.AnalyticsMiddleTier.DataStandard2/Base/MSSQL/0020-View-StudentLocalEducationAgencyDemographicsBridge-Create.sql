-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'StudentLocalEducationAgencyDemographicsBridge')
BEGIN
	DROP VIEW analytics.StudentLocalEducationAgencyDemographicsBridge
END
GO

CREATE VIEW analytics.StudentLocalEducationAgencyDemographicsBridge AS
WITH StudentLocalEducationAgencyDemographics AS (
    SELECT
		CONCAT(
            'CohortYear:', 
            StudentCohortYear.SchoolYear, 
            '-', 
            CohortYearType.CodeValue,
            '-', 
            Student.StudentUniqueId,
            '-', 
            School.LocalEducationAgencyId
        ) AS StudentSchoolDemographicBridgeKey,
		CONCAT(
            CAST(Student.StudentUniqueId AS VARCHAR),
            '-', 
            CAST(School.LocalEducationAgencyId AS VARCHAR)
        ) AS StudentLocalEducationAgencyKey,
        CONCAT(
            'CohortYear:', 
            StudentCohortYear.SchoolYear, 
            '-', 
            CohortYearType.CodeValue
        ) AS DemographicKey,
        StudentSchoolAssociation.ExitWithdrawDate
	FROM
		edfi.CohortYearType
	INNER JOIN
		edfi.StudentCohortYear
            ON CohortYearType.CohortYearTypeId = StudentCohortYear.CohortYearTypeId
    INNER JOIN
        edfi.Student
            ON StudentCohortYear.StudentUSI = Student.StudentUSI
    INNER JOIN
        edfi.StudentSchoolAssociation
            ON Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN
        edfi.School
            ON StudentSchoolAssociation.SchoolId = School.SchoolId

    UNION ALL
    
    SELECT
		CONCAT(
            'Disability:',
            Descriptor.CodeValue,
            '-', 
            Student.StudentUniqueId,
            '-', 
            School.LocalEducationAgencyId
        ) AS StudentSchoolDemographicBridgeKey,
		CONCAT(
            CAST(Student.StudentUniqueId AS VARCHAR),
            '-', 
            CAST(School.LocalEducationAgencyId AS VARCHAR)
        ) AS StudentLocalEducationAgencyKey,
        CONCAT(
            'Disability:',
            Descriptor.CodeValue
        ) AS DemographicKey,
        StudentSchoolAssociation.ExitWithdrawDate
	FROM
		edfi.StudentDisability
    INNER JOIN
        edfi.DisabilityDescriptor
            ON StudentDisability.DisabilityDescriptorId = DisabilityDescriptor.DisabilityDescriptorId
    INNER JOIN
        edfi.Descriptor
            ON DisabilityDescriptor.DisabilityDescriptorId = Descriptor.DescriptorId
    INNER JOIN
        edfi.Student
            ON StudentDisability.StudentUSI = Student.StudentUSI
    INNER JOIN
        edfi.StudentSchoolAssociation
            ON Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN
        edfi.School
            ON StudentSchoolAssociation.SchoolId = School.SchoolId

    UNION ALL
    
    SELECT
		CONCAT(
            'LanguageUse:',
            LanguageUseType.CodeValue,
            '-', 
            Student.StudentUniqueId,
            '-', 
            School.LocalEducationAgencyId
        ) AS StudentSchoolDemographicBridgeKey,
		CONCAT(
            CAST(Student.StudentUniqueId AS VARCHAR),
            '-', 
            CAST(School.LocalEducationAgencyId AS VARCHAR)
        ) AS StudentLocalEducationAgencyKey,
        CONCAT(
            'LanguageUse:',
            LanguageUseType.CodeValue
        ) AS DemographicKey,
        StudentSchoolAssociation.ExitWithdrawDate
	FROM
        edfi.LanguageUseType
	INNER JOIN 
		edfi.StudentLanguageUse
		    ON LanguageUseType.LanguageUseTypeId = StudentLanguageUse.LanguageUseTypeId
    INNER JOIN
        edfi.Student
            ON StudentLanguageUse.StudentUSI = Student.StudentUSI
    INNER JOIN
        edfi.StudentSchoolAssociation
            ON Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN
        edfi.School
            ON StudentSchoolAssociation.SchoolId = School.SchoolId

    UNION ALL
    
    SELECT
		CONCAT(
            'Language:',
            Descriptor.CodeValue,
            '-', 
            Student.StudentUniqueId,
            '-', 
            School.LocalEducationAgencyId
        ) AS StudentSchoolDemographicBridgeKey,
		CONCAT(
            CAST(Student.StudentUniqueId AS VARCHAR),
            '-', 
            CAST(School.LocalEducationAgencyId AS VARCHAR)
        ) AS StudentLocalEducationAgencyKey,
        CONCAT(
            'Language:',
            Descriptor.CodeValue
        ) AS DemographicKey,
        StudentSchoolAssociation.ExitWithdrawDate
	FROM
        edfi.Descriptor
	INNER JOIN
		edfi.StudentLanguage
		    ON Descriptor.DescriptorId = StudentLanguage.LanguageDescriptorId
    INNER JOIN
        edfi.Student
            ON StudentLanguage.StudentUSI = Student.StudentUSI
    INNER JOIN
        edfi.StudentSchoolAssociation
            ON Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN
        edfi.School
            ON StudentSchoolAssociation.SchoolId = School.SchoolId

	UNION ALL
	
    SELECT
        CONCAT(
            'Race:',
            RaceType.CodeValue,
            '-', 
            Student.StudentUniqueId,
            '-', 
            School.LocalEducationAgencyId
        ) AS StudentSchoolDemographicBridgeKey,
		CONCAT(
            CAST(Student.StudentUniqueId AS VARCHAR),
            '-', 
            CAST(School.LocalEducationAgencyId AS VARCHAR)
        ) AS StudentLocalEducationAgencyKey,
        CONCAT(
            'Race:',
            RaceType.CodeValue
        ) AS DemographicKey,
        StudentSchoolAssociation.ExitWithdrawDate
	FROM
        edfi.RaceType    
	INNER JOIN 
		edfi.StudentRace
		    ON RaceType.RaceTypeId = StudentRace.RaceTypeId
	INNER JOIN 
		edfi.Student
		    ON StudentRace.StudentUSI = Student.StudentUSI
	INNER JOIN 
		edfi.StudentSchoolAssociation
		    ON Student.StudentUSI = StudentSchoolAssociation.StudentUSI
	INNER JOIN 
		edfi.School
		    ON StudentSchoolAssociation.SchoolId = School.SchoolId
            
    UNION ALL
    
    SELECT
		CONCAT(
            'StudentCharacteristic:',
            Descriptor.CodeValue,
            '-', 
            Student.StudentUniqueId,
            '-', 
            School.LocalEducationAgencyId
        ) AS StudentSchoolDemographicBridgeKey,
		CONCAT(
            CAST(Student.StudentUniqueId AS VARCHAR),
            '-', 
            CAST(School.LocalEducationAgencyId AS VARCHAR)
        ) AS StudentLocalEducationAgencyKey,
        CONCAT(
            'StudentCharacteristic:',
            Descriptor.CodeValue
        ) AS DemographicKey,
        StudentSchoolAssociation.ExitWithdrawDate
	FROM
        edfi.Descriptor
	INNER JOIN 
		edfi.StudentCharacteristic
		    ON StudentCharacteristic.StudentCharacteristicDescriptorId = Descriptor.DescriptorId
    INNER JOIN
        edfi.Student
            ON StudentCharacteristic.StudentUSI = Student.StudentUSI
    INNER JOIN
        edfi.StudentSchoolAssociation
            ON Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN
        edfi.School
            ON StudentSchoolAssociation.SchoolId = School.SchoolId
    WHERE StudentCharacteristic.EndDate IS NULL OR StudentCharacteristic.EndDate > GETDATE()
            
    UNION ALL
    
    SELECT
		CONCAT(
            'StudentCharacteristic:Economic Disadvantaged-',
            Student.StudentUniqueId,
            '-', 
            School.LocalEducationAgencyId
        ) AS StudentSchoolDemographicBridgeKey,
		CONCAT(
            CAST(Student.StudentUniqueId AS VARCHAR),
            '-', 
            CAST(School.LocalEducationAgencyId AS VARCHAR)
        ) AS StudentLocalEducationAgencyKey,
        'StudentCharacteristic:Economic Disadvantaged' AS DemographicKey,
        StudentSchoolAssociation.ExitWithdrawDate
	FROM
        edfi.Student
	INNER JOIN
		edfi.StudentSchoolAssociation
		ON edfi.Student.StudentUSI = edfi.StudentSchoolAssociation.StudentUSI
	INNER JOIN
		edfi.School
		ON edfi.StudentSchoolAssociation.SchoolId = edfi.School.SchoolId
    WHERE Student.EconomicDisadvantaged = 1)
    SELECT StudentSchoolDemographicBridgeKey,StudentLocalEducationAgencyKey,DemographicKey
    FROM StudentLocalEducationAgencyDemographics
    WHERE ExitWithdrawDate IS NULL OR ExitWithdrawDate > GETDATE();
   
