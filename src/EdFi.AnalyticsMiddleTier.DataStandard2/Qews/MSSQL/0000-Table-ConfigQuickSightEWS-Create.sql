-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[SCHEMATA] WHERE SCHEMA_NAME = 'analytics_config')
BEGIN
    EXEC sp_executesql N'CREATE SCHEMA [analytics_config]';
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'analytics_config' AND TABLE_NAME = 'QuickSightEWS')
BEGIN
    CREATE TABLE [analytics_config].[QuickSightEWS] (
        [GradeAtRisk] DECIMAL(3,1) NOT NULL,
        [GradeEarlyWarning] DECIMAL(3,1) NOT NULL,
        [AttendanceAtRisk] DECIMAL(3,2) NOT NULL,
        [AttendanceEarlyWarning] DECIMAL(3,2) NOT NULL,
        [OffenseAtRisk] INT NOT NULL,
        [ConductAtRisk] INT NOT NULL,
        [ConductEarlyWarning] INT NOT NULL,
    ) ON [Primary]
END
GO

INSERT INTO [analytics_config].[QuickSightEWS]  (
    GradeAtRisk,
    GradeEarlyWarning,
    AttendanceAtRisk,
    AttendanceEarlyWarning,
    OffenseAtRisk,
    ConductAtRisk,
    ConductEarlyWarning
) VALUES (
    65.0,
    72.0,
    0.8,
    0.88,
    0,
    5,
    2
)

MERGE INTO [analytics_config].[QuickSightEWS] AS [Target]
USING (
    VALUES 
        (65.0, 72.0, 0.8, 0.88, 0, 5, 2 )
) AS [Source] ([GradeAtRisk], [GradeEarlyWarning], [AttendanceAtRisk], [AttendanceEarlyWarning], [OffenseAtRisk], [ConductAtRisk], [ConductEarlyWarning])
ON 
        [Target].[GradeAtRisk] = [Source].[GradeAtRisk]
    AND [Target].[GradeEarlyWarning] = [Source].[GradeEarlyWarning]
    AND [Target].[AttendanceAtRisk] = [Source].[AttendanceAtRisk]
    AND [Target].[AttendanceEarlyWarning] = [Source].[AttendanceEarlyWarning]
    AND [Target].[OffenseAtRisk] = [Source].[OffenseAtRisk]
    AND [Target].[ConductAtRisk] = [Source].[ConductAtRisk]
    AND [Target].[ConductEarlyWarning] = [Source].[ConductEarlyWarning]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([GradeAtRisk], [GradeEarlyWarning], [AttendanceAtRisk], [AttendanceEarlyWarning], [OffenseAtRisk], [ConductAtRisk], [ConductEarlyWarning]) 
VALUES ([GradeAtRisk], [GradeEarlyWarning], [AttendanceAtRisk], [AttendanceEarlyWarning], [OffenseAtRisk], [ConductAtRisk], [ConductEarlyWarning])
OUTPUT $action, inserted.*;