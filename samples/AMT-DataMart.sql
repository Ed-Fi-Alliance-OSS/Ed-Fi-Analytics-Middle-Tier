﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


/*
This script will create a data mart with the views materialized into tables.
Run this with sqlcmd or in SSMS with "sqlcmd mode" turned on. Adjust the two 
variables immediately below as needed. Assumes that the destination database 
already exists and is on the same server as the ODS. Run the script 
periodically to refresh the data.
*/


:setvar DataMartDB EdFi_AMT_DataMart
:setvar OdsDb EdFi_Glendale


USE [$(DataMartDB)]
GO

IF NOT EXISTS (SELECT 1 FROM [INFORMATION_SCHEMA].[SCHEMATA] WHERE SCHEMA_NAME = 'analytics')
BEGIN
	EXEC sp_executesql N'CREATE SCHEMA [analytics]';
END

----------------------------
-- Populate Staging Tables
----------------------------
PRINT 'Creating staging tables...'

SELECT * 
INTO [$(DataMartDB)].[analytics].[stg_ContactPersonDim]
FROM [$(OdsDb)].[analytics].[ContactPersonDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_DateDim]
FROM [$(OdsDb)].[analytics].[DateDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_GradingPeriodDim]
FROM [$(OdsDb)].[analytics].[GradingPeriodDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_MostRecentGradingPeriod]
FROM [$(OdsDb)].[analytics].[MostRecentGradingPeriod]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_SchoolDim]
FROM [$(OdsDb)].[analytics].[SchoolDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_SchoolNetworkAssociationDim]
FROM [$(OdsDb)].[analytics].[SchoolNetworkAssociationDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_rls_StudentDataAuthorization]
FROM [$(OdsDb)].[analytics].[rls_StudentDataAuthorization]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_StudentDim]
FROM [$(OdsDb)].[analytics].[StudentDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_ews_StudentEarlyWarningFact]
FROM [$(OdsDb)].[analytics].[ews_StudentEarlyWarningFact]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_StudentSectionDim]
FROM [$(OdsDb)].[analytics].[StudentSectionDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_ews_StudentSectionGradeFact]
FROM [$(OdsDb)].[analytics].[ews_StudentSectionGradeFact]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_rls_UserAuthorization]
FROM [$(OdsDb)].[analytics].[rls_UserAuthorization]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_rls_UserDim]
FROM [$(OdsDb)].[analytics].[rls_UserDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_rls_UserStudentDataAuthorization]
FROM [$(OdsDb)].[analytics].[rls_UserStudentDataAuthorization]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_LocalEducationAgencyDim]
FROM [$(OdsDb)].[analytics].[LocalEducationAgencyDim]
GO

----------------------------
-- Add Indexes to Staging Tables
----------------------------
PRINT 'Adding indexes to staging tables...'

CREATE NONCLUSTERED INDEX [IX_ContactPersonDim_StudentKey] 
ON [analytics].[stg_ContactPersonDim] (
	[StudentKey]
) ON [Primary]


CREATE UNIQUE CLUSTERED INDEX [UCX_DateDim]
ON [analytics].[stg_DateDim] (
	[DateKey]
) ON [Primary]


CREATE UNIQUE CLUSTERED INDEX [UCX_GradingPeriodDim]
ON [analytics].[stg_GradingPeriodDim] (
	[GradingPeriodKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_GradingPeriodDim_SchoolKey]
ON [analytics].[stg_GradingPeriodDim] (
	[SchoolKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_MostRecentGradingPeriod]
ON [analytics].[stg_MostRecentGradingPeriod] (
	[SchoolKey]
) ON [Primary]


CREATE UNIQUE CLUSTERED INDEX [UCX_SchoolDim]
ON [analytics].[stg_SchoolDim] (
	[SchoolKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_SchoolNetworkAssociationDim_SchoolKey]
ON [analytics].[stg_SchoolNetworkAssociationDim] (
	[SchoolKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_rls_StudentDataAuthorization]
ON [analytics].[stg_rls_StudentDataAuthorization] (
	[StudentKey],
	[SchoolKey],
	[BeginDate],
	[EndDate]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_StudentDim]
ON [analytics].[stg_StudentDim] (
	[StudentKey],
	[SchoolKey]
) ON [Primary]


CREATE UNIQUE CLUSTERED INDEX [UCX_ews_StudentEarlyWarningFact]
ON [analytics].[stg_ews_StudentEarlyWarningFact] (
	[StudentKey],
	[SchoolKey],
	[DateKey]
) ON [Primary]


CREATE UNIQUE CLUSTERED INDEX [UCX_StudentSectionDim]
ON [analytics].[stg_StudentSectionDim] (
	[StudentSectionKey]
) ON [Primary]


CREATE INDEX [IX_StudentSectionDim_StudentSectionKey] ON
	[analytics].[stg_StudentSectionDim]
(
	[StudentKey],
	[StudentSectionKey],
	[Subject],
	[SchoolKey]
) ON [Primary]


CREATE NONCLUSTERED INDEX [IX_StudentSectionDim_SchoolKey]
ON [analytics].[stg_StudentSectionDim] (
	[SchoolKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StudentSectionDim_SectionKey]
ON [analytics].[stg_StudentSectionDim] (
	[SectionKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_ews_StudentSectionGradeFact]
ON [analytics].[stg_ews_StudentSectionGradeFact] (
	[StudentSectionKey],
	[GradingPeriodKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_ews_StudentSectionGradeFact_StudentKey]
ON [analytics].[stg_ews_StudentSectionGradeFact] (
	[StudentKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_ews_StudentSectionGradeFact_SchoolKey]
ON [analytics].[stg_ews_StudentSectionGradeFact] (
	[SchoolKey]	
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_ews_StudentSectionGradeFact_SectionKey]
ON [analytics].[stg_ews_StudentSectionGradeFact] (
	[SectionKey]
) ON [Primary]


CREATE UNIQUE CLUSTERED INDEX [UCX_rls_UserAuthorization]
ON [analytics].[stg_rls_UserAuthorization] (
	[UserKey],
	[UserScope],
	[StudentPermission],
	[SectionPermission],
	[SchoolPermission]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_rls_UserDim]
ON [analytics].[stg_rls_UserDim] (
	[UserKey]
) ON [Primary]


CREATE UNIQUE CLUSTERED INDEX [UCX_rls_UserStudentDataAuthorization]
ON [analytics].[stg_rls_UserStudentDataAuthorization] (
	[UserKey],
	[StudentKey]
) ON [Primary]

----------------------------
-- Drop real tables so they can be replaced by the staging ones
-- (Dropping and then renaming staging tables is much faster
-- than merging records into the real tables)
----------------------------
PRINT 'Dropping live tables...'

DECLARE [AnalyticsTables] CURSOR READ_ONLY FORWARD_ONLY FOR
	SELECT 
		[TABLE_NAME] 
	FROM 
		[INFORMATION_SCHEMA].[TABLES] 
	WHERE 
		[TABLE_SCHEMA] = 'Analytics' 
	AND [TABLE_TYPE] = 'Base Table' 
	AND [TABLE_NAME] NOT LIKE 'stg_%'

DECLARE @TableToDelete as NVARCHAR(128)

OPEN [AnalyticsTables]

FETCH NEXT FROM [AnalyticsTables] INTO @TableToDelete

WHILE @@FETCH_STATUS = 0
BEGIN

	DECLARE @sql NVARCHAR(200) = N'DROP TABLE [analytics].[' + @TableToDelete + N']';
	EXEC sp_executesql @sql;

	FETCH NEXT FROM [AnalyticsTables] INTO @TableToDelete
END

CLOSE [AnalyticsTables]
DEALLOCATE [AnalyticsTables]
GO


----------------------------
-- Rename staging tables to be the real tables
----------------------------
PRINT 'Renaming staging to real tables...'

DECLARE [StagingTables] CURSOR READ_ONLY FORWARD_ONLY FOR
	SELECT 
		[TABLE_NAME] 
	FROM 
		[INFORMATION_SCHEMA].[TABLES] 
	WHERE 
		[TABLE_SCHEMA] = 'Analytics' 
	AND [TABLE_TYPE] = 'Base Table' 
	AND [TABLE_NAME] LIKE 'stg_%'

DECLARE @StagingTable as NVARCHAR(128)

OPEN [StagingTables]

FETCH NEXT FROM [StagingTables] INTO @StagingTable

WHILE @@FETCH_STATUS = 0
BEGIN

	DECLARE @source NVARCHAR(300) = '[analytics].' + @StagingTable
	DECLARE @dest NVARCHAR(128) = REPLACE(@StagingTable, 'stg_', '')
	
	EXEC sp_rename @source, @dest

	FETCH NEXT FROM [StagingTables] INTO @StagingTable
END

CLOSE [StagingTables]
DEALLOCATE [StagingTables]

----------------------------
-- Fake out installation of the base Analytics Middle Tier views - which have
-- been replaced by matieralized tables - so that the EWS views can be 
-- installed using the middle tier installer
----------------------------
PRINT 'Creating fake schema version log...'
IF NOT EXISTS (SELECT 1 FROM [$(DataMartDB)].[INFORMATION_SCHEMA].[TABLES] WHERE [TABLE_NAME] = 'AnalyticsMiddleTierSchemaVersion')
BEGIN

	SELECT * 
	INTO [$(DataMartDB)].[dbo].[AnalyticsMiddleTierSchemaVersion]
	FROM [$(OdsDb)].[dbo].[AnalyticsMiddleTierSchemaVersion]
	WHERE [ScriptName] LIKE 'EdFi.AnalyticsMiddleTier.Lib.Base.%'

	ALTER TABLE [$(DataMartDB)].[dbo].[AnalyticsMiddleTierSchemaVersion] ADD CONSTRAINT [PK_AnalyticsMiddleTierSchemaVersion_Id] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)

END
ELSE
BEGIN
	
	SET IDENTITY_INSERT [$(DataMartDB)].[dbo].[AnalyticsMiddleTierSchemaVersion] ON 

	MERGE INTO [$(DataMartDB)].[dbo].[AnalyticsMiddleTierSchemaVersion] as [Target]
	USING (
		SELECT Id, ScriptName, Applied 
		FROM [$(OdsDb)].[dbo].[AnalyticsMiddleTierSchemaVersion]
		WHERE [ScriptName] LIKE 'EdFi.AnalyticsMiddleTier.Lib.Base.%'
	) AS [Source] (Id, ScriptName, Applied)
	ON [Target].[Id] = [Source].[Id]
	WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, ScriptName, Applied) 
	VALUES (Id, ScriptName, Applied);

	SET IDENTITY_INSERT [$(DataMartDB)].[dbo].[AnalyticsMiddleTierSchemaVersion] OFF

END



PRINT 'All operations complete. Run the Analytics Middle Tier installer to install EWS views.'
GO