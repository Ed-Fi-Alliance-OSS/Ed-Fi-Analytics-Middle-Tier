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
    SELECT DISTINCT studentSectionDim.StudentSectionKey
        ,STRING_AGG(CAST(CONCAT(studentSectionDim.CourseTitle, ': ', CAST(gradeFact.NumericGradeEarned AS VARCHAR(100))) as VARCHAR(MAX)), CONCAT(', ' , CHAR(10))) AS GradeSummary
    FROM analytics.ews_StudentSectionGradeFact gradeFact
    INNER JOIN analytics.StudentSectionDim studentSectionDim
        ON gradeFact.StudentSectionKey = studentSectionDim.StudentSectionKey
            AND gradeFact.SectionKey = studentSectionDim.SectionKey
    GROUP BY studentSectionDim.StudentSectionKey
        ,gradeFact.GradingPeriodKey
    )
SELECT DISTINCT studentSchoolDim.StudentKey
    ,studentSchoolDim.StudentSchoolKey
    ,STRING_AGG(gradeFact.GradeSummary, CONCAT(', ' , CHAR(10))) AS GradeSummary
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
                    ),CONCAT(', ' , CHAR(10)))
        FROM edfi.StudentSchoolAssociation ssd
        INNER JOIN edfi.Student st
            ON st.StudentUSI = ssd.StudentUSI
        INNER JOIN analytics.SchoolDim school
            ON school.SchoolKey = ssd.SchoolId
        WHERE st.StudentUniqueId = studentSectionDim.StudentKey
        ) AS EnrollmentHistory
    ,(
        SELECT MAX(MaxLastModifiedDate)
        FROM (
            VALUES (studentSchoolDim.LastModifiedDate)
                ,(studentSectionDim.LastModifiedDate)
            ) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate
FROM analytics.StudentSchoolDim studentSchoolDim
INNER JOIN analytics.StudentSectionDim studentSectionDim
    ON StudentSectionDim.StudentKey = studentSchoolDim.StudentKey
INNER JOIN GradeList gradeFact
    ON gradeFact.StudentSectionKey = studentSectionDim.StudentSectionKey
LEFT OUTER JOIN AttendanceHist ah
    ON ah.StudentSchoolKey = studentSchoolDim.StudentSchoolKey
GROUP BY studentSchoolDim.StudentKey
    ,studentSchoolDim.StudentSchoolKey
    ,studentSchoolDim.SchoolKey
    ,DaysEnrolled
    ,DaysAbsent
    ,StudentSectionDim.StudentKey
	,studentSchoolDim.LastModifiedDate
	,studentSectionDim.LastModifiedDate;
