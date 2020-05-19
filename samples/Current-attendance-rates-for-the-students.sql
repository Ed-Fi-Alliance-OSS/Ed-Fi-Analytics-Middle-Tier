-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

/*
    The script provides information about the attendance rate for student.
    For obtaining this result, we have used the analytics.chrab_ChronicAbsenteeismAttendanceFact View only.
    This view tells us if a student was absent on any given day. So, by just doing a summarization of those absent days and considering the days enrolled, 
    we can obtain this absent rate for student. 

The query:
    The first part (With statement) obtains the total number of absents and the number of days enrolled, grouped by school and student.
    In the second part we obtain the days the student has been present and using a rule of three we can obtain the attendance rate. 
*/

WITH aggr as (
    SELECT
        StudentKey,
        SchoolKey,
        COUNT(1) AS DaysEnrolled,
        SUM(IsAbsentFromHomeRoom) AS DaysAbsent
    FROM
        analytics.chrab_ChronicAbsenteeismAttendanceFact
    GROUP BY
        StudentKey,
        SchoolKey
)
SELECT
    StudentKey,
    SchoolKey,
    ROUND(CAST(DaysEnrolled - DaysAbsent AS FLOAT) / CAST(DaysEnrolled AS FLOAT) * 100, 2) AS AttendanceRate
FROM 
    aggr
