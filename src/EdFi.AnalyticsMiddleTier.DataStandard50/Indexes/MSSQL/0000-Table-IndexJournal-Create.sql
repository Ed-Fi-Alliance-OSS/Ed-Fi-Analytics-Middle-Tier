-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'analytics_config' AND TABLE_NAME = 'IndexJournal')
BEGIN
	CREATE TABLE analytics_config.IndexJournal (
		FullyQualifiedIndexName NVARCHAR(400) NOT NULL,
		CONSTRAINT PK_IndexJournal PRIMARY KEY CLUSTERED (FullyQualifiedIndexName)
	) ON [PRIMARY]
END