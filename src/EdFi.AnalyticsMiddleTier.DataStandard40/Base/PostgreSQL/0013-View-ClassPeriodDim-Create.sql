﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
DROP VIEW IF EXISTS analytics.ClassPeriodDim;
CREATE OR REPLACE VIEW analytics.ClassPeriodDim AS
    SELECT 
           CONCAT(ClassPeriodName, '-', LocalCourseCode, '-', SchoolId, '-', SchoolYear, '-', SectionIdentifier, '-', SessionName) ClassPeriodKey, 
           CONCAT(SchoolId, '-', LocalCourseCode, '-', SchoolYear, '-', SectionIdentifier, '-', SessionName) SectionKey,
           ClassPeriodName,
           LocalCourseCode, 
           cast(SchoolId as varchar) as SchoolId, 
           cast(SchoolId as varchar) as SchoolKey,   
           cast(SchoolYear as varchar) as SchoolYear, 
           SectionIdentifier, 
           SessionName
    FROM 
         edfi.SectionClassPeriod;
