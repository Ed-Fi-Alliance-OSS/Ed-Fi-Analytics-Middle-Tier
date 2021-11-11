-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

WITH UpcomingSubmission as (
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
			Descriptor.CodeValue in ('Upcoming', 'CREATED', 'NEW', 'RECLAIMED_BY_STUDENT')
	) as d
	WHERE DescriptorConstant.ConstantName = 'SubmissionStatus.Upcoming'
)
MERGE INTO analytics_config.DescriptorMap AS Target
USING (
	SELECT * FROM UpcomingSubmission
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
