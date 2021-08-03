-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT * FROM analytics_config.IndexJournal WHERE FullyQualifiedIndexName = '[edfi.StudentSectionAssociation].[IX_AMT_StudentSectionAssociation_StudentSectionDim]')
UPDATE analytics_config.IndexJournal SET FullyQualifiedIndexName='[edfi].[StudentSectionAssociation].[IX_AMT_StudentSectionAssociation_StudentSectionDim]' WHERE FullyQualifiedIndexName ='[edfi.StudentSectionAssociation].[IX_AMT_StudentSectionAssociation_StudentSectionDim]';
