-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE NONCLUSTERED INDEX [IX_AMT_AcademicSubjectType_CodeValue] ON [edfi].[AcademicSubjectType] (
	[CodeValue]
)
GO

INSERT INTO [analytics_config].[IndexJournal] VALUES ('[edfi].[AcademicSubjectType].[IX_AMT_AcademicSubjectType_CodeValue]')