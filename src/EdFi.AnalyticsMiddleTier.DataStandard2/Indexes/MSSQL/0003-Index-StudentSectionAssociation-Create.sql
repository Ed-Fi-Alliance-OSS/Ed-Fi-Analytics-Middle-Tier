-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE NONCLUSTERED INDEX [IX_AMT_StudentSectionAssociation_StudentSectionDim] ON [edfi].[StudentSectionAssociation] (
	[SchoolId],
	[LocalCourseCode],
	[SchoolYear],
	[TermDescriptorId]
)
INCLUDE (
	[EndDate],
	[LastModifiedDate]
)
GO

INSERT INTO [analytics_config].[IndexJournal] VALUES ('[edfi].[StudentSectionAssociation].[IX_AMT_StudentSectionAssociation_StudentSectionDim]')
