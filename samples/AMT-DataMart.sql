-- SPDX-License-Identifier: Apache-2.0
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
:setvar OdsDb EdFi_Ods_Glendale_v510


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
INTO [$(DataMartDB)].[analytics].[stg_AcademicTimePeriodDim]
FROM [$(OdsDb)].[analytics].[AcademicTimePeriodDim]

SELECT * 
INTO [$(DataMartDB)].[analytics].[stg_ClassPeriodDim]
FROM [$(OdsDb)].[analytics].[ClassPeriodDim]

SELECT * 
INTO [$(DataMartDB)].[analytics].[stg_ContactPersonDim]
FROM [$(OdsDb)].[analytics].[ContactPersonDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_DateDim]
FROM [$(OdsDb)].[analytics].[DateDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_DemographicDim]
FROM [$(OdsDb)].[analytics].[DemographicDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_GradingPeriodDim]
FROM [$(OdsDb)].[analytics].[GradingPeriodDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_LocalEducationAgencyDim]
FROM [$(OdsDb)].[analytics].[LocalEducationAgencyDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_MostRecentGradingPeriod]
FROM [$(OdsDb)].[analytics].[MostRecentGradingPeriod]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_SchoolDim]
FROM [$(OdsDb)].[analytics].[SchoolDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_SectionDim]
FROM [$(OdsDb)].[analytics].[SectionDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_StaffSectionDim]
FROM [$(OdsDb)].[analytics].[StaffSectionDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_StudentLocalEducationAgencyDemographicsBridge]
FROM [$(OdsDb)].[analytics].[StudentLocalEducationAgencyDemographicsBridge]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_StudentLocalEducationAgencyDim]
FROM [$(OdsDb)].[analytics].[StudentLocalEducationAgencyDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_StudentProgramDim]
FROM [$(OdsDb)].[analytics].[StudentProgramDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_StudentSchoolDemographicsBridge]
FROM [$(OdsDb)].[analytics].[StudentSchoolDemographicsBridge]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_StudentSchoolDim]
FROM [$(OdsDb)].[analytics].[StudentSchoolDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_StudentSectionDim]
FROM [$(OdsDb)].[analytics].[StudentSectionDim]

-- ASMT Collection. 

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_asmt_AssessmentFact]
FROM [$(OdsDb)].[analytics].[asmt_AssessmentFact]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_asmt_StudentAssessmentFact]
FROM [$(OdsDb)].[analytics].[asmt_StudentAssessmentFact]

-- CHRAB Collection

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_chrab_ChronicAbsenteeismAttendanceFact]
FROM [$(OdsDb)].[analytics].[chrab_ChronicAbsenteeismAttendanceFact]

-- RLS Collection.

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_rls_StudentDataAuthorization]
FROM [$(OdsDb)].[analytics].[rls_StudentDataAuthorization]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_rls_UserAuthorization]
FROM [$(OdsDb)].[analytics].[rls_UserAuthorization]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_rls_UserDim]
FROM [$(OdsDb)].[analytics].[rls_UserDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_rls_UserStudentDataAuthorization]
FROM [$(OdsDb)].[analytics].[rls_UserStudentDataAuthorization]

-- EWS Collection.

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_ews_StudentEarlyWarningFact]
FROM [$(OdsDb)].[analytics].[ews_StudentEarlyWarningFact]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_ews_StudentSectionGradeFact]
FROM [$(OdsDb)].[analytics].[ews_StudentSectionGradeFact]

-- Equity Collection.

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_equity_StudentSchoolFoodServiceProgramDim]
FROM [$(OdsDb)].[analytics].[equity_StudentSchoolFoodServiceProgramDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_equity_FeederSchoolDim]
FROM [$(OdsDb)].[analytics].[equity_FeederSchoolDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_equity_StudentDisciplineActionDim]
FROM [$(OdsDb)].[analytics].[equity_StudentDisciplineActionDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_equity_StudentProgramCohortDim]
FROM [$(OdsDb)].[analytics].[equity_StudentProgramCohortDim]

SELECT *
INTO [$(DataMartDB)].[analytics].[stg_equity_StudentHistoryDim]
FROM [$(OdsDb)].[analytics].[equity_StudentHistoryDim]
GO


----------------------------
-- Add Indexes to Staging Tables
----------------------------
PRINT 'Adding indexes to staging tables...'

CREATE UNIQUE CLUSTERED INDEX [UCX_AcademicTimePeriodDim] 
ON [analytics].[stg_AcademicTimePeriodDim] (
	[AcademicTimePeriodKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_AcademicTimePeriodDim_GradingPeriodKey] 
ON [analytics].[stg_AcademicTimePeriodDim] (
	[GradingPeriodKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_ClassPeriodDim] 
ON [analytics].[stg_ClassPeriodDim] (
	[ClassPeriodKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_ClassPeriodDim_SectionKey] 
ON [analytics].[stg_ClassPeriodDim] (
	[SectionKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_ContactPersonDim] 
ON [analytics].[stg_ContactPersonDim] (
	[UniqueKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_ContactPersonDim_StudentKey] 
ON [analytics].[stg_ContactPersonDim] (
	[StudentKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_DateDim]
ON [analytics].[stg_DateDim] (
	[DateKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_DemographicDim] 
ON [analytics].[stg_DemographicDim] (
	[DemographicKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_GradingPeriodDim]
ON [analytics].[stg_GradingPeriodDim] (
	[GradingPeriodKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_GradingPeriodDim_SchoolKey]
ON [analytics].[stg_GradingPeriodDim] (
	[SchoolKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_LocalEducationAgencyDim]
ON [analytics].[stg_LocalEducationAgencyDim] (
	[LocalEducationAgencyKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_MostRecentGradingPeriod]
ON [analytics].[stg_MostRecentGradingPeriod] (
	[SchoolKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_SchoolDim]
ON [analytics].[stg_SchoolDim] (
	[SchoolKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_SchoolDim_LocalEducationAgencyKey]
ON [analytics].[stg_SchoolDim] (
	[LocalEducationAgencyKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_SchoolDim_StateEducationAgencyKey]
ON [analytics].[stg_SchoolDim] (
	[StateEducationAgencyKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_SectionDim]
ON [analytics].[stg_SectionDim] (
	[SectionKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_SectionDim_SchoolKey]
ON [analytics].[stg_SectionDim] (
	[SchoolKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_StaffSectionDim]
ON [analytics].[stg_StaffSectionDim] (
	[StaffSectionKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StaffSectionDim_SchoolKey]
ON [analytics].[stg_StaffSectionDim] (
	[SchoolKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StaffSectionDim_SectionKey]
ON [analytics].[stg_StaffSectionDim] (
	[SectionKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StudentLocalEducationAgencyDemographicsBridge_StudentSchoolDemographicBridgeKey]
ON [analytics].[stg_StudentLocalEducationAgencyDemographicsBridge] (
	[StudentSchoolDemographicBridgeKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_StudentLocalEducationAgencyDim]
ON [analytics].[stg_StudentLocalEducationAgencyDim] (
	[StudentLocalEducationAgencyKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StudentLocalEducationAgencyDim_StudentKey]
ON [analytics].[stg_StudentLocalEducationAgencyDim] (
	[StudentKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_StudentProgramDim]
ON [analytics].[stg_StudentProgramDim] (
	[StudentSchoolProgramKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StudentProgramDim_StudentKey]
ON [analytics].[stg_StudentProgramDim] (
	[StudentKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StudentProgramDim_SchoolKey]
ON [analytics].[stg_StudentProgramDim] (
	[SchoolKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StudentProgramDim_StudentSchoolKey]
ON [analytics].[stg_StudentProgramDim] (
	[StudentSchoolKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StudentSchoolDemographicsBridge_StudentSchoolDemographicBridgeKey]
ON [analytics].[stg_StudentSchoolDemographicsBridge] (
	[StudentSchoolDemographicBridgeKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_StudentSchoolDim]
ON [analytics].[stg_StudentSchoolDim] (
	[StudentSchoolKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StudentSchoolDim_StudentKey]
ON [analytics].[stg_StudentSchoolDim] (
	[StudentKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StudentSchoolDim_SchoolKey]
ON [analytics].[stg_StudentSchoolDim] (
	[SchoolKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_StudentSectionDim]
ON [analytics].[stg_StudentSectionDim] (
	[StudentSectionKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StudentSectionDim_SchoolKey]
ON [analytics].[stg_StudentSectionDim] (
	[SchoolKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StudentSectionDim_StudentKey]
ON [analytics].[stg_StudentSectionDim] (
	[StudentKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_StudentSectionDim_SectionKey]
ON [analytics].[stg_StudentSectionDim] (
	[SectionKey]
) ON [Primary]

CREATE INDEX [IX_StudentSectionDim_StudentSectionKey] ON
	[analytics].[stg_StudentSectionDim]
(
	[StudentKey],
	[StudentSectionKey],
	[Subject],
	[SchoolKey]
) ON [Primary]

-- ASMT Collection

CREATE UNIQUE CLUSTERED INDEX [UCX_asmt_AssessmentFact]
ON [analytics].[stg_asmt_AssessmentFact] (
	[AssessmentFactKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_asmt_AssessmentFact_AssessmentKey]
ON [analytics].[stg_asmt_AssessmentFact] (
	[AssessmentKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_asmt_StudentAssessmentFact]
ON [analytics].[stg_asmt_StudentAssessmentFact] (
	[StudentAssessmentFactKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_asmt_StudentAssessmentFact_StudentAssessmentKey]
ON [analytics].[stg_asmt_StudentAssessmentFact] (
	[StudentAssessmentKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_asmt_StudentAssessmentFact_AssessmentKey]
ON [analytics].[stg_asmt_StudentAssessmentFact] (
	[AssessmentKey]
) ON [Primary]


-- CHRAB Collection

CREATE UNIQUE CLUSTERED INDEX [UCX_chrab_ChronicAbsenteeismAttendanceFact]
ON [analytics].[stg_chrab_ChronicAbsenteeismAttendanceFact] (
	[StudentSchoolKey],
	[DateKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_chrab_ChronicAbsenteeismAttendanceFact_StudentKey]
ON [analytics].[stg_chrab_ChronicAbsenteeismAttendanceFact] (
	[StudentKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_chrab_ChronicAbsenteeismAttendanceFact_SchoolKey]
ON [analytics].[stg_chrab_ChronicAbsenteeismAttendanceFact] (
	[SchoolKey]
) ON [Primary]

-- RLS Collection

CREATE UNIQUE CLUSTERED INDEX [UCX_rls_StudentDataAuthorization]
ON [analytics].[stg_rls_StudentDataAuthorization] (
	[StudentKey],
	[SchoolKey],
	[BeginDate],
	[EndDate],
	[SectionId]
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

-- EWS Collection

CREATE UNIQUE CLUSTERED INDEX [UCX_ews_StudentEarlyWarningFact]
ON [analytics].[stg_ews_StudentEarlyWarningFact] (
	[StudentKey],
	[SchoolKey],
	[DateKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_ews_StudentEarlyWarningFact_SchoolKey]
ON [analytics].[stg_ews_StudentEarlyWarningFact] (
	[SchoolKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_ews_StudentEarlyWarningFact_DateKey]
ON [analytics].[stg_ews_StudentEarlyWarningFact] (
	[DateKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_ews_StudentSectionGradeFact]
ON [analytics].[stg_ews_StudentSectionGradeFact] (
	[StudentSectionKey],
	[GradingPeriodKey],
	[GradeType]
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

CREATE NONCLUSTERED INDEX [IX_ews_StudentSectionGradeFact_GradingPeriodKey]
ON [analytics].[stg_ews_StudentSectionGradeFact] (
	[GradingPeriodKey]
) ON [Primary]

-- Equity Collection

CREATE UNIQUE CLUSTERED INDEX [UCX_equity_FeederSchoolDim]
ON [analytics].[stg_equity_FeederSchoolDim] (
	[FeederSchoolUniqueKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_equity_FeederSchoolDim_SchoolKey]
ON [analytics].[stg_equity_FeederSchoolDim] (
	[SchoolKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_equity_FeederSchoolDim_FeederSchoolKey]
ON [analytics].[stg_equity_FeederSchoolDim] (
	[FeederSchoolKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_equity_StudentDisciplineActionDim]
ON [analytics].[stg_equity_StudentDisciplineActionDim] (
	[StudentDisciplineActionKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_equity_StudentDisciplineActionDim_StudentSchoolKey]
ON [analytics].[stg_equity_StudentDisciplineActionDim] (
	[StudentSchoolKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_equity_StudentDisciplineActionDim_DisciplineDateKey]
ON [analytics].[stg_equity_StudentDisciplineActionDim] (
	[DisciplineDateKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_equity_StudentSchoolFoodServiceProgramDim]
ON [analytics].[stg_equity_StudentSchoolFoodServiceProgramDim] (
	[StudentSchoolFoodServiceProgramKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_equity_StudentSchoolFoodServiceProgramDim_StudentSchoolProgramKey]
ON [analytics].[stg_equity_StudentSchoolFoodServiceProgramDim] (
	[StudentSchoolProgramKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_equity_StudentProgramCohortDim]
ON [analytics].[stg_equity_StudentProgramCohortDim] (
	[StudentProgramCohortKey]
) ON [Primary]

CREATE NONCLUSTERED INDEX [IX_equity_StudentProgramCohortDim_StudentSchoolProgramKey]
ON [analytics].[stg_equity_StudentProgramCohortDim] (
	[StudentSchoolProgramKey]
) ON [Primary]

CREATE UNIQUE CLUSTERED INDEX [UCX_equity_StudentHistoryDim]
ON [analytics].[stg_equity_StudentHistoryDim] (
	[StudentSchoolKey]
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

-----------------------------------------------------------------------------------------

-- This script contains a final section that is commented out. 
-- Uncomment it when you need to combine the data from 2 different Ods sources. 
-- Additionally you have to set the SecondOdsDb variable below 
/*
:setvar SecondOdsDb EdFi_Ods_Northridge_v510

-- Second ODS
USE [$(DataMartDB)]
GO

----------------------------
-- Populate Tables from Second Ods
----------------------------

INSERT INTO [$(DataMartDB)].[analytics].[AcademicTimePeriodDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[AcademicTimePeriodDim]

INSERT INTO [$(DataMartDB)].[analytics].[ClassPeriodDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[ClassPeriodDim]

INSERT INTO [$(DataMartDB)].[analytics].[ContactPersonDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[ContactPersonDim]

INSERT INTO [$(DataMartDB)].[analytics].[DateDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[DateDim]

INSERT INTO [$(DataMartDB)].[analytics].[DemographicDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[DemographicDim]

INSERT INTO [$(DataMartDB)].[analytics].[GradingPeriodDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[GradingPeriodDim]

INSERT INTO [$(DataMartDB)].[analytics].[LocalEducationAgencyDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[LocalEducationAgencyDim]

INSERT INTO [$(DataMartDB)].[analytics].[MostRecentGradingPeriod]
SELECT * FROM [$(SecondOdsDb)].[analytics].[MostRecentGradingPeriod]

INSERT INTO [$(DataMartDB)].[analytics].[SchoolDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[SchoolDim]

INSERT INTO [$(DataMartDB)].[analytics].[SectionDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[SectionDim]

INSERT INTO [$(DataMartDB)].[analytics].[StaffSectionDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[StaffSectionDim]

INSERT INTO [$(DataMartDB)].[analytics].[StudentLocalEducationAgencyDemographicsBridge]
SELECT * FROM [$(SecondOdsDb)].[analytics].[StudentLocalEducationAgencyDemographicsBridge]

INSERT INTO [$(DataMartDB)].[analytics].[StudentLocalEducationAgencyDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[StudentLocalEducationAgencyDim]

INSERT INTO [$(DataMartDB)].[analytics].[StudentProgramDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[StudentProgramDim]

INSERT INTO [$(DataMartDB)].[analytics].[StudentSchoolDemographicsBridge]
SELECT * FROM [$(SecondOdsDb)].[analytics].[StudentSchoolDemographicsBridge]

INSERT INTO [$(DataMartDB)].[analytics].[StudentSchoolDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[StudentSchoolDim]

INSERT INTO [$(DataMartDB)].[analytics].[StudentSectionDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[StudentSectionDim]

-- ASMT Collection. 

INSERT INTO [$(DataMartDB)].[analytics].[asmt_AssessmentFact]
SELECT * FROM [$(SecondOdsDb)].[analytics].[asmt_AssessmentFact]

INSERT INTO [$(DataMartDB)].[analytics].[asmt_StudentAssessmentFact]
SELECT * FROM [$(SecondOdsDb)].[analytics].[asmt_StudentAssessmentFact]

-- RLS Collection.

INSERT INTO [$(DataMartDB)].[analytics].[rls_StudentDataAuthorization]
SELECT * FROM [$(SecondOdsDb)].[analytics].[rls_StudentDataAuthorization]

INSERT INTO [$(DataMartDB)].[analytics].[rls_UserAuthorization]
SELECT * FROM [$(SecondOdsDb)].[analytics].[rls_UserAuthorization]

INSERT INTO [$(DataMartDB)].[analytics].[rls_UserDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[rls_UserDim]

INSERT INTO [$(DataMartDB)].[analytics].[rls_UserStudentDataAuthorization]
SELECT * FROM [$(SecondOdsDb)].[analytics].[rls_UserStudentDataAuthorization]

-- EWS Collection.

INSERT INTO [$(DataMartDB)].[analytics].[ews_StudentEarlyWarningFact]
SELECT * FROM [$(SecondOdsDb)].[analytics].[ews_StudentEarlyWarningFact]

INSERT INTO [$(DataMartDB)].[analytics].[ews_StudentSectionGradeFact]
SELECT * FROM [$(SecondOdsDb)].[analytics].[ews_StudentSectionGradeFact]

-- Equity Collection.

INSERT INTO [$(DataMartDB)].[analytics].[equity_StudentSchoolFoodServiceProgramDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[equity_StudentSchoolFoodServiceProgramDim]

INSERT INTO [$(DataMartDB)].[analytics].[equity_FeederSchoolDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[equity_FeederSchoolDim]

INSERT INTO [$(DataMartDB)].[analytics].[equity_StudentDisciplineActionDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[equity_StudentDisciplineActionDim]

INSERT INTO [$(DataMartDB)].[analytics].[equity_StudentProgramCohortDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[equity_StudentProgramCohortDim]

INSERT INTO [$(DataMartDB)].[analytics].[equity_StudentHistoryDim]
SELECT * FROM [$(SecondOdsDb)].[analytics].[equity_StudentHistoryDim]

-- CHRAB Collection

INSERT INTO [$(DataMartDB)].[analytics].[chrab_ChronicAbsenteeismAttendanceFact]
SELECT * FROM [$(SecondOdsDb)].[analytics].[chrab_ChronicAbsenteeismAttendanceFact]
GO
*/
-----------------------------------------------------------------------------------------

PRINT 'All operations complete. Run the Analytics Middle Tier installer to install EWS views.'
GO 