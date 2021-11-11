-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.VIEWS
		WHERE TABLE_SCHEMA = 'analytics_config'
			AND TABLE_NAME = 'rls_StaffClassificationDescriptorScopeList'
		)
BEGIN
	DROP VIEW analytics_config.rls_StaffClassificationDescriptorScopeList
END
GO

CREATE VIEW [analytics_config].rls_StaffClassificationDescriptorScopeList
AS
	SELECT DescriptorConstant.ConstantName AS AuthorizationScopeName
		,Descriptor.CodeValue
	FROM analytics_config.DescriptorConstant
	INNER JOIN 
		analytics_config.DescriptorMap
		ON DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
	INNER JOIN 
		edfi.Descriptor
		ON DescriptorMap.DescriptorId = Descriptor.DescriptorId
	WHERE DescriptorConstant.ConstantName IN (
			'AuthorizationScope.District'
			,'AuthorizationScope.School'
			,'AuthorizationScope.Section'
			)
