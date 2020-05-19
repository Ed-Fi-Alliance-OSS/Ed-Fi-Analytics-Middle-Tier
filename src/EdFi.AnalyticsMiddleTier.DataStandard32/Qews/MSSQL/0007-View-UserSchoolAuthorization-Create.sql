-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW analytics.qews_UserSchoolAuthorization AS

    /*
     * This view was made with QuickSight row-level security in mind, which
     * requires a user column, and a column containing a comma-separated list
     * of keys that the user can access. The first column *must* be called
     * UserName, and the additional column(s) must precisely match the name
     * of a column in the dataset that is being protected.
     *
     * This query effectively will give all teachers access to all students
     * in a school. Haven't found any way, with QuickSight limitations,
     * to provide access only to students in the teacher's sections.
     */

    WITH permission as (
        SELECT
            UserEmail as UserName,
            STUFF((
                SELECT DISTINCT
                    N',' + CAST(SchoolPermission as NVARCHAR)
                FROM
                    analytics.rls_UserAuthorization
                WHERE
                    UserKey = rls_UserDim.UserKey
                AND rls_UserAuthorization.StudentPermission = 'ALL'
                FOR XML PATH('')), 1, 1, N'') as SchoolKey
        FROM
            analytics.rls_UserDim
    )
    SELECT
        UserName,
        CASE WHEN SchoolKey = 'ALL' THEN '' ELSE SchoolKey END as SchoolKey
    FROM
        permission
GO
