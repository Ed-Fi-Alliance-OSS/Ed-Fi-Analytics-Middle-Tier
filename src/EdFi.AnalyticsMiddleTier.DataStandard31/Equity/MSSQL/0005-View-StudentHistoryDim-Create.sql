-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
IF EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.VIEWS
        WHERE TABLE_SCHEMA = 'analytics'
            AND TABLE_NAME = 'equity_StudentHistoryDim'
        )
BEGIN
    DROP VIEW analytics.equity_StudentHistoryDim
END
GO

CREATE VIEW analytics.equity_StudentHistoryDim
AS
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

WITH AttendanceHist
AS (
    SELECT StudentSchoolKey
        ,COUNT(1) AS DaysEnrolled
        ,SUM(ReportedAsAbsentFromHomeRoom) AS DaysAbsent
    FROM analytics.chrab_ChronicAbsenteeismAttendanceFact
    GROUP BY StudentSchoolKey
    )
    ,GradeList
AS (
    SELECT CONCAT(studentSectionDim.StudentKey,'-'
            ,studentSectionDim.SchoolKey) AS StudentSchoolKey
            ,LastModifiedDate
        ,STUFF((
                SELECT CONCAT (
                        ', '
                        ,studentSectionDim.CourseTitle
                        ,': '
                        ,grade.NumericGradeEarned
                        )
                FROM analytics.ews_StudentSectionGradeFact grade
                WHERE grade.GradeType IN ('Semester')
                    AND grade.StudentSectionKey = studentSectionDim.StudentSectionKey
                    AND grade.SectionKey = studentSectionDim.SectionKey
                FOR XML PATH('')
                ), 1, 2, '') AS GradeSummary
    FROM analytics.StudentSectionDim studentSectionDim
    )
SELECT DISTINCT ssd.StudentKey
    ,ssd.StudentSchoolKey
    ,CAST(grades.GradeSummary AS VARCHAR(MAX)) as GradeSummary
    ,ssd.SchoolKey AS CurrentSchoolKey
    ,COALESCE((CAST((DaysEnrolled - DaysAbsent) AS DECIMAL) / CAST(DaysEnrolled AS DECIMAL) * 100), 100) AS AttendanceRate
    ,(
        SELECT COUNT(1)
        FROM analytics.equity_StudentDisciplineActionDim discipline
        WHERE discipline.StudentSchoolKey = ssd.StudentSchoolKey
        ) AS ReferralsAndSuspensions
    ,STUFF((
            SELECT CONCAT (
                    ','
                    ,CHAR(10)
                    ,SchoolName
                    ,' '
                    ,COALESCE(CAST(ssa.ExitWithdrawDate AS VARCHAR(10)), '')
                    )
            FROM edfi.StudentSchoolAssociation ssa
            INNER JOIN edfi.Student st
                ON st.StudentUSI = ssa.StudentUSI
            INNER JOIN analytics.SchoolDim school
                ON school.SchoolKey = ssa.SchoolId
            WHERE st.StudentUniqueId = ssd.StudentKey
            FOR XML PATH('')
            ), 1, 2, '') AS EnrollmentHistory
    ,(
        SELECT MAX(MaxLastModifiedDate)
        FROM (
            VALUES (ssd.LastModifiedDate)
                ,(grades.LastModifiedDate)
            ) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate
FROM analytics.StudentSchoolDim ssd
INNER JOIN GradeList grades
    ON ssd.StudentSchoolKey = grades.StudentSchoolKey
LEFT OUTER JOIN AttendanceHist ah
    ON ah.StudentSchoolKey = ssd.StudentSchoolKey
WHERE GradeSummary IS NOT NULL;
 

