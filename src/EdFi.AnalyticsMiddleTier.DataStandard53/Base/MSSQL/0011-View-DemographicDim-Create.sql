﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS
(
    SELECT 1
    FROM INFORMATION_SCHEMA.VIEWS
    WHERE TABLE_SCHEMA = 'analytics'
          AND TABLE_NAME = 'DemographicDim'
)
    BEGIN
        DROP VIEW analytics.DemographicDim;
END;
GO

CREATE VIEW analytics.DemographicDim
AS
    SELECT
		CONCAT('CohortYear:', SchoolYearType.SchoolYear, '-', Descriptor.CodeValue) AS DemographicKey,
		'CohortYear' AS DemographicParentKey,
		CONCAT(SchoolYearType.SchoolYear, '-', Descriptor.CodeValue) AS DemographicLabel
	FROM
		edfi.SchoolYearType
	CROSS JOIN
		edfi.CohortYearTypeDescriptor
	INNER JOIN
		edfi.Descriptor ON
			CohortYearTypeDescriptor.CohortYearTypeDescriptorId = Descriptor.DescriptorId

	UNION ALL

	SELECT
		CONCAT('DisabilityDesignation:', Descriptor.CodeValue) AS DemographicKey,
		'DisabilityDesignation' AS DemographicParentKey,
		Descriptor.CodeValue AS DemographicLabel
	FROM 
		edfi.DisabilityDesignationDescriptor
	INNER JOIN
		edfi.Descriptor ON
			DisabilityDesignationDescriptor.DisabilityDesignationDescriptorId = Descriptor.DescriptorId

	UNION ALL

	SELECT
		CONCAT('Language:', Descriptor.CodeValue) AS DemographicKey,
		'Language' AS DemographicParentKey,
		Descriptor.CodeValue AS DemographicLabel
	FROM 
		edfi.LanguageDescriptor
	INNER JOIN
		edfi.Descriptor ON
			LanguageDescriptor.LanguageDescriptorId = Descriptor.DescriptorId

	UNION ALL

	SELECT
		CONCAT('LanguageUse:', Descriptor.CodeValue) AS DemographicKey,
		'LanguageUse' AS DemographicParentKey,
		Descriptor.CodeValue AS DemographicLabel
	FROM 
		edfi.LanguageUseDescriptor
	INNER JOIN
		edfi.Descriptor ON
			LanguageUseDescriptor.LanguageUseDescriptorId = Descriptor.DescriptorId

	UNION ALL

	SELECT
		CONCAT('Race:', Descriptor.CodeValue) AS DemographicKey,
		'Race' AS DemographicParentKey,
		Descriptor.CodeValue AS DemographicLabel
	FROM 
		edfi.RaceDescriptor
	INNER JOIN
		edfi.Descriptor ON
			RaceDescriptor.RaceDescriptorId = Descriptor.DescriptorId

	UNION ALL

	SELECT
		CONCAT('TribalAffiliation:', Descriptor.CodeValue) AS DemographicKey,
		'TribalAffiliation' AS DemographicParentKey,
		Descriptor.CodeValue AS DemographicLabel
	FROM 
		edfi.TribalAffiliationDescriptor
	INNER JOIN
		edfi.Descriptor ON
			TribalAffiliationDescriptor.TribalAffiliationDescriptorId = Descriptor.DescriptorId

	UNION ALL

	SELECT
		CONCAT('StudentCharacteristic:', Descriptor.CodeValue) AS DemographicKey,
		'StudentCharacteristic' AS DemographicParentKey,
		Descriptor.CodeValue AS DemographicLabel
	FROM 
		edfi.StudentCharacteristicDescriptor
	INNER JOIN
		edfi.Descriptor ON
			StudentCharacteristicDescriptor.StudentCharacteristicDescriptorId = Descriptor.DescriptorId
			
	UNION ALL
	
	SELECT
		CONCAT('Disability:', Descriptor.CodeValue) AS DemographicKey,
		'Disability' AS DemographicParentKey,
		Descriptor.CodeValue AS DemographicLabel
	FROM 
		edfi.DisabilityDescriptor
	INNER JOIN
		edfi.Descriptor ON
			DisabilityDescriptor.DisabilityDescriptorId = Descriptor.DescriptorId
			
GO