-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

/*
    The script provides information about the historical attendance rates for the students.
    For obtaining this result, we have used the analytics.chrab_ChronicAbsenteeismAttendanceFact, StudentSchoolDim and DateDim.

The query:
    The query obtains the rate of attendance, grouped by school and student and date.
*/
SELECT 
       DateDim.DateKey, 
       Attendance.StudentKey, 
       Attendance.SchoolKey, 
       ROUND(100.0 * ((Attendance.DaysEnrolled - Attendance.DaysAbsent) / Attendance.DaysEnrolled), 2) AS AttendanceRateToDate
FROM 
     analytics.DateDim
OUTER APPLY
    ( SELECT 
             StudentSchoolDim.StudentKey, 
             StudentSchoolDim.SchoolKey, 
             COUNT(1) AS DaysEnrolled, 
             SUM(IsAbsentFromHomeRoom) AS DaysAbsent
      FROM 
           analytics.StudentSchoolDim
      INNER JOIN
          analytics.chrab_ChronicAbsenteeismAttendanceFact ON
              StudentSchoolDim.StudentSchoolKey = chrab_ChronicAbsenteeismAttendanceFact.StudentSchoolKey
      WHERE
              DateDim.DateKey >= StudentSchoolDim.EnrollmentDateKey
              AND
              chrab_ChronicAbsenteeismAttendanceFact.DateKey < DateDim.DateKey
      GROUP BY 
               StudentSchoolDim.StudentKey, 
               StudentSchoolDim.SchoolKey
    ) AS Attendance;