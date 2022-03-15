-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS analytics.EPP_EppDim;

CREATE VIEW analytics.EPP_EppDim AS

---EPP
SELECT
	EducationOrganization.EducationOrganizationId AS EducationOrganizationKey
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