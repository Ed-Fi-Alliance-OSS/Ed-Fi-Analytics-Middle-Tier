-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS(SELECT 1 FROM sys.database_principals WHERE [type] = 'R' AND [name] = 'analytics_middle_tier')
BEGIN
	CREATE ROLE [analytics_middle_tier]
END
GO

GRANT SELECT ON SCHEMA::analytics TO [analytics_middle_tier]