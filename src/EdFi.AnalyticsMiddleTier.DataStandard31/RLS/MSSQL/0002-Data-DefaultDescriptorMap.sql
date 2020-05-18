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
MERGE INTO analytics_config.DescriptorMap AS Target
USING (
	SELECT * FROM district
	UNION ALL
	SELECT * FROM school
	UNION ALL
	SELECT * FROM section
) AS Source(DescriptorConstantId, DescriptorId)
ON TARGET.DescriptorConstantId = Source.DescriptorConstantId
    WHEN NOT MATCHED BY TARGET
    THEN
      INSERT
	  (
		DescriptorConstantId, 
		DescriptorId, 
		CreateDate
	  )
      VALUES
      (
        Source.DescriptorConstantId,
        Source.DescriptorId,
        getdate()
      )
OUTPUT $action,
       inserted.*;
