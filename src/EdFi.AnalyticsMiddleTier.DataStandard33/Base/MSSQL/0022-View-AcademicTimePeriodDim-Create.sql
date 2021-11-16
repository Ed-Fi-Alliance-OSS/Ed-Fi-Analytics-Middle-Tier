-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'AcademicTimePeriodDim')
BEGIN
    DROP VIEW analytics.AcademicTimePeriodDim
END
GO

CREATE VIEW analytics.AcademicTimePeriodDim
AS
     SELECT
		FORMATMESSAGE(
			'%s-%s-%s-%s-%s',
			CAST(Session.SchoolId as VARCHAR),
			CAST(Session.SchoolYear as VARCHAR),
			CAST(Session.TermDescriptorId as VARCHAR),
			CAST(GradingPeriod.GradingPeriodDescriptorId as VARCHAR),
			CONVERT(VARCHAR, GradingPeriod.BeginDate, 112)
		) as AcademicTimePeriodKey,
		CAST(SchoolYearType.SchoolYear as VARCHAR) as SchoolYear,
		SchoolYearType.SchoolYearDescription as SchoolYearName,
		SchoolYearType.CurrentSchoolYear as IsCurrentSchoolYear,
		CAST(Session.SchoolId as VARCHAR) as SchoolKey,
		FORMATMESSAGE(
			'%s-%s-%s',
			CAST(Session.SchoolId as VARCHAR),
			CAST(Session.SchoolYear as VARCHAR),
			CAST(Session.SessionName as VARCHAR)
		) as SessionKey,
		Session.SessionName,
		Descriptor.Description as TermName,
		FORMATMESSAGE(
			'%s-%s-%s',
			CAST(GradingPeriod.GradingPeriodDescriptorId as VARCHAR),
			CAST(GradingPeriod.SchoolId as VARCHAR),
			CONVERT(VARCHAR, GradingPeriod.BeginDate, 112)
		) as GradingPeriodKey,
		gpDescriptor.Description as GradingPeriodName,
		(
			SELECT MAX(MaxLastModifiedDate)
			FROM (
				VALUES
					(SchoolYearType.LastModifiedDate),
					(Session.LastModifiedDate),
					(GradingPeriod.LastModifiedDate)
			) as VALUE(MaxLastModifiedDate)
		) as LastModifiedDate
	FROM
		edfi.SchoolYearType
	INNER JOIN
		edfi.Session
	ON
		SchoolYearType.SchoolYear = Session.SchoolYear
	INNER JOIN
		edfi.Descriptor
	ON
		Session.TermDescriptorId = Descriptor.DescriptorId
	INNER JOIN
		edfi.SessionGradingPeriod
	ON
		Session.SchoolYear = SessionGradingPeriod.SchoolYear
	AND
		Session.SessionName = SessionGradingPeriod.SessionName
	AND
		Session.SchoolId = SessionGradingPeriod.SchoolId
	INNER JOIN
		edfi.GradingPeriod
	ON
		SessionGradingPeriod.GradingPeriodDescriptorId = GradingPeriod.GradingPeriodDescriptorId
	AND
		SessionGradingPeriod.PeriodSequence = GradingPeriod.PeriodSequence
	AND
		SessionGradingPeriod.SchoolId = GradingPeriod.SchoolId
	AND
		Session.SchoolYear = GradingPeriod.SchoolYear
	INNER JOIN
		edfi.Descriptor as gpDescriptor
	ON
		GradingPeriod.GradingPeriodDescriptorId = gpDescriptor.DescriptorId

GO