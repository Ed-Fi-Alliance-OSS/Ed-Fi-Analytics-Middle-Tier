-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE VIEW analytics.StudentInternetAccessDim
AS

	SELECT
		FORMAT(
			'%s-%s',
			Student.StudentUniqueId,
			CAST(edorg.EducationOrganizationId as VARCHAR)
		) as StudentSchoolKey,
		CAST(edorg.EducationOrganizationId as VARCHAR) as SchoolKey,
		COALESCE(InternetAccessInResidence.Indicator,'n/a') as InternetAccessInResidence,
		COALESCE(InternetAccessTypeInResidence.Indicator,'n/a') as InternetAccessTypeInResidence,
		COALESCE(InternetPerformance.Indicator,'n/a') as InternetPerformance,
		COALESCE(DigitalDevice.Indicator,'n/a') as DigitalDevice,
		COALESCE(DeviceAccess.Indicator,'n/a') as DeviceAccess
	FROM
		edfi.Student

	INNER JOIN
		edfi.StudentEducationOrganizationAssociation as edorg
	ON
		Student.StudentUSI = edorg.StudentUSI

	INNER JOIN
		edfi.School
	ON
		edorg.EducationOrganizationId = School.SchoolId

	LEFT OUTER JOIN
		edfi.StudentEducationOrganizationAssociationStudentIndicator as InternetAccessInResidence
	ON
		edorg.StudentUSI = InternetAccessInResidence.StudentUSI
	AND
		edorg.EducationOrganizationId = InternetAccessInResidence.EducationOrganizationId

	LEFT OUTER JOIN
		edfi.StudentEducationOrganizationAssociationStudentIndicator as InternetAccessTypeInResidence
	ON
		edorg.StudentUSI = InternetAccessTypeInResidence.StudentUSI
	AND
		edorg.EducationOrganizationId = InternetAccessTypeInResidence.EducationOrganizationId

	LEFT OUTER JOIN
		edfi.StudentEducationOrganizationAssociationStudentIndicator as InternetPerformance
	ON
		edorg.StudentUSI = InternetPerformance.StudentUSI
	AND
		edorg.EducationOrganizationId = InternetPerformance.EducationOrganizationId

	LEFT OUTER JOIN
		edfi.StudentEducationOrganizationAssociationStudentIndicator as DigitalDevice
	ON
		edorg.StudentUSI = DigitalDevice.StudentUSI
	AND
		edorg.EducationOrganizationId = DigitalDevice.EducationOrganizationId

	LEFT OUTER JOIN
		edfi.StudentEducationOrganizationAssociationStudentIndicator as DeviceAccess
	ON
		edorg.StudentUSI = DeviceAccess.StudentUSI
	AND
		edorg.EducationOrganizationId = DeviceAccess.EducationOrganizationId

	WHERE
		(InternetAccessInResidence.StudentUSI IS NULL or InternetAccessInResidence.IndicatorName = 'InternetAccessInResidence')
	AND
		(InternetAccessTypeInResidence.StudentUSI IS NULL or InternetAccessTypeInResidence.IndicatorName = 'InternetAccessTypeInResidence')
	AND
		(InternetPerformance.StudentUSI IS NULL or InternetPerformance.IndicatorName = 'InternetPerformance')
	AND
		(DigitalDevice.StudentUSI IS NULL or DigitalDevice.IndicatorName = 'DigitalDevice')
	AND
		(DeviceAccess.StudentUSI IS NULL or DeviceAccess.IndicatorName = 'DeviceAccess');
