-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE PROC analytics_config.rls_InsertStaffClassificationDescriptorScope (
	@StaffDescriptor NVARCHAR(50) = NULL,
	@StaffDescriptorId INT = NULL,
	@Scope VARCHAR(50) = NULL,
	@ScopeID INT = NULL
	)
AS
BEGIN
	SET NOCOUNT ON;

	--
	-- Missing argument error handling
	--
	DECLARE @StaffDescriptorIsSet BIT,
		@ScopeIsSet BIT;

	SELECT @StaffDescriptorIsSet =  CASE 
									WHEN @StaffDescriptor IS NULL
										AND @StaffDescriptorId IS NULL
										THEN 0
									ELSE 1
									END;

	SELECT @ScopeIsSet =	CASE 
							WHEN @Scope IS NULL
								AND @ScopeID IS NULL
								THEN 0
							ELSE 1
							END;

	IF (@StaffDescriptorIsSet = 0)
	BEGIN
		THROW 51000,
			'Must pass in a value for either @StaffDescriptor or @StaffDescriptorId',
			1;
	END;

	IF (@ScopeIsSet = 0)
	BEGIN
		THROW 51001,
			'Must pass in a value for either @Scope or @ScopeID',
			1;
	END;

	--
	-- Invalid argument error handling
	--
	IF NOT EXISTS (
			SELECT 1
			FROM 
				[edfi].[StaffClassificationDescriptor]
			INNER JOIN 
				[edfi].[Descriptor]
				ON [StaffClassificationDescriptor].[StaffClassificationDescriptorId] = [Descriptor].[DescriptorId]
			WHERE [Descriptor].[CodeValue] = @StaffDescriptor
				OR [Descriptor].[DescriptorId] = @StaffDescriptorId
			)
	BEGIN
		DECLARE @descriptors AS NVARCHAR(MAX) = 'Invalid staff classification descriptor. Valid values are (Id, Value):';

		SELECT @descriptors = @descriptors + CHAR(10) + CAST([Descriptor].[DescriptorId] AS NVARCHAR) + ', ' + [Descriptor].[CodeValue]
		FROM 
			[edfi].[StaffClassificationDescriptor]
		INNER JOIN 
			[edfi].[Descriptor]
			ON [StaffClassificationDescriptor].[StaffClassificationDescriptorId] = [Descriptor].[DescriptorId];

		THROW 51002,
			@descriptors,
			1;
	END;

	--At the moment only values corresponding to AuthorizationScope are allowed
	IF NOT EXISTS (
			SELECT 1
			FROM 
				analytics_config.DescriptorConstant
			WHERE DescriptorConstant.ConstantName IN (
					'AuthorizationScope.District',
					'AuthorizationScope.School',
					'AuthorizationScope.Section'
					)
				AND (
					DescriptorConstant.ConstantName = @Scope
					OR DescriptorConstantId = @ScopeId
					)
			)
	BEGIN
		DECLARE @scopes AS NVARCHAR(MAX) = 'Invalid authorization scope. Valid values are (Id, Value):';

		SELECT @scopes = @scopes + CHAR(10) + CAST([DescriptorConstantId] AS NVARCHAR) + ', ' + DescriptorConstant.ConstantName
		FROM 
			[analytics_config].DescriptorConstant
		WHERE DescriptorConstant.ConstantName IN (
				'AuthorizationScope.District',
				'AuthorizationScope.School',
				'AuthorizationScope.Section'
				);

		THROW 51003,
			@scopes,
			1;
	END;

	--
	-- Set ID variables if input parameters were provided instead of IDs
	--
	IF (@ScopeID IS NULL)
	BEGIN
		SELECT @ScopeID = DescriptorConstantId
		FROM 
			[analytics_config].DescriptorConstant
		WHERE ConstantName = @Scope
			OR DescriptorConstantId = @ScopeId;
	END;

	IF (@StaffDescriptorId IS NULL)
	BEGIN
		SELECT @StaffDescriptorId = [DescriptorId]
		FROM 
			[edfi].[StaffClassificationDescriptor]
		INNER JOIN 
			[edfi].[Descriptor]
			ON [StaffClassificationDescriptor].[StaffClassificationDescriptorId] = [Descriptor].[DescriptorId]
		WHERE [CodeValue] = @StaffDescriptor;
	END;

	--
	-- Merge the new values into the destination table, so we don't risk getting duplicates.
	-- Restore row count so the user will get feedback.
	--
	SET NOCOUNT OFF;

	MERGE INTO [analytics_config].[DescriptorMap] AS [Target]
	USING (
		VALUES (
			@ScopeID,
			@StaffDescriptorId
			)
		) AS [Source](DescriptorConstantId, DescriptorId)
		ON [Target].DescriptorConstantId = [Source].DescriptorConstantId
			AND [Target].DescriptorId = [Source].DescriptorId
	WHEN NOT MATCHED BY TARGET
		THEN
			INSERT (
				DescriptorConstantId,
				DescriptorId,
				CreateDate
				)
			VALUES (
				DescriptorConstantId,
				DescriptorId,
				GETDATE()
				);
END;