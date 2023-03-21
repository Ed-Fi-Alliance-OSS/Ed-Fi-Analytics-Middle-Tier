-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE PROCEDURE analytics_config.rls_RemoveStaffClassificationDescriptorScope(
	StaffDescriptor VARCHAR(50) = NULL,
	StaffDescriptorId INT = NULL,
	Scope VARCHAR(50) = NULL,
	ScopeID INT = NULL
)
LANGUAGE plpgsql
AS $$
	--
	-- Missing argument error handling
	--
	
	DECLARE
	   StaffDescriptorIsSet BOOLEAN;
	   ScopeIsSet BOOLEAN;
	BEGIN
		CASE
			WHEN StaffDescriptor IS NULL AND StaffDescriptorId IS NULL 
			THEN StaffDescriptorIsSet = FALSE;
			ELSE StaffDescriptorIsSet = TRUE;
		END CASE;

		CASE 
			WHEN Scope IS NULL AND ScopeID IS NULL 
			THEN ScopeIsSet = FALSE;
			ELSE ScopeIsSet = TRUE;
		END CASE;

		IF (StaffDescriptorIsSet = FALSE) THEN
			RAISE EXCEPTION 'Must pass in a value for either StaffDescriptor or StaffDescriptorId';
		END IF;

		IF (ScopeIsSet = FALSE) THEN
			RAISE EXCEPTION 'Must pass in a value for either Scope or ScopeID';
		END IF;

		--
		-- Invalid argument error handling
		--
		IF NOT EXISTS(
			SELECT 1 
			FROM 
				edfi.StaffClassificationDescriptor
			INNER JOIN
				edfi.Descriptor ON 
					StaffClassificationDescriptor.StaffClassificationDescriptorId = Descriptor.DescriptorId
			WHERE
				Descriptor.CodeValue = StaffDescriptor
			OR	Descriptor.DescriptorId = StaffDescriptorId
		) THEN
			DECLARE descriptors TEXT := 'Invalid staff classification descriptor. Valid values are (Id, Value):';
			BEGIN
				descriptors := descriptors || STRING_AGG(
					CHR(10) || CAST(Descriptor.DescriptorId as TEXT) || ', ' || Descriptor.CodeValue, ' ')
				FROM 
					edfi.StaffClassificationDescriptor
				INNER JOIN
					edfi.Descriptor ON 
						StaffClassificationDescriptor.StaffClassificationDescriptorId = Descriptor.DescriptorId;

				RAISE EXCEPTION '%', descriptors;
			END;
		END IF;

		IF NOT EXISTS(
			SELECT 1 
			FROM 
				analytics_config.DescriptorConstant
			WHERE
				(DescriptorConstant.ConstantName = Scope
					OR	DescriptorConstantId = ScopeId)
				AND ConstantName IN('AuthorizationScope.District', 'AuthorizationScope.School', 'AuthorizationScope.Section')
		) THEN
			DECLARE scopes TEXT := 'Invalid authorization scope. Valid values are (Id, Value):';
			BEGIN
				scopes := scopes || STRING_AGG( 
					CHR(10) || CAST(DescriptorConstantId as TEXT) || ', ' || ConstantName, ' ')
				FROM 
					analytics_config.DescriptorConstant
				WHERE ConstantName IN('AuthorizationScope.District', 'AuthorizationScope.School', 'AuthorizationScope.Section');

				RAISE EXCEPTION '%', scopes;
			END;
		END IF;

		--
		-- Set ID variables if input parameters were provided instead of IDs
		--
		IF (ScopeID IS NULL) THEN
			ScopeID := DescriptorConstantId 
			FROM 
				analytics_config.DescriptorConstant 
			WHERE
				ConstantName = Scope;
		END IF;

		IF (StaffDescriptorId IS NULL) THEN
			StaffDescriptorId := DescriptorId
			FROM 
				edfi.StaffClassificationDescriptor
			INNER JOIN
				edfi.Descriptor ON 
					StaffClassificationDescriptor.StaffClassificationDescriptorId = Descriptor.DescriptorId
			WHERE
				CodeValue = StaffDescriptor;
		END IF;

		--
		-- Restore row count so the user will get feedback.
		--

		DELETE FROM 
			analytics_config.DescriptorMap
		WHERE 
			DescriptorMap.DescriptorConstantId = ScopeID
		AND DescriptorMap.DescriptorId = StaffDescriptorId;

	END
$$;