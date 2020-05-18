-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

/*
 * This script is optimized for running multiple times, in order to support
 * the uninstall / reinstall process. Uninstall leaves the new tables in 
 * place so that the DBA will not lose any existing scope mappings. However,
 * the journal table is deleted. Thus if you then re-run the migration utility,
 * this script will run it again. The script name will be add to the 
 * re-created journal table, but no error will occur due to the existing
 * table and the existing table's data will be preserved.
 */

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'analytics_config' AND TABLE_NAME = 'ews_LetterGradeTranslation')
BEGIN
	CREATE TABLE [analytics_config].[ews_LetterGradeTranslation] (
		[LetterGradeEarned] NVARCHAR(20) NOT NULL,
		[NumericGradeEarned] DECIMAL(9,2) NOT NULL,
		CONSTRAINT [PK_ews_LetterGradeTranslation] PRIMARY KEY CLUSTERED ([LetterGradeEarned])
	) ON [Primary];

	-- Default values can be adjusted after deployment
	INSERT INTO [analytics_config].[ews_LetterGradeTranslation]  (
		[LetterGradeEarned],
		[NumericGradeEarned]
	) VALUES 
		( 'A', 95.0 ),
		( 'B', 85.0 ),
		( 'C', 75.0 ),
		( 'D', 65.0 ),
		( 'F', 55.0 );
END;