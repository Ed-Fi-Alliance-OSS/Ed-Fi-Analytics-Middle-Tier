-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'LocalEducationAgencyDim')
BEGIN
	DROP VIEW analytics.LocalEducationAgencyDim
END
GO

CREATE VIEW analytics.LocalEducationAgencyDim AS

	SELECT
		CAST(EducationOrganization.EducationOrganizationId AS VARCHAR) as LocalEducationAgencyKey,
		EducationOrganization.NameOfInstitution as LocalEducationAgencyName,
		ISNULL(LocalEducationAgencyCategoryType.CodeValue, '') as LocalEducationAgencyType,
		COALESCE(CAST(LocalEducationAgency.ParentLocalEducationAgencyId AS VARCHAR),'') as LocalEducationAgencyParentLocalEducationAgencyKey,
		ISNULL(StateEducationAgency.NameOfInstitution, '') as LocalEducationAgencyStateEducationAgencyName,
		COALESCE(CAST(LocalEducationAgency.StateEducationAgencyId AS VARCHAR), '') as LocalEducationAgencyStateEducationAgencyKey,
		ISNULL(EducationServiceCenter.NameOfInstitution, '') as LocalEducationAgencyServiceCenterName,
		COALESCE(CAST(EducationServiceCenter.EducationOrganizationId AS VARCHAR), '') as LocalEducationAgencyServiceCenterKey,
		ISNULL(CharterStatusType.CodeValue, '') as LocalEducationAgencyCharterStatus,
		(
			SELECT
				MAX(MaxLastModifiedDate)
			FROM (VALUES (EducationOrganization.LastModifiedDate)
						,(EducationServiceCenter.LastModifiedDate)
						, (StateEducationAgency.LastModifiedDate)
			) AS VALUE (MaxLastModifiedDate)
		) AS LastModifiedDate
	FROM
		edfi.EducationOrganization
	INNER JOIN
		edfi.LocalEducationAgency ON
			EducationOrganization.EducationOrganizationId = LocalEducationAgency.LocalEducationAgencyId
	LEFT OUTER JOIN
		edfi.Descriptor as LocalEducationAgencyCategoryType ON
			LocalEducationAgency.LocalEducationAgencyCategoryDescriptorId = LocalEducationAgencyCategoryType.DescriptorId
	LEFT OUTER JOIN
		edfi.EducationOrganization as EducationServiceCenter ON
			LocalEducationAgency.EducationServiceCenterId = EducationServiceCenter.EducationOrganizationId
	LEFT OUTER JOIN
		edfi.Descriptor as CharterStatusType ON
			LocalEducationAgency.CharterStatusDescriptorId = CharterStatusType.DescriptorId
	LEFT OUTER JOIN
		edfi.EducationOrganization as StateEducationAgency ON
			LocalEducationAgency.StateEducationAgencyId = StateEducationAgency.EducationOrganizationId
GO
