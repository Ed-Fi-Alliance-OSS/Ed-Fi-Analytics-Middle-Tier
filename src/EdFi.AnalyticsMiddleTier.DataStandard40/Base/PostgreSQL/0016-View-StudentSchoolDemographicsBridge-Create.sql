-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW analytics.StudentSchoolDemographicsBridge AS
WITH StudentSchoolDemographics AS (
	SELECT
        CONCAT('CohortYear:', SchoolYearType.SchoolYear, '-', Descriptor.CodeValue
			,'-', Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS ​StudentSchoolDemographicBridgeKey,
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        CONCAT('CohortYear:', SchoolYearType.SchoolYear, '-', Descriptor.CodeValue) AS DemographicKey,
		StudentSchoolAssociation.ExitWithdrawDate
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
        edfi.School ON
            StudentEducationOrganizationAssociationCohortYear.EducationOrganizationId = School.SchoolId
    INNER JOIN
         edfi.StudentEducationOrganizationAssociation ON
            StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationCohortYear.StudentUSI
           AND StudentEducationOrganizationAssociation.EducationOrganizationId =StudentEducationOrganizationAssociationCohortYear.EducationOrganizationId
    INNER JOIN
		 edfi.StudentSchoolAssociation ON
			StudentSchoolAssociation.StudentUSI = StudentEducationOrganizationAssociation.StudentUSI
			AND School.SchoolId = StudentSchoolAssociation.SchoolId
	INNER JOIN
		edfi.Student ON
			Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
    UNION ALL
    SELECT
        CONCAT('Disability:', Descriptor.CodeValue,
			'-', Student.StudentUniqueId, '-',StudentSchoolAssociation.SchoolId) AS ​StudentSchoolDemographicBridgeKey,
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        CONCAT('Disability:', Descriptor.CodeValue) AS DemographicKey,
		StudentSchoolAssociation.ExitWithdrawDate
     FROM
        edfi.StudentEducationOrganizationAssociationDisability
    INNER JOIN
        edfi.Descriptor ON
            StudentEducationOrganizationAssociationDisability.DisabilityDescriptorId = Descriptor.DescriptorId
    INNER JOIN
        edfi.School ON
            StudentEducationOrganizationAssociationDisability.EducationOrganizationId = School.SchoolId
    INNER JOIN
         edfi.StudentEducationOrganizationAssociation ON
            StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationDisability.StudentUSI
           AND StudentEducationOrganizationAssociation.EducationOrganizationId =StudentEducationOrganizationAssociationDisability.EducationOrganizationId
    INNER JOIN
		 edfi.StudentSchoolAssociation ON
			StudentSchoolAssociation.StudentUSI = StudentEducationOrganizationAssociation.StudentUSI
			AND School.SchoolId = StudentSchoolAssociation.SchoolId
	INNER JOIN
		edfi.Student ON
			Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
    UNION ALL
    SELECT
        CONCAT('DisabilityDesignation:', Descriptor.CodeValue,
			'-', Student.StudentUniqueId, '-',StudentSchoolAssociation.SchoolId) AS ​StudentSchoolDemographicBridgeKey,
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        CONCAT('DisabilityDesignation:', Descriptor.CodeValue) AS DemographicKey,
		StudentSchoolAssociation.ExitWithdrawDate
     FROM
        edfi.StudentEducationOrganizationAssociationDisabilityDesignation
    INNER JOIN
        edfi.Descriptor ON
            StudentEducationOrganizationAssociationDisabilityDesignation.DisabilityDesignationDescriptorId = Descriptor.DescriptorId
    INNER JOIN
        edfi.School ON
            StudentEducationOrganizationAssociationDisabilityDesignation.EducationOrganizationId = School.SchoolId
    INNER JOIN
         edfi.StudentEducationOrganizationAssociation ON
           StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationDisabilityDesignation.StudentUSI
           AND StudentEducationOrganizationAssociation.EducationOrganizationId =StudentEducationOrganizationAssociationDisabilityDesignation.EducationOrganizationId
    INNER JOIN
		 edfi.StudentSchoolAssociation ON
			StudentSchoolAssociation.StudentUSI = StudentEducationOrganizationAssociation.StudentUSI
			AND School.SchoolId = StudentSchoolAssociation.SchoolId
	INNER JOIN
		edfi.Student ON
			Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
    UNION ALL
    SELECT
        CONCAT('Language:', Descriptor.CodeValue,
			'-', Student.StudentUniqueId, '-',StudentSchoolAssociation.SchoolId) AS ​StudentSchoolDemographicBridgeKey,
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        CONCAT('Language:', Descriptor.CodeValue) AS DemographicKey,
		StudentSchoolAssociation.ExitWithdrawDate
     FROM
        edfi.StudentEducationOrganizationAssociationLanguage
    INNER JOIN
        edfi.Descriptor ON
            StudentEducationOrganizationAssociationLanguage.LanguageDescriptorId = Descriptor.DescriptorId
    INNER JOIN
        edfi.School ON
            StudentEducationOrganizationAssociationLanguage.EducationOrganizationId = School.SchoolId
    INNER JOIN
         edfi.StudentEducationOrganizationAssociation ON
           StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationLanguage.StudentUSI
           AND StudentEducationOrganizationAssociation.EducationOrganizationId =StudentEducationOrganizationAssociationLanguage.EducationOrganizationId
    INNER JOIN
		 edfi.StudentSchoolAssociation ON
			StudentSchoolAssociation.StudentUSI = StudentEducationOrganizationAssociation.StudentUSI
			AND School.SchoolId = StudentSchoolAssociation.SchoolId
	INNER JOIN
		edfi.Student ON
			Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
    UNION ALL
    SELECT
        CONCAT('LanguageUse:', Descriptor.CodeValue,
			'-', Student.StudentUniqueId, '-',StudentSchoolAssociation.SchoolId) AS ​StudentSchoolDemographicBridgeKey,
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        CONCAT('LanguageUse:', Descriptor.CodeValue) AS DemographicKey,
		StudentSchoolAssociation.ExitWithdrawDate
    FROM
        edfi.StudentEducationOrganizationAssociationLanguageUse
    INNER JOIN
        edfi.Descriptor ON
            StudentEducationOrganizationAssociationLanguageUse.LanguageUseDescriptorId = Descriptor.DescriptorId
    INNER JOIN
        edfi.School ON
            StudentEducationOrganizationAssociationLanguageUse.EducationOrganizationId = School.SchoolId
    INNER JOIN
         edfi.StudentEducationOrganizationAssociation ON
           StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationLanguageUse.StudentUSI
           AND StudentEducationOrganizationAssociation.EducationOrganizationId =StudentEducationOrganizationAssociationLanguageUse.EducationOrganizationId
    INNER JOIN
		 edfi.StudentSchoolAssociation ON
			StudentSchoolAssociation.StudentUSI = StudentEducationOrganizationAssociation.StudentUSI
			AND School.SchoolId = StudentSchoolAssociation.SchoolId
	INNER JOIN
		edfi.Student ON
			Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
    UNION ALL
    SELECT
        CONCAT('Race:', Descriptor.CodeValue,
			'-', Student.StudentUniqueId, '-',StudentSchoolAssociation.SchoolId) AS ​StudentSchoolDemographicBridgeKey,
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        CONCAT('Race:', Descriptor.CodeValue) AS DemographicKey,
		StudentSchoolAssociation.ExitWithdrawDate
    FROM
        edfi.StudentEducationOrganizationAssociationRace
    INNER JOIN
        edfi.Descriptor ON
            StudentEducationOrganizationAssociationRace.RaceDescriptorId = Descriptor.DescriptorId
    INNER JOIN
        edfi.School ON
            StudentEducationOrganizationAssociationRace.EducationOrganizationId = School.SchoolId
    INNER JOIN
         edfi.StudentEducationOrganizationAssociation ON
           StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationRace.StudentUSI
           AND StudentEducationOrganizationAssociation.EducationOrganizationId =StudentEducationOrganizationAssociationRace.EducationOrganizationId
    INNER JOIN
		 edfi.StudentSchoolAssociation ON
			StudentSchoolAssociation.StudentUSI = StudentEducationOrganizationAssociation.StudentUSI
			AND School.SchoolId = StudentSchoolAssociation.SchoolId
	INNER JOIN
		edfi.Student ON
			Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
    UNION ALL
    SELECT
        CONCAT('TribalAffiliation:', Descriptor.CodeValue,
			'-', Student.StudentUniqueId, '-',StudentSchoolAssociation.SchoolId) AS ​StudentSchoolDemographicBridgeKey,
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        CONCAT('TribalAffiliation:', Descriptor.CodeValue) AS DemographicKey,
		StudentSchoolAssociation.ExitWithdrawDate
    FROM
        edfi.StudentEducationOrganizationAssociationTribalAffiliation
    INNER JOIN
        edfi.Descriptor ON
            StudentEducationOrganizationAssociationTribalAffiliation.TribalAffiliationDescriptorId = Descriptor.DescriptorId
    INNER JOIN
        edfi.School ON
            StudentEducationOrganizationAssociationTribalAffiliation.EducationOrganizationId = School.SchoolId
    INNER JOIN
         edfi.StudentEducationOrganizationAssociation ON
           StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationTribalAffiliation.StudentUSI
           AND StudentEducationOrganizationAssociation.EducationOrganizationId =StudentEducationOrganizationAssociationTribalAffiliation.EducationOrganizationId
    INNER JOIN
		 edfi.StudentSchoolAssociation ON
			StudentSchoolAssociation.StudentUSI = StudentEducationOrganizationAssociation.StudentUSI
			AND School.SchoolId = StudentSchoolAssociation.SchoolId
	INNER JOIN
		edfi.Student ON
			Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
    UNION ALL
    SELECT
        CONCAT('StudentCharacteristic:', Descriptor.CodeValue,
			'-', Student.StudentUniqueId, '-',StudentSchoolAssociation.SchoolId) AS ​StudentSchoolDemographicBridgeKey,
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
        CONCAT('StudentCharacteristic:', Descriptor.CodeValue) AS DemographicKey,
		StudentSchoolAssociation.ExitWithdrawDate
    FROM
        edfi.StudentEducationOrganizationAssociationStudentCharacteristic
    INNER JOIN
        edfi.Descriptor ON
            StudentEducationOrganizationAssociationStudentCharacteristic.StudentCharacteristicDescriptorId = Descriptor.DescriptorId
    INNER JOIN
        edfi.School ON
            StudentEducationOrganizationAssociationStudentCharacteristic.EducationOrganizationId = School.SchoolId
    INNER JOIN
         edfi.StudentEducationOrganizationAssociation ON
           StudentEducationOrganizationAssociation.StudentUSI = StudentEducationOrganizationAssociationStudentCharacteristic.StudentUSI
           AND StudentEducationOrganizationAssociation.EducationOrganizationId =StudentEducationOrganizationAssociationStudentCharacteristic.EducationOrganizationId
    INNER JOIN
		 edfi.StudentSchoolAssociation ON
			StudentSchoolAssociation.StudentUSI = StudentEducationOrganizationAssociation.StudentUSI
			AND School.SchoolId = StudentSchoolAssociation.SchoolId
	INNER JOIN
		edfi.Student ON
			Student.StudentUsi = StudentEducationOrganizationAssociation.StudentUSI
    LEFT JOIN edfi.studenteducationorganizationassociationstudentcharacteri_a18fcf ON
            studenteducationorganizationassociationstudentcharacteri_a18fcf.EducationOrganizationID=StudentEducationOrganizationAssociationStudentCharacteristic.EducationOrganizationID
            AND studenteducationorganizationassociationstudentcharacteri_a18fcf.StudentUSI=StudentEducationOrganizationAssociationStudentCharacteristic.StudentUSI
            AND studenteducationorganizationassociationstudentcharacteri_a18fcf.StudentCharacteristicDescriptorId=StudentEducationOrganizationAssociationStudentCharacteristic.StudentCharacteristicDescriptorId
    WHERE  studenteducationorganizationassociationstudentcharacteri_a18fcf.EndDate IS NULL OR studenteducationorganizationassociationstudentcharacteri_a18fcf.EndDate > NOW()
    )
	SELECT  
		​StudentSchoolDemographicBridgeKey as StudentSchoolDemographicBridgeKey,
		StudentSchoolKey,
		DemographicKey
	FROM StudentSchoolDemographics
	WHERE ExitWithdrawDate IS NULL OR ExitWithdrawDate > NOW();

