-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

/*
    The script provides information about the daily attendance rates for the students based on a specific demographic.
    For obtaining this result, we have used the analytics.chrab_ChronicAbsenteeismAttendanceFact,StudentSchoolDemographicsBridge,DemographicDim and DateDim Views.
    This view returns the average daily attendance as filtered by the student demographic record.     
The query:
    The first part (With statement) obtains the total number of absents and the number of students enrolled, grouped by school, date, demographic and student.
    In the second part we obtain the attendace rate by demographic. It can be filtered by Demographic (CohortYear, Disability, DisabilityDesignation, Language, LanguageUse, Race, StudentCharacteristic, TribalAffiliation). 

+----------+-------------+--------------------+-----------+----------------+
| DateKey  | Demographic |  DemographicValue  | SchoolKey | AttendanceRate |
+----------+-------------+--------------------+-----------+----------------+
| 20120520 | Language    | English            | 867530011 |         100.00 |
| 20120520 | Language    | Korean             | 867530011 |         100.00 |
| 20120516 | Language    | English            | 867530011 |         100.00 |
| 20120516 | Language    | Korean             | 867530011 |         100.00 |
| 20120515 | Language    | English            | 867530011 |          75.00 |
| 20120515 | Language    | Korean             | 867530011 |         100.00 |
| 20120510 | Language    | English            | 867530011 |         100.00 |
+----------+-------------+--------------------+-----------+----------------+
*/

WITH Attendance
     AS (SELECT 
                chrab_ChronicAbsenteeismAttendanceFact.DateKey, 
                chrab_ChronicAbsenteeismAttendanceFact.SchoolKey, 
                DemographicDim.DemographicParentKey AS Demographic, 
                DemographicDim.DemographicLabel AS DemographicValue, 
                DemographicDim.DemographicKey, 
                COUNT(1) AS StudentsCount, 
                SUM(IsAbsentFromHomeRoom) AS AbsentStudents
         FROM 
              analytics.chrab_ChronicAbsenteeismAttendanceFact
         INNER JOIN
             analytics.StudentSchoolDemographicsBridge ON
                 StudentSchoolDemographicsBridge.StudentSchoolKey = chrab_ChronicAbsenteeismAttendanceFact.StudentSchoolKey
         INNER JOIN
             analytics.DemographicDim ON
                 DemographicDim.DemographicKey = StudentSchoolDemographicsBridge.DemographicKey
         INNER JOIN
             analytics.DateDim ON
                 chrab_ChronicAbsenteeismAttendanceFact.DateKey = DateDim.DateKey
         GROUP BY 
                  chrab_ChronicAbsenteeismAttendanceFact.DateKey, 
                  chrab_ChronicAbsenteeismAttendanceFact.SchoolKey, 
                  DemographicDim.DemographicParentKey, 
                  DemographicDim.DemographicLabel, 
                  DemographicDim.DemographicKey)
     SELECT 
            DateKey, 
            Demographic, 
            DemographicValue, 
            Attendance.SchoolKey, 
            ROUND((100.0 * ((Attendance.StudentsCount - Attendance.AbsentStudents)) / Attendance.StudentsCount), 2) AS AttendanceRate
     FROM 
          Attendance
     WHERE
          Demographic = 'Language'
     ORDER BY 
          DateKey DESC;