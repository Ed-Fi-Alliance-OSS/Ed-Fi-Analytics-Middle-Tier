-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'SchoolDim')
BEGIN
	DROP VIEW analytics.SchoolDim
END
GO

CREATE VIEW analytics.SchoolDim AS

	SELECT 
		CAST(School.SchoolId AS VARCHAR) as SchoolKey,
		EducationOrganization.NameOfInstitution as SchoolName,
		COALESCE(SchoolType.CodeValue, '') as SchoolType,
		COALESCE(SchoolAddress.SchoolAddress, '') as SchoolAddress,
		COALESCE(SchoolAddress.SchoolCity, '') as SchoolCity,
		COALESCE(SchoolAddress.SchoolCounty, '') as SchoolCounty,
		COALESCE(SchoolAddress.SchoolState, '') as SchoolState,
		COALESCE(EdOrgLocal.NameOfInstitution, '') as LocalEducationAgencyName,
		EdOrgLocal.EducationOrganizationId as LocalEducationAgencyKey,
		COALESCE(EdOrgState.NameOfInstitution, '') as StateEducationAgencyName,
		EdOrgState.EducationOrganizationId as StateEducationAgencyKey,
		COALESCE(EdOrgServiceCenter.NameOfInstitution, '') as EducationServiceCenterName,
		EdOrgServiceCenter.EducationOrganizationId as EducationServiceCenterKey,
		(	SELECT 
				MAX(MaxLastModifiedDate)
			FROM (VALUES (EducationOrganization.LastModifiedDate)
						,(SchoolType.LastModifiedDate)
						,(EdOrgLocal.LastModifiedDate)
						,(EdOrgState.LastModifiedDate)
						,(EdOrgServiceCenter.LastModifiedDate)
						,(SchoolAddress.LastModifiedDate)
				 ) AS VALUE (MaxLastModifiedDate)
		) AS LastModifiedDate
	FROM 
		edfi.School
	INNER JOIN 
		edfi.EducationOrganization
	  ON School.SchoolId = EducationOrganization.EducationOrganizationId
	LEFT OUTER JOIN
		edfi.Descriptor as SchoolType
	  ON School.SchoolTypeDescriptorId = SchoolType.DescriptorId
	LEFT OUTER JOIN 
		edfi.LocalEducationAgency
	  ON School.LocalEducationAgencyId = LocalEducationAgency.LocalEducationAgencyId
	LEFT OUTER JOIN 
		edfi.EducationOrganization as EdOrgLocal
	  ON School.LocalEducationAgencyId = EdOrgLocal.EducationOrganizationId
	LEFT OUTER JOIN 
		edfi.EducationOrganization as EdOrgState
	  ON LocalEducationAgency.StateEducationAgencyId = EdOrgState.EducationOrganizationId
	LEFT OUTER JOIN 
		edfi.EducationOrganization as EdOrgServiceCenter
	  ON LocalEducationAgency.EducationServiceCenterId = EdOrgServiceCenter.EducationOrganizationId
	OUTER APPLY (
		SELECT TOP 1
			CONCAT(EducationOrganizationAddress.StreetNumberName, ', ',
				(EducationOrganizationAddress.ApartmentRoomSuiteNumber + ', '),
				EducationOrganizationAddress.City,
				StateAbbreviationType.CodeValue, ' ',
				EducationOrganizationAddress.PostalCode) as SchoolAddress,
			EducationOrganizationAddress.City as SchoolCity,
			EducationOrganizationAddress.NameOfCounty as SchoolCounty,
			StateAbbreviationType.CodeValue as SchoolState,
			EducationOrganizationAddressPeriod.BeginDate as LastModifiedDate
		FROM
			edfi.EducationOrganizationAddress
		INNER JOIN
			edfi.Descriptor as AddressType
		  ON EducationOrganizationAddress.AddressTypeDescriptorId = AddressType.DescriptorId
		INNER JOIN
			edfi.EducationOrganizationAddressPeriod
		  ON EducationOrganizationAddress.AddressTypeDescriptorId = EducationOrganizationAddressPeriod.AddressTypeDescriptorId
		  AND EducationOrganizationAddress.EducationOrganizationId = EducationOrganizationAddressPeriod.EducationOrganizationId
		INNER JOIN
			edfi.Descriptor as StateAbbreviationType
		  ON EducationOrganizationAddress.StateAbbreviationDescriptorId = StateAbbreviationType.DescriptorId
         INNER JOIN
              analytics_config.DescriptorMap
           ON AddressType.DescriptorId = DescriptorMap.DescriptorId
         INNER JOIN
              analytics_config.DescriptorConstant
           ON DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
		WHERE 
			School.SchoolId = EducationOrganizationAddress.EducationOrganizationId
			AND EducationOrganizationAddressPeriod.EndDate IS NULL
			AND DescriptorConstant.ConstantName = 'Address.Physical'
	) as SchoolAddress
GO
