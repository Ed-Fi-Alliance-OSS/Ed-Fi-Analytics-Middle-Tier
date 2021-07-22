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
    @StudentKey VARCHAR(max)
    ,@SchoolKey VARCHAR(max)
    )
RETURNS VARCHAR(max)
AS
BEGIN
 DECLARE @val VARCHAR(max)

 SELECT  @val = COALESCE(@VAL, '') + (
            CAST(CONCAT (
                    ', '
					,CHAR(10)
                    ,course.CourseTitle
                    ,': '
                    ,gradeFact.NumericGradeEarned
                    ) AS VARCHAR(8000))
            )
    FROM edfi.Student
	INNER JOIN  edfi.Grade gradeFact
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
    WHERE Descriptor.CodeValue IN ('Semester')
        AND Student.StudentUniqueId = @StudentKey
        AND gradeFact.SchoolId = @SchoolKey;

    RETURN STUFF(COALESCE(@val,''),1,3,'');
END