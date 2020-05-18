-- SPDX-License-Identifier: Apache-2.0
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
		CONCAT('CohortYear:', StudentCohortYear.SchoolYear, '-', CohortYearType.CodeValue) AS DemographicKey,
		'CohortYear' AS DemographicParentKey,
		CONCAT(StudentCohortYear.SchoolYear, '-', CohortYearType.CodeValue) AS DemographicLabel
	FROM
		edfi.CohortYearType
	CROSS JOIN
		edfi.StudentCohortYear

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
		CONCAT('LanguageUse:', LanguageUseType.CodeValue) AS DemographicKey,
		'LanguageUse' AS DemographicParentKey,
		LanguageUseType.CodeValue AS DemographicLabel
	FROM 
		edfi.LanguageUseType

	UNION ALL
	
	SELECT
		CONCAT('Race:', RaceType.CodeValue) AS DemographicKey,
		'Race' AS DemographicParentKey,
		RaceType.CodeValue AS DemographicLabel
	FROM
		edfi.RaceType

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
		'StudentCharacteristic:Economic Disadvantaged' AS DemographicKey,
		'StudentCharacteristic' AS DemographicParentKey,
		'Economic Disadvantaged' AS DemographicLabel
			
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