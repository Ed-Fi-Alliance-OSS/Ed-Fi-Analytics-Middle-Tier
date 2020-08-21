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
        CONCAT(Section.ClassPeriodName, '-', Section.LocalCourseCode, '-', Section.SchoolId, '-', Section.SchoolYear, '-', Section.TermDescriptorId, '-', Section.UniqueSectionCode, '-', Session.SessionName) ClassPeriodKey, 
        CONCAT(section.SchoolId, '-', Section.ClassPeriodName, '-', section.ClassroomIdentificationCode, '-', Section.LocalCourseCode, '-', Section.TermDescriptorId, '-', Section.SchoolYear, '-', Section.UniqueSectionCode, '-', Section.SequenceOfCourse) as SectionKey,
        Section.ClassPeriodName, 
        Section.LocalCourseCode, 
        Section.SchoolId, 
        Section.SchoolYear, 
        Section.UniqueSectionCode as SectionIdentifier, 
        Session.SessionName
    FROM 
        edfi.Section
    INNER JOIN
        edfi.Session ON
            Section.SchoolId = Session.SchoolId
            AND
            Section.SchoolYear = Session.SchoolYear
            AND
            Section.TermDescriptorId = Session.TermDescriptorId
GO