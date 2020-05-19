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
		EducationOrganization.EducationOrganizationId as LocalEducationAgencyKey,
		EducationOrganization.NameOfInstitution as LocalEducationAgencyName,
		ISNULL(LocalEducationAgencyCategoryType.CodeValue, '') as LocalEducationAgencyType,
		LocalEducationAgency.ParentLocalEducationAgencyId as LocalEducationAgencyParentLocalEducationAgencyKey,
		ISNULL(StateEducationAgency.NameOfInstitution, '') as LocalEducationAgencyStateEducationAgencyName,
		LocalEducationAgency.StateEducationAgencyId as LocalEducationAgencyStateEducationAgencyKey,
		ISNULL(EducationServiceCenter.NameOfInstitution, '') as LocalEducationAgencyServiceCenterName,
		EducationServiceCenter.EducationOrganizationId as LocalEducationAgencyServiceCenterKey,
		ISNULL(CharterStatusType.CodeValue, '') as LocalEducationAgencyCharterStatus,
		(
			SELECT
				MAX(MaxLastModifiedDate)
			FROM (VALUES (EducationOrganization.LastModifiedDate)
						,(EducationServiceCenter.LastModifiedDate)
						,(StateEducationAgency.LastModifiedDate)
			) AS VALUE (MaxLastModifiedDate)
		) AS LastModifiedDate
	FROM
		edfi.EducationOrganization
	INNER JOIN
		edfi.LocalEducationAgency ON
			EducationOrganization.EducationOrganizationId = LocalEducationAgency.LocalEducationAgencyId
	LEFT OUTER JOIN
		edfi.LocalEducationAgencyCategoryType ON
			LocalEducationAgency.LocalEducationAgencyCategoryTypeId = LocalEducationAgencyCategoryType.LocalEducationAgencyCategoryTypeId
	LEFT OUTER JOIN
		edfi.EducationOrganization as EducationServiceCenter ON
			LocalEducationAgency.EducationServiceCenterId = EducationServiceCenter.EducationOrganizationId
	LEFT OUTER JOIN
		edfi.CharterStatusType ON
			LocalEducationAgency.CharterStatusTypeId = CharterStatusType.CharterStatusTypeId
	LEFT OUTER JOIN
		edfi.EducationOrganization as StateEducationAgency ON
			LocalEducationAgency.StateEducationAgencyId = StateEducationAgency.EducationOrganizationId
GO
