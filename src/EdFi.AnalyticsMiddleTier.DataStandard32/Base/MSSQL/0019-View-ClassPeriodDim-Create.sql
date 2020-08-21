-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'ClassPeriodDim')
BEGIN
	DROP VIEW analytics.ClassPeriodDim
END
GO

CREATE VIEW analytics.ClassPeriodDim AS
    SELECT
           CONCAT(ClassPeriodName, '-', LocalCourseCode, '-', SchoolId, '-', SchoolYear, '-', SectionIdentifier, '-', SessionName) ClassPeriodKey,
           CONCAT(SchoolId, '-', LocalCourseCode, '-', SchoolYear, '-', SectionIdentifier, '-', SessionName) SectionKey,
           ClassPeriodName,
           LocalCourseCode, 
           SchoolId, 
           SchoolYear, 
           SectionIdentifier, 
           SessionName
    FROM 
         edfi.SectionClassPeriod;
GO