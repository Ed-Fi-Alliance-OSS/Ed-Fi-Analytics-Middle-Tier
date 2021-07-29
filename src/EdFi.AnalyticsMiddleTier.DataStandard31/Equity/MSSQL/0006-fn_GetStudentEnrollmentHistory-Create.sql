-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
IF EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.ROUTINES
        WHERE ROUTINE_SCHEMA = 'analytics'
            AND ROUTINE_NAME = 'fn_GetStudentEnrollmentHistory'
        )
BEGIN
    DROP FUNCTION analytics.fn_GetStudentEnrollmentHistory
END
GO

CREATE FUNCTION [analytics].[fn_GetStudentEnrollmentHistory] (
    -- Add the parameters for the function here
    @StudentKey VARCHAR(8000)
    )
RETURNS VARCHAR(8000)
AS
BEGIN
    -- Declare the return variable here
    DECLARE @val VARCHAR(8000)

    SELECT @val = COALESCE(@VAL, '') + (
            CAST(CONCAT (
                    ','
                    ,CHAR(10)
                    ,SchoolName
                    ,' '
                    ,COALESCE(CAST(ssa.ExitWithdrawDate AS VARCHAR(10)), '')
                    ) AS VARCHAR(8000))
            )
    FROM edfi.StudentSchoolAssociation ssa
    INNER JOIN edfi.Student st
        ON st.StudentUSI = ssa.StudentUSI
    INNER JOIN analytics.SchoolDim school
        ON school.SchoolKey = ssa.SchoolId
    WHERE st.StudentUniqueId = @StudentKey;

    RETURN STUFF(COALESCE(@val,''),1,2,'');
END;