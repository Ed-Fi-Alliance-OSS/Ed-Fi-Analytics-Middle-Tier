-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

WITH gradingTypeSemester as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			DescriptorId
		FROM
			edfi.GradeTypeDescriptor
		INNER JOIN
			edfi.Descriptor
		ON
			GradeTypeDescriptor.GradeTypeDescriptorId = Descriptor.DescriptorId
		 WHERE
            Descriptor.CodeValue = 'Semester'
            AND Namespace LIKE '%/GradeTypeDescriptor'
	) as d
	WHERE DescriptorConstant.ConstantName = 'GradeType.Semester'
), gradingTypeFinal as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			DescriptorId
		FROM
			edfi.GradeTypeDescriptor
		INNER JOIN
			edfi.Descriptor
		ON
			GradeTypeDescriptor.GradeTypeDescriptorId = Descriptor.DescriptorId
		WHERE
            Descriptor.CodeValue = 'Final'
            AND Namespace LIKE '%/GradeTypeDescriptor'
	) as d
	WHERE DescriptorConstant.ConstantName = 'GradeType.GradingPeriod'
)
INSERT INTO
    analytics_config.descriptormap
    (
		DescriptorConstantId, 
		DescriptorId, 
		CreateDate
    )
SELECT DescriptorConstantId, DescriptorId, now() FROM gradingTypeSemester
UNION ALL
SELECT DescriptorConstantId, DescriptorId, now() FROM gradingTypeFinal
ON CONFLICT DO NOTHING
