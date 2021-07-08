-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW analytics.engage_AssignmentDim AS
    
    SELECT
        1 as AssignmentKey,
        1 as SchoolKey,
        1 as SourceSystem,
        1 as Title,
        1 as Description,
        1 as StartDateKey,
        1 as EndDateKey,
        1 as DueDateKey,
        1 as MaxPoints,
        1 as SectionKey,
        1 as GradingPeriodKey,
        1 as LastModifiedDate
