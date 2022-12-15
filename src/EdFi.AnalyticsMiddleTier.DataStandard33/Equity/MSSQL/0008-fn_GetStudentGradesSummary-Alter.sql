-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
IF EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.ROUTINES
        WHERE ROUTINE_SCHEMA = 'analytics'
            AND ROUTINE_NAME = 'fn_GetStudentGradesSummary'
        )
BEGIN
    DROP FUNCTION analytics.fn_GetStudentGradesSummary
END
GO

CREATE FUNCTION analytics.fn_GetStudentGradesSummary (
    @StudentKey VARCHAR(8000)
    ,@SchoolKey VARCHAR(8000)
    )
RETURNS VARCHAR(8000)
AS
BEGIN
    DECLARE @val VARCHAR(8000)

    SELECT @val = COALESCE(@VAL, '') + (
            CAST(CONCAT (
                    ', '
                    ,CHAR(10)
                    ,course.CourseTitle
                    ,': '
                    ,gradeFact.NumericGradeEarned
                    ) AS VARCHAR(8000))
            )
    FROM edfi.Student
    INNER JOIN edfi.Grade gradeFact
        ON gradeFact.StudentUSI = Student.StudentUSI
    INNER JOIN edfi.CourseOffering
        ON CourseOffering.SchoolId = gradeFact.SchoolId
            AND CourseOffering.LocalCourseCode = gradeFact.LocalCourseCode
            AND CourseOffering.SchoolYear = gradeFact.SchoolYear
            AND CourseOffering.SessionName = gradeFact.SessionName
    INNER JOIN edfi.Course
        ON Course.CourseCode = CourseOffering.CourseCode
            AND Course.EducationOrganizationId = CourseOffering.EducationOrganizationId
    INNER JOIN edfi.Descriptor
        ON GradeTypeDescriptorId = Descriptor.DescriptorId
    INNER JOIN edfi.GradingPeriod
        ON gradeFact.GradingPeriodDescriptorId = GradingPeriod.GradingPeriodDescriptorId
            AND gradeFact.GradingPeriodSequence = GradingPeriod.PeriodSequence
            AND gradeFact.SchoolId = GradingPeriod.SchoolId
            AND gradeFact.GradingPeriodSchoolYear = GradingPeriod.SchoolYear
    INNER JOIN analytics_config.DescriptorMap
        ON DescriptorMap.DescriptorId = GradeTypeDescriptorId
    INNER JOIN analytics_config.DescriptorConstant
        ON DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
    WHERE DescriptorConstant.ConstantName IN ('GradeType.Semester')
        AND Student.StudentUniqueId = @StudentKey
        AND gradeFact.SchoolId = @SchoolKey
    ORDER BY gradeFact.GradingPeriodDescriptorId DESC
        ,gradeFact.SchoolId DESC
        ,GradingPeriod.BeginDate DESC;

    RETURN COALESCE(STUFF(COALESCE(@val, ''), 1, 3, ''),'');
END
