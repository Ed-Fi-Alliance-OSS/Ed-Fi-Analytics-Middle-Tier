-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
CREATE
    OR REPLACE VIEW analytics.equity_StudentHistoryDim AS
    WITH AttendanceHist AS (
            SELECT StudentSchoolKey
                ,COUNT(1) AS DaysEnrolled
                ,SUM(ReportedAsAbsentFromHomeRoom) AS DaysAbsent
            FROM analytics.chrab_ChronicAbsenteeismAttendanceFact
            GROUP BY StudentSchoolKey
            )
        ,GradeList AS (
            SELECT CONCAT (
                    studentSectionDim.StudentKey
                    ,'-'
                    ,studentSectionDim.SchoolKey
                    ) AS StudentSchoolKey
                ,studentSectionDim.LastModifiedDate
                ,STRING_AGG(CAST(CONCAT (
                            studentSectionDim.CourseTitle
                            ,': '
                            ,gradeFact.NumericGradeEarned
                            ) AS VARCHAR(8000)), ', ') AS GradeSummary
            FROM analytics.ews_StudentSectionGradeFact gradeFact
            INNER JOIN analytics.StudentSectionDim studentSectionDim
                ON gradeFact.StudentSectionKey = studentSectionDim.StudentSectionKey
                    AND gradeFact.SectionKey = studentSectionDim.SectionKey
            WHERE gradeFact.GradeType IN ('Semester')
			GROUP BY studentSectionDim.StudentKey
                ,studentSectionDim.SchoolKey
                ,studentSectionDim.LastModifiedDate
            )

SELECT DISTINCT studentSchoolDim.StudentKey
    ,studentSchoolDim.StudentSchoolKey
    ,gradeFact.GradeSummary AS GradeSummary
    ,studentSchoolDim.SchoolKey AS CurrentSchoolKey
    ,COALESCE((CAST((DaysEnrolled - DaysAbsent) AS DECIMAL) / CAST(DaysEnrolled AS DECIMAL) * 100), 100) AS AttendanceRate
    ,(
        SELECT COUNT(1)
        FROM analytics.equity_StudentDisciplineActionDim discipline
        WHERE discipline.StudentSchoolKey = studentSchoolDim.StudentSchoolKey
        ) AS ReferralsAndSuspensions
    ,(
        SELECT STRING_AGG(CONCAT (
                    SchoolName
                    ,' '
                    ,COALESCE(CAST(ssd.ExitWithdrawDate AS VARCHAR(10)), ' (Current)')
                    ), ', ')
        FROM edfi.StudentSchoolAssociation ssd
        INNER JOIN edfi.Student st
            ON st.StudentUSI = ssd.StudentUSI
        INNER JOIN analytics.SchoolDim school
            ON school.SchoolKey = CAST(ssd.SchoolId AS VARCHAR)
        WHERE st.StudentUniqueId = studentSchoolDim.StudentKey
        ) AS EnrollmentHistory
    ,(
        SELECT MAX(MaxLastModifiedDate)
        FROM (
            VALUES (studentSchoolDim.LastModifiedDate)
                ,(gradeFact.LastModifiedDate)
            ) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate
FROM analytics.StudentSchoolDim studentSchoolDim
INNER JOIN GradeList gradeFact
    ON gradeFact.StudentSchoolKey = studentSchoolDim.StudentSchoolKey
LEFT OUTER JOIN AttendanceHist ah
    ON ah.StudentSchoolKey = studentSchoolDim.StudentSchoolKey;
