-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE NAME = N'IX_AMT_StudentSectionAssociation_StudentSectionDim')
CREATE NONCLUSTERED INDEX IX_AMT_StudentSectionAssociation_StudentSectionDim ON edfi.StudentSectionAssociation (
	SchoolId,
	LocalCourseCode,
	SchoolYear,
	SessionName
)
INCLUDE (
	EndDate,
	LastModifiedDate
)
GO
IF NOT EXISTS (SELECT * FROM analytics_config.IndexJournal WHERE FullyQualifiedIndexName = '[edfi.StudentSectionAssociation].[IX_AMT_StudentSectionAssociation_StudentSectionDim]')
INSERT INTO analytics_config.IndexJournal VALUES ('[edfi.StudentSectionAssociation].[IX_AMT_StudentSectionAssociation_StudentSectionDim]')
