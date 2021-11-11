-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'GradingPeriodDim')
BEGIN
	DROP VIEW analytics.GradingPeriodDim
END
GO

CREATE VIEW analytics.GradingPeriodDim AS

	SELECT
		CAST(GradingPeriod.GradingPeriodDescriptorId as NVARCHAR)
			+ '-' + CAST(GradingPeriod.SchoolId as NVARCHAR)
			+ '-' + CONVERT(NVARCHAR, GradingPeriod.BeginDate, 112) as GradingPeriodKey,
		CONVERT(NVARCHAR, GradingPeriod.BeginDate, 112) as GradingPeriodBeginDateKey,
		CONVERT(NVARCHAR, GradingPeriod.EndDate, 112) as GradingPeriodEndDateKey,
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
	WHERE GradingPeriod.BeginDate < GETDATE()