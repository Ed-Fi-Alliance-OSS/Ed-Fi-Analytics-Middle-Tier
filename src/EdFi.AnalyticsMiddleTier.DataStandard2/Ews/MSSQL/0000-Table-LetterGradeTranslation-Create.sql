-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'analytics_config' AND TABLE_NAME = 'ews_LetterGradeTranslation')
BEGIN
    CREATE TABLE [analytics_config].[ews_LetterGradeTranslation] (
        [LetterGradeEarned] NVARCHAR(20) NOT NULL,
        [NumericGradeEarned] DECIMAL(9,2) NOT NULL,
        CONSTRAINT [PK_ews_LetterGradeTranslation] PRIMARY KEY CLUSTERED ([LetterGradeEarned])
    ) ON [Primary]
END
GO

-- Default values can be adjusted after deployment
MERGE INTO [analytics_config].[ews_LetterGradeTranslation] AS [Target]
USING (
    VALUES 
        ( 'A', 95.0 ),
        ( 'B', 85.0 ),
        ( 'C', 75.0 ),
        ( 'D', 65.0 ),
        ( 'F', 55.0 )
) AS [Source] ([LetterGradeEarned], [NumericGradeEarned])
ON 
        [Target].[LetterGradeEarned] = [Source].[LetterGradeEarned]
    AND	[Target].[NumericGradeEarned] = [Source].[NumericGradeEarned]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([LetterGradeEarned], [NumericGradeEarned]) VALUES ([LetterGradeEarned], [NumericGradeEarned])
OUTPUT $action, inserted.*;
