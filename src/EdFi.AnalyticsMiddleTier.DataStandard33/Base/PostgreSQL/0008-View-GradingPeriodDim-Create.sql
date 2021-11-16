-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE VIEW analytics.GradingPeriodDim
AS
	SELECT
		CAST(GradingPeriod.GradingPeriodDescriptorId as VARCHAR)
			|| '-' || CAST(GradingPeriod.SchoolId as VARCHAR)
			|| '-' || to_char(GradingPeriod.BeginDate, 'yyyymmdd') as GradingPeriodKey,
		to_char(GradingPeriod.BeginDate, 'yyyymmdd') as GradingPeriodBeginDateKey,
		to_char(GradingPeriod.EndDate, 'yyyymmdd') as GradingPeriodEndDateKey,
		GradingPeriodDescriptor.CodeValue as GradingPeriodDescription,
		GradingPeriod.TotalInstructionalDays,
		GradingPeriod.PeriodSequence,
		CAST(GradingPeriod.SchoolId AS VARCHAR) as SchoolKey,
		CAST(GradingPeriod.SchoolYear AS VARCHAR) as SchoolYear,
		GradingPeriod.LastModifiedDate
	FROM
		edfi.GradingPeriod
	INNER JOIN
		edfi.Descriptor as GradingPeriodDescriptor ON
			GradingPeriod.GradingPeriodDescriptorId = GradingPeriodDescriptor.DescriptorId
	WHERE GradingPeriod.BeginDate < NOW();