-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE NAME = N'IX_AMT_Grade_SectionKey')
CREATE NONCLUSTERED INDEX [IX_AMT_Grade_SectionKey]
ON [edfi].[Grade] ([StudentUSI],[SchoolId],[LocalCourseCode],[SchoolYear],[SectionIdentifier],[SessionName])
INCLUDE ([NumericGradeEarned])
GO
IF NOT EXISTS (SELECT * FROM [analytics_config].[IndexJournal] WHERE [FullyQualifiedIndexName] = '[edfi].[Grade].[IX_AMT_Grade_SectionKey]')
INSERT INTO [analytics_config].[IndexJournal] VALUES ('[edfi].[Grade].[IX_AMT_Grade_SectionKey]')
