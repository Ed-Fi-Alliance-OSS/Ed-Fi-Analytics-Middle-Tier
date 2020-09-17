-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE VIEW analytics.chrab_ChronicAbsenteeismAttendanceFact
AS
	WITH descriptorMap AS (
		SELECT
			Descriptor.DescriptorId,
			DescriptorConstant.ConstantName
		FROM
			edfi.Descriptor
		INNER JOIN
			analytics_config.DescriptorMap
		ON 
			Descriptor.DescriptorId = DescriptorMap.DescriptorId
		INNER JOIN
			analytics_config.DescriptorConstant
		ON
			DescriptorMap.DescriptorConstantId = DescriptorConstant.DescriptorConstantId
	)
    SELECT 
        CONCAT(Student.StudentUniqueId, '-', StudentSchoolAssociation.SchoolId) AS StudentSchoolKey,
		Student.StudentUniqueId AS StudentKey, 
        CAST(StudentSchoolAssociation.SchoolId AS VARCHAR) AS SchoolKey,
		to_char(CalendarDateCalendarEvent.Date, 'yyyymmdd') as DateKey,
        
        MAX(CASE
            WHEN
                StudentSchoolAttendanceEvent.Id IS NOT NULL
            AND
                schoolAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Present' THEN 1
            ELSE 0
        END) AS ReportedAsPresentAtSchool,
        MAX(CASE
            WHEN
                StudentSchoolAttendanceEvent.Id IS NOT NULL
            AND
                schoolAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Absence' THEN 1
            ELSE 0
        END) AS ReportedAsAbsentFromSchool,

        MAX(CASE
            WHEN
                StudentSectionAttendanceEvent.Id IS NOT NULL
            AND
                sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Present' 
            AND
                StudentSectionAssociation.HomeroomIndicator = TRUE THEN 1
            ELSE 0
        END) AS ReportedAsAbsentFromSchoolReportedAsPresentAtHomeRoom,
        MAX(CASE
            WHEN
                StudentSectionAttendanceEvent.Id IS NOT NULL
            AND
                sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Absence'
            AND 
                StudentSectionAssociation.HomeroomIndicator = TRUE THEN 1
            ELSE 0
        END) AS ReportedAsAbsentFromHomeRoom,

        CASE
            WHEN
                (MAX(CASE
                    WHEN
                        StudentSectionAttendanceEvent.Id IS NOT NULL
                    AND
                        sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Absence' THEN 1
                    ELSE 0
                END) = 0)
                    AND
                (MAX(CASE
                    WHEN
                        StudentSectionAttendanceEvent.Id IS NOT NULL
                    AND
                        sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Present' THEN 1
                    ELSE 0
                END) > 0)
            THEN 1
            ELSE 0 
        END as ReportedAsIsPresentInAllSections,
        MAX(CASE
            WHEN
                StudentSectionAttendanceEvent.Id IS NOT NULL
            AND
                sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Absence' THEN 1
            ELSE 0
        END) AS ReportedAsAbsentFromAnySection
    FROM
		edfi.StudentSchoolAssociation
    INNER JOIN
        edfi.Student
    ON 
		StudentSchoolAssociation.StudentUSI = Student.StudentUSI
    INNER JOIN
        edfi.CalendarDateCalendarEvent
    ON 
		CalendarDateCalendarEvent.SchoolId = StudentSchoolAssociation.SchoolId
    AND 
		StudentSchoolAssociation.EntryDate <= CalendarDateCalendarEvent.Date
    AND (
		StudentSchoolAssociation.ExitWithdrawDate IS NULL
    OR 
		StudentSchoolAssociation.ExitWithdrawDate >= CalendarDateCalendarEvent.Date
	)
    INNER JOIN
        descriptorMap as calendarDescriptorMap
    ON 
		CalendarDateCalendarEvent.CalendarEventDescriptorId = calendarDescriptorMap.DescriptorId

    -- School attendance
    LEFT OUTER JOIN
		edfi.StudentSchoolAttendanceEvent
    ON
		StudentSchoolAssociation.StudentUSI = StudentSchoolAttendanceEvent.StudentUSI
    AND
		StudentSchoolAssociation.SchoolId = StudentSchoolAttendanceEvent.SchoolId
    AND (
    -- StudentSchoolAssociation.SchoolYear is nullable in this table
		StudentSchoolAssociation.SchoolYear IS NULL
    OR 
		StudentSchoolAssociation.SchoolYear = StudentSchoolAttendanceEvent.SchoolYear
	)
    AND
		CalendarDateCalendarEvent.Date = StudentSchoolAttendanceEvent.EventDate
    LEFT OUTER JOIN
        descriptorMap as schoolAttendanceDescriptorMap
    ON
        StudentSchoolAttendanceEvent.AttendanceEventCategoryDescriptorId = schoolAttendanceDescriptorMap.DescriptorId

    -- Section Attendance
    LEFT OUTER JOIN
		edfi.StudentSectionAttendanceEvent
    ON
		CalendarDateCalendarEvent.Date = StudentSectionAttendanceEvent.EventDate
    AND
		StudentSchoolAssociation.StudentUSI = StudentSectionAttendanceEvent.StudentUSI
    AND
		StudentSchoolAssociation.SchoolId = StudentSectionAttendanceEvent.SchoolId
    AND (
	-- StudentSchoolAssociation.SchoolYear is nullable
		StudentSchoolAssociation.SchoolYear IS NULL
    OR
		StudentSchoolAssociation.SchoolYear = StudentSectionAttendanceEvent.SchoolYear
	)
    LEFT OUTER JOIN
        edfi.StudentSectionAssociation
    ON
		StudentSectionAttendanceEvent.StudentUSI = StudentSectionAssociation.StudentUSI
	AND
		StudentSectionAttendanceEvent.LocalCourseCode = StudentSectionAssociation.LocalCourseCode
	AND
		StudentSectionAttendanceEvent.SchoolId = StudentSectionAssociation.SchoolId
	AND
		StudentSectionAttendanceEvent.SchoolYear = StudentSectionAssociation.SchoolYear
	AND
		StudentSectionAttendanceEvent.SectionIdentifier = StudentSectionAssociation.SectionIdentifier
	AND
		StudentSectionAttendanceEvent.SessionName = StudentSectionAssociation.SessionName
    LEFT OUTER JOIN
        descriptorMap as sectionAttendanceDescriptorMap
    ON
	    StudentSectionAttendanceEvent.AttendanceEventCategoryDescriptorId = sectionAttendanceDescriptorMap.DescriptorId
	WHERE
        CalendarDateCalendarEvent.Date <= NOW()
    AND
        calendarDescriptorMap.ConstantName = 'CalendarEvent.InstructionalDay'
    GROUP BY
        Student.StudentUniqueId,
        StudentSchoolAssociation.SchoolId,
        CalendarDateCalendarEvent.Date;