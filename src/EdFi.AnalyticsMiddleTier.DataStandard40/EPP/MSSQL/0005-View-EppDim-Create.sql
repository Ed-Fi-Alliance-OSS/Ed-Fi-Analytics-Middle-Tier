-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('analytics.EPP_EppDim') IS NOT NULL
	DROP VIEW analytics.EPP_EppDim

GO

CREATE VIEW analytics.EPP_EppDim AS

---EPP
SELECT 
	CAST(EducationOrganization.EducationOrganizationId AS VARCHAR) AS EducationOrganizationKey
	,NameOfInstitution
	,EducationOrganization.LastModifiedDate
FROM
	edfi.EducationOrganization
JOIN
	edfi.EducationOrganizationCategory
		ON EducationOrganization.EducationOrganizationId = EducationOrganizationCategory.EducationOrganizationId
JOIN
	edfi.Descriptor
		ON EducationOrganizationCategory.EducationOrganizationCategoryDescriptorId = Descriptor.DescriptorId
WHERE
	Descriptor.CodeValue like '%Preparation Provider%';