-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW analytics.equity_StudentHistoryDim
AS

WITH AttendanceHist
AS (
    SELECT StudentSchoolKey
        ,COUNT(1) AS DaysEnrolled
        ,SUM(ReportedAsAbsentFromHomeRoom) AS DaysAbsent
    FROM analytics.chrab_ChronicAbsenteeismAttendanceFact
    GROUP BY StudentSchoolKey
    )
SELECT DISTINCT ssd.StudentKey
    ,ssd.StudentSchoolKey
    ,COALESCE(analytics.fn_GetStudentGradesSummary(ssd.StudentKey,ssd.SchoolKey),'') AS GradeSummary
    ,ssd.SchoolKey AS CurrentSchoolKey
    ,COALESCE((CAST((DaysEnrolled - DaysAbsent) AS DECIMAL) / CAST(DaysEnrolled AS DECIMAL) * 100), 100) AS AttendanceRate
    ,(
        SELECT COUNT(1)
        FROM analytics.equity_StudentDisciplineActionDim discipline
        WHERE discipline.StudentSchoolKey = ssd.StudentSchoolKey
        ) AS ReferralsAndSuspensions
    ,analytics.fn_GetStudentEnrollmentHistory(ssd.StudentKey) AS EnrollmentHistory
    ,(
        SELECT MaxLastModifiedDate
        FROM (
            VALUES (ssd.LastModifiedDate)
          ) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate
FROM analytics.StudentSchoolDim ssd
LEFT OUTER JOIN AttendanceHist ah
    ON ah.StudentSchoolKey = ssd.StudentSchoolKey;
