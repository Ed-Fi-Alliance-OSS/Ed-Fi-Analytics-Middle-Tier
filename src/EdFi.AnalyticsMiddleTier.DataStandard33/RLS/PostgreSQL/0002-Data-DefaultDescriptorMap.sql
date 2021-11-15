-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

WITH district as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			Descriptor.DescriptorId
		FROM
			edfi.Descriptor
		INNER JOIN
			edfi.StaffClassificationDescriptor ON
				Descriptor.DescriptorId = StaffClassificationDescriptor.StaffClassificationDescriptorId
		WHERE
			Descriptor.CodeValue = 'Superintendent'
	) as d
	WHERE DescriptorConstant.ConstantName = 'AuthorizationScope.District'
), school as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			Descriptor.DescriptorId
		FROM
			edfi.Descriptor
		INNER JOIN
			edfi.StaffClassificationDescriptor ON
				Descriptor.DescriptorId = StaffClassificationDescriptor.StaffClassificationDescriptorId
		WHERE
			Descriptor.CodeValue = 'Principal'
	) as d
	WHERE DescriptorConstant.ConstantName = 'AuthorizationScope.School'
), section as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			Descriptor.DescriptorId
		FROM
			edfi.Descriptor
		INNER JOIN
			edfi.StaffClassificationDescriptor ON
				Descriptor.DescriptorId = StaffClassificationDescriptor.StaffClassificationDescriptorId
		WHERE
			Descriptor.CodeValue = 'Teacher'
	) as d
	WHERE DescriptorConstant.ConstantName = 'AuthorizationScope.Section'
)
INSERT INTO
    analytics_config.descriptormap
    (
		DescriptorConstantId, 
		DescriptorId, 
		CreateDate
    )
SELECT DescriptorConstantId, DescriptorId, now() FROM district
UNION ALL
SELECT DescriptorConstantId, DescriptorId, now() FROM school
UNION ALL
SELECT DescriptorConstantId, DescriptorId, now() FROM section
ON CONFLICT DO NOTHING
