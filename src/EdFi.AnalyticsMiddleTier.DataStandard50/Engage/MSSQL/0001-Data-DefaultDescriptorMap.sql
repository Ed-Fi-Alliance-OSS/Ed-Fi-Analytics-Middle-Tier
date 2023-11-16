-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

WITH assignment as (
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
			lmsx.AssignmentCategoryDescriptor ON
				Descriptor.DescriptorId = AssignmentCategoryDescriptor.AssignmentCategoryDescriptorId
		WHERE
			Descriptor.CodeValue = 'Assignment'
	) as d
	WHERE DescriptorConstant.ConstantName = 'AssignmentCategory.Assignment'
), ispastdue as (
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
			lmsx.SubmissionStatusDescriptor  ON
				Descriptor.DescriptorId = SubmissionStatusDescriptor.SubmissionStatusDescriptorId
		WHERE
			Descriptor.CodeValue = 'missing'
	) as d
	WHERE DescriptorConstant.ConstantName = 'SubmissionStatus.IsPastDue'
), submittedlate as (
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
			lmsx.SubmissionStatusDescriptor ON
				Descriptor.DescriptorId = SubmissionStatusDescriptor.SubmissionStatusDescriptorId
		WHERE
			Descriptor.CodeValue = 'late'
	) as d
	WHERE DescriptorConstant.ConstantName = 'SubmissionStatus.SubmittedLate'
), submittedontime as (
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
			lmsx.SubmissionStatusDescriptor ON
				Descriptor.DescriptorId = SubmissionStatusDescriptor.SubmissionStatusDescriptorId
		WHERE
			Descriptor.CodeValue in ('on-time', 'graded', 'RETURNED', 'TURNED_IN')
	) as d
	WHERE DescriptorConstant.ConstantName = 'SubmissionStatus.SubmittedOnTime'
)
MERGE INTO analytics_config.DescriptorMap AS Target
USING (
	SELECT * FROM assignment
	UNION ALL
	SELECT * FROM ispastdue
	UNION ALL
	SELECT * FROM submittedlate
	UNION ALL
	SELECT * FROM submittedontime
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
