-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

WITH gradingPeriodSemester as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.GradeTypeId,
		'GradeType' as TypeTable
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			GradeTypeId
		FROM
			edfi.GradeType
		WHERE
			CodeValue = 'Semester'
	) as d
	WHERE DescriptorConstant.ConstantName = 'GradeType.Semester'
),
gradingPeriodFinal as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.GradeTypeId,
		'GradeType' as TypeTable
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			GradeTypeId
		FROM
			edfi.GradeType
		WHERE
			CodeValue = 'Final'
	) as d
	WHERE DescriptorConstant.ConstantName = 'GradeType.Final'
)
MERGE INTO analytics_config.TypeMap AS Target
USING (
	SELECT * FROM gradingPeriodSemester
	UNION ALL
	SELECT * FROM gradingPeriodFinal
) AS Source(DescriptorConstantId, TypeId, TypeTable)
ON TARGET.DescriptorConstantId = Source.DescriptorConstantId
    WHEN NOT MATCHED BY TARGET
    THEN
      INSERT
	  (
		DescriptorConstantId, 
		TypeId,
		TypeTable,
		CreateDate
	  )
      VALUES
      (
        Source.DescriptorConstantId,
        Source.TypeId,
		Source.TypeTable,
        getdate()
      )
OUTPUT $action,
       inserted.*;
