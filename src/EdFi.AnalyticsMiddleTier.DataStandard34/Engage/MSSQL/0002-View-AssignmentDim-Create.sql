-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW analytics.engage_AssignmentDim AS

    SELECT
        Assignment.AssignmentIdentifier as AssignmentKey,
        Assignment.SchoolId as SchoolKey,
        Descriptor.ShortDescription as SourceSystem,
        Assignment.Title as Title,
        Assignment.AssignmentDescription as Description,
        CONVERT(VARCHAR, Assignment.StartDateTime, 112) as StartDateKey,
        CONVERT(VARCHAR, Assignment.EndDateTime, 112) as EndDateKey,
        CONVERT(VARCHAR, Assignment.DueDateTime, 112) as DueDateKey,
        Assignment.MaxPoints as MaxPoints,
        FORMATMESSAGE(
            '%s-%s-%s-%s-%s',
            CAST(Assignment.SchoolId AS NVARCHAR)
            ,Assignment.LocalCourseCode
            ,CAST(Assignment.SchoolYear AS NVARCHAR)
            ,Assignment.SectionIdentifier
            ,Assignment.SessionName
		) as SectionKey,
        FORMATMESSAGE(
			'%s-%s-%s',
			CAST(GradingPeriod.GradingPeriodDescriptorId as VARCHAR),
			CAST(GradingPeriod.SchoolId as VARCHAR),
			CONVERT(VARCHAR, GradingPeriod.BeginDate, 112)
		) as GradingPeriodKey,
        Assignment.LastModifiedDate
    FROM
        lmsx.Assignment

    INNER JOIN
        analytics_config.DescriptorMap
    ON
		Assignment.AssignmentCategoryDescriptorId = DescriptorMap.DescriptorId

	INNER JOIN
		analytics_config.DescriptorConstant
	ON
		DescriptorMap.DescriptorConstantId = DescriptorConstant.DescriptorConstantId

	CROSS APPLY (
		SELECT
			TOP(1)
			GradingPeriod.GradingPeriodDescriptorId,
			GradingPeriod.SchoolId,
			GradingPeriod.BeginDate
		FROM
			edfi.SessionGradingPeriod
		INNER JOIN
			edfi.GradingPeriod
		ON
			SessionGradingPeriod.GradingPeriodDescriptorId = GradingPeriod.GradingPeriodDescriptorId
		AND
			SessionGradingPeriod.PeriodSequence = GradingPeriod.PeriodSequence
		AND
			SessionGradingPeriod.SchoolId = GradingPeriod.SchoolId
		AND
			SessionGradingPeriod.SchoolYear = GradingPeriod.SchoolYear
		WHERE
			Assignment.SessionName = SessionGradingPeriod.SessionName
		AND
			Assignment.SchoolYear = SessionGradingPeriod.SchoolYear
		AND
			Assignment.SchoolId = SessionGradingPeriod.SchoolId
		AND
			Assignment.DueDateTime BETWEEN GradingPeriod.BeginDate AND GradingPeriod.EndDate
		ORDER BY
			GradingPeriod.PeriodSequence
	) AS GradingPeriod

	INNER JOIN
		edfi.Descriptor
	ON
		Assignment.LMSSourceSystemDescriptorId = Descriptor.DescriptorId

	WHERE
		DescriptorConstant.ConstantName = 'AssignmentCategory.Assignment';
