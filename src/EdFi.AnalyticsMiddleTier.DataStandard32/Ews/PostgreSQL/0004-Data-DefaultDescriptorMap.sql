-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

WITH present as (
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
			edfi.AttendanceEventCategoryDescriptor ON
				Descriptor.DescriptorId = AttendanceEventCategoryDescriptor.AttendanceEventCategoryDescriptorId
		WHERE
			Descriptor.CodeValue = 'In Attendance'
	) as d
	WHERE DescriptorConstant.ConstantName = 'AttendanceEvent.Present'
), excusedAbsence as (
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
			edfi.AttendanceEventCategoryDescriptor ON
				Descriptor.DescriptorId = AttendanceEventCategoryDescriptor.AttendanceEventCategoryDescriptorId
		WHERE
			Descriptor.CodeValue = 'Excused Absence'
	) as d
	WHERE DescriptorConstant.ConstantName = 'AttendanceEvent.ExcusedAbsence'
), unexcusedAbsence as (
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
			edfi.AttendanceEventCategoryDescriptor ON
				Descriptor.DescriptorId = AttendanceEventCategoryDescriptor.AttendanceEventCategoryDescriptorId
		WHERE
			Descriptor.CodeValue = 'Unexcused Absence'
	) as d
	WHERE DescriptorConstant.ConstantName = 'AttendanceEvent.UnexcusedAbsence'
), tardy as (
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
			edfi.AttendanceEventCategoryDescriptor ON
				Descriptor.DescriptorId = AttendanceEventCategoryDescriptor.AttendanceEventCategoryDescriptorId
		WHERE
			Descriptor.CodeValue = 'Tardy'
	) as d
	WHERE DescriptorConstant.ConstantName = 'AttendanceEvent.Tardy'
), instructionalDay as (
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
			edfi.CalendarEventDescriptor ON
				Descriptor.DescriptorId = CalendarEventDescriptor.CalendarEventDescriptorId
		WHERE
			Descriptor.CodeValue IN ('Instructional Day', 'Instructional day', 'Make-up Day', 'Make-up day')
	) as d
	WHERE DescriptorConstant.ConstantName = 'CalendarEvent.InstructionalDay'
), stateOffenses as (
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
			edfi.BehaviorDescriptor ON
				Descriptor.DescriptorId = BehaviorDescriptor.BehaviorDescriptorId
		WHERE
			Descriptor.CodeValue = 'State Offense'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Behavior.StateOffense'
), schoolOffenses as (
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
			edfi.BehaviorDescriptor ON
				Descriptor.DescriptorId = BehaviorDescriptor.BehaviorDescriptorId
		WHERE
			Descriptor.CodeValue IN ('School Code of Conduct')
	) as d
	WHERE DescriptorConstant.ConstantName = 'Behavior.SchoolCodeOfConductOffense'
), gradingPeriod as (
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
			Descriptor.CodeValue = 'Grading Period'
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
SELECT DescriptorConstantId, DescriptorId, now() FROM present
UNION ALL
SELECT DescriptorConstantId, DescriptorId, now() FROM excusedAbsence
UNION ALL
SELECT DescriptorConstantId, DescriptorId, now() FROM unexcusedAbsence
UNION ALL
SELECT DescriptorConstantId, DescriptorId, now() FROM tardy
UNION ALL
SELECT DescriptorConstantId, DescriptorId, now() FROM instructionalDay
UNION ALL
SELECT DescriptorConstantId, DescriptorId, now() FROM stateOffenses
UNION ALL
SELECT DescriptorConstantId, DescriptorId, now() FROM schoolOffenses
UNION ALL
SELECT DescriptorConstantId, DescriptorId, now() FROM gradingPeriod
ON CONFLICT DO NOTHING
