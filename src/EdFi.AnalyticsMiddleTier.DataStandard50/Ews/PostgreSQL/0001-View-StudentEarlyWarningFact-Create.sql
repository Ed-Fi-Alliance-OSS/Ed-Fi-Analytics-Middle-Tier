-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
CREATE VIEW analytics.ews_StudentEarlyWarningFact AS
    WITH descriptorMap AS (
            SELECT Descriptor.DescriptorId
                ,DescriptorConstant.ConstantName
            FROM edfi.Descriptor
            INNER JOIN analytics_config.DescriptorMap
                ON Descriptor.DescriptorId = DescriptorMap.DescriptorId
            INNER JOIN analytics_config.DescriptorConstant
                ON DescriptorMap.DescriptorConstantId = DescriptorConstant.DescriptorConstantId
            )

SELECT Student.StudentUniqueId AS StudentKey
    ,CAST(StudentSchoolAssociation.SchoolId AS VARCHAR) AS SchoolKey
    ,to_char(CalendarDateCalendarEvent.DATE, 'yyyymmdd') AS DateKey
    ,MAX(CASE 
            WHEN calendarDescriptorMap.ConstantName = 'CalendarEvent.InstructionalDay'
                THEN 1
            ELSE 0
            END) AS IsInstructionalDay
    ,1 AS IsEnrolled
    ,MAX(CASE 
            WHEN StudentSchoolAttendanceEvent.Id IS NOT NULL
                AND schoolAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Present'
                THEN 1
            ELSE 0
            END) AS IsPresentSchool
    ,MAX(CASE 
            WHEN StudentSchoolAttendanceEvent.Id IS NOT NULL
                AND schoolAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.ExcusedAbsence'
                THEN 1
            ELSE 0
            END) AS IsAbsentFromSchoolExcused
    ,MAX(CASE 
            WHEN StudentSchoolAttendanceEvent.Id IS NOT NULL
                AND schoolAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.UnexcusedAbsence'
                THEN 1
            ELSE 0
            END) AS IsAbsentFromSchoolUnexcused
    ,MAX(CASE 
            WHEN StudentSchoolAttendanceEvent.Id IS NOT NULL
                 AND schoolAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Tardy'
                THEN 1
            ELSE 0
            END) AS IsTardyToSchool
    ,MAX(CASE 
            WHEN StudentSectionAttendanceEvent.Id IS NOT NULL
                AND sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Present'
                AND StudentSectionAssociation.HomeroomIndicator = TRUE
                THEN 1
            ELSE 0
            END) AS IsPresentHomeroom
    ,MAX(CASE 
            WHEN StudentSectionAttendanceEvent.Id IS NOT NULL
                AND sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.ExcusedAbsence'
                AND StudentSectionAssociation.HomeroomIndicator = TRUE
                THEN 1
            ELSE 0
            END) AS IsAbsentFromHomeroomExcused
    ,MAX(CASE 
            WHEN StudentSectionAttendanceEvent.Id IS NOT NULL
                AND sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.UnexcusedAbsence'
                AND StudentSectionAssociation.HomeroomIndicator = TRUE
                THEN 1
            ELSE 0
            END) AS IsAbsentFromHomeroomUnexcused
    ,MAX(CASE 
            WHEN StudentSectionAttendanceEvent.Id IS NOT NULL
                AND sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Tardy'
                AND StudentSectionAssociation.HomeroomIndicator = TRUE
                THEN 1
            ELSE 0
            END) AS IsTardyToHomeroom
    ,MAX(CASE 
            WHEN StudentSectionAttendanceEvent.Id IS NOT NULL
                AND sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Present'
                THEN 1
            ELSE 0
            END) AS IsPresentAnyClass
    ,MAX(CASE 
            WHEN StudentSectionAttendanceEvent.Id IS NOT NULL
               AND sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.ExcusedAbsence'
                THEN 1
            ELSE 0
            END) AS IsAbsentFromAnyClassExcused
    ,MAX(CASE 
            WHEN StudentSectionAttendanceEvent.Id IS NOT NULL
                AND sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.UnexcusedAbsence'
                THEN 1
            ELSE 0
            END) AS IsAbsentFromAnyClassUnexcused
    ,MAX(CASE 
            WHEN StudentSectionAttendanceEvent.Id IS NOT NULL
                AND sectionAttendanceDescriptorMap.ConstantName = 'AttendanceEvent.Tardy'
                THEN 1
            ELSE 0
            END) AS IsTardyToAnyClass
    ,MAX(CASE 
            WHEN DisciplineIncident.Id IS NOT NULL
                AND behaviorDescriptorMap.ConstantName = 'Behavior.StateOffense'
                THEN 1
            ELSE 0
            END) AS CountByDayOfStateOffenses
    ,MAX(CASE 
            WHEN DisciplineIncident.Id IS NOT NULL
                AND behaviorDescriptorMap.ConstantName = 'Behavior.SchoolCodeOfConductOffense'
                THEN 1
            ELSE 0
            END) AS CountByDayOfConductOffenses
FROM edfi.StudentSchoolAssociation
INNER JOIN edfi.Student
    ON StudentSchoolAssociation.StudentUSI = Student.StudentUSI
INNER JOIN edfi.CalendarDateCalendarEvent
    ON CalendarDateCalendarEvent.SchoolId = StudentSchoolAssociation.SchoolId
        AND StudentSchoolAssociation.EntryDate <= CalendarDateCalendarEvent.DATE
        AND (
            StudentSchoolAssociation.ExitWithdrawDate IS NULL
            OR StudentSchoolAssociation.ExitWithdrawDate >= CalendarDateCalendarEvent.DATE
            )
-- outer join because we need to return non-instructional days, which are not listed in analytics_config.DescriptorMap
LEFT OUTER JOIN descriptorMap AS calendarDescriptorMap
    ON CalendarDateCalendarEvent.CalendarEventDescriptorId = calendarDescriptorMap.DescriptorId
-- School attendance
LEFT OUTER JOIN edfi.StudentSchoolAttendanceEvent
    ON StudentSchoolAssociation.StudentUSI = StudentSchoolAttendanceEvent.StudentUSI
        AND StudentSchoolAssociation.SchoolId = StudentSchoolAttendanceEvent.SchoolId
        AND (
            -- StudentSchoolAssociation.SchoolYear is nullable in this table
            StudentSchoolAssociation.SchoolYear IS NULL
            OR StudentSchoolAssociation.SchoolYear = StudentSchoolAttendanceEvent.SchoolYear
            )
        AND CalendarDateCalendarEvent.DATE = StudentSchoolAttendanceEvent.EventDate
LEFT OUTER JOIN descriptorMap AS schoolAttendanceDescriptorMap
    ON StudentSchoolAttendanceEvent.AttendanceEventCategoryDescriptorId = schoolAttendanceDescriptorMap.DescriptorId
-- Section Attendance
LEFT OUTER JOIN edfi.StudentSectionAttendanceEvent
    ON CalendarDateCalendarEvent.DATE = StudentSectionAttendanceEvent.EventDate
        AND StudentSchoolAssociation.StudentUSI = StudentSectionAttendanceEvent.StudentUSI
        AND StudentSchoolAssociation.SchoolId = StudentSectionAttendanceEvent.SchoolId
        AND (
            -- StudentSchoolAssociation.SchoolYear is nullable
            StudentSchoolAssociation.SchoolYear IS NULL
            OR StudentSchoolAssociation.SchoolYear = StudentSectionAttendanceEvent.SchoolYear
            )
LEFT OUTER JOIN edfi.StudentSectionAssociation
    ON StudentSectionAttendanceEvent.StudentUSI = StudentSectionAssociation.StudentUSI
        AND StudentSectionAttendanceEvent.LocalCourseCode = StudentSectionAssociation.LocalCourseCode
        AND StudentSectionAttendanceEvent.SchoolId = StudentSectionAssociation.SchoolId
        AND StudentSectionAttendanceEvent.SchoolYear = StudentSectionAssociation.SchoolYear
        AND StudentSectionAttendanceEvent.SectionIdentifier = StudentSectionAssociation.SectionIdentifier
        AND StudentSectionAttendanceEvent.SessionName = StudentSectionAssociation.SessionName
LEFT OUTER JOIN descriptorMap AS sectionAttendanceDescriptorMap
    ON StudentSectionAttendanceEvent.AttendanceEventCategoryDescriptorId = sectionAttendanceDescriptorMap.DescriptorId
-- Behavior
LEFT OUTER JOIN edfi.StudentDisciplineIncidentBehaviorAssociation
    ON StudentSchoolAssociation.StudentUSI = StudentDisciplineIncidentBehaviorAssociation.StudentUSI
        AND StudentSchoolAssociation.SchoolId = StudentDisciplineIncidentBehaviorAssociation.SchoolId
LEFT OUTER JOIN edfi.DisciplineIncidentBehavior
    ON DisciplineIncidentBehavior.IncidentIdentifier = StudentDisciplineIncidentBehaviorAssociation.IncidentIdentifier
        AND DisciplineIncidentBehavior.SchoolId = StudentDisciplineIncidentBehaviorAssociation.SchoolId
LEFT OUTER JOIN descriptorMap AS behaviorDescriptorMap
    ON DisciplineIncidentBehavior.BehaviorDescriptorId = behaviorDescriptorMap.DescriptorId
LEFT OUTER JOIN edfi.DisciplineIncident
    ON DisciplineIncidentBehavior.IncidentIdentifier = DisciplineIncident.IncidentIdentifier
        AND DisciplineIncidentBehavior.SchoolId = DisciplineIncident.SchoolId
        AND CalendarDateCalendarEvent.DATE = DisciplineIncident.IncidentDate
WHERE CalendarDateCalendarEvent.DATE <= NOW()
GROUP BY Student.StudentUniqueId
    ,StudentSchoolAssociation.SchoolId
    ,CalendarDateCalendarEvent.DATE;
