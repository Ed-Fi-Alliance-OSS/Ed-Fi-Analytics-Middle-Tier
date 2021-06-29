-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'equity_StudentSchoolFoodServiceProgramDim')
BEGIN
	DROP VIEW analytics.equity_StudentSchoolFoodServiceProgramDim
END
GO

CREATE VIEW analytics.equity_StudentSchoolFoodServiceProgramDim
AS
	SELECT
		CONCAT (
			Student.StudentUniqueId, 
			'-',
			StudentSchoolAssociation.SchoolId, 
			'-',
			StudentSchoolFoodServiceProgramAssociation.ProgramName, 
			'-',
			StudentSchoolFoodServiceProgramAssociation.ProgramTypeDescriptorId,
			'-',
			StudentSchoolFoodServiceProgramAssociation.EducationOrganizationId,
			'-',
			StudentSchoolFoodServiceProgramAssociation.ProgramEducationOrganizationId,
			'-',
			CONVERT(varchar, StudentSchoolFoodServiceProgramAssociation.BeginDate, 112),
			'-',
			SchoolFoodServiceProgramServiceDescriptor.DescriptorId
		) AS StudentSchoolFoodServiceProgramKey
		,CONCAT (
			Student.StudentUniqueId,
			'-',
			StudentSchoolAssociation.SchoolId,
			'-',
			StudentSchoolFoodServiceProgramAssociation.ProgramName,
			'-',
			StudentSchoolFoodServiceProgramAssociation.ProgramTypeDescriptorId,
			'-',
			StudentSchoolFoodServiceProgramAssociation.EducationOrganizationId,
			'-',
			StudentSchoolFoodServiceProgramAssociation.ProgramEducationOrganizationId,
			'-',
			CONVERT(varchar, StudentSchoolFoodServiceProgramAssociation.BeginDate, 112)
		) AS StudentSchoolProgramKey
		,CONCAT (
			Student.StudentUniqueId, 
			'-',
			StudentSchoolAssociation.SchoolId
		) AS StudentSchoolKey
		,StudentSchoolFoodServiceProgramAssociation.ProgramName
		,SchoolFoodServiceProgramServiceDescriptor.Description as SchoolFoodServiceProgramServiceDescriptor
		,GeneralStudentProgramAssociation.LastModifiedDate
	FROM
		edfi.StudentSchoolFoodServiceProgramAssociation
	INNER JOIN
		edfi.GeneralStudentProgramAssociation ON
			StudentSchoolFoodServiceProgramAssociation.BeginDate = GeneralStudentProgramAssociation.BeginDate
			AND StudentSchoolFoodServiceProgramAssociation.EducationOrganizationId = GeneralStudentProgramAssociation.EducationOrganizationId
			AND StudentSchoolFoodServiceProgramAssociation.ProgramEducationOrganizationId = GeneralStudentProgramAssociation.ProgramEducationOrganizationId
			AND StudentSchoolFoodServiceProgramAssociation.ProgramName = GeneralStudentProgramAssociation.ProgramName
			AND StudentSchoolFoodServiceProgramAssociation.ProgramTypeDescriptorId = GeneralStudentProgramAssociation.ProgramTypeDescriptorId
			AND StudentSchoolFoodServiceProgramAssociation.StudentUSI = GeneralStudentProgramAssociation.StudentUSI
	INNER JOIN
		edfi.StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService ON
			StudentSchoolFoodServiceProgramAssociation.BeginDate = StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService.BeginDate
			AND StudentSchoolFoodServiceProgramAssociation.EducationOrganizationId = StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService.EducationOrganizationId
			AND StudentSchoolFoodServiceProgramAssociation.ProgramEducationOrganizationId = StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService.ProgramEducationOrganizationId
			AND StudentSchoolFoodServiceProgramAssociation.ProgramName = StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService.ProgramName
			AND StudentSchoolFoodServiceProgramAssociation.ProgramTypeDescriptorId = StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService.ProgramTypeDescriptorId
			AND StudentSchoolFoodServiceProgramAssociation.StudentUSI = StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService.StudentUSI
	INNER JOIN
		edfi.Descriptor SchoolFoodServiceProgramServiceDescriptor ON
			StudentSchoolFoodServiceProgramAssociationSchoolFoodServiceProgramService.SchoolFoodServiceProgramServiceDescriptorId = SchoolFoodServiceProgramServiceDescriptor.DescriptorId
	INNER JOIN
		edfi.Student ON
			GeneralStudentProgramAssociation.StudentUSI = Student.StudentUSI
	INNER JOIN
		edfi.StudentSchoolAssociation ON
			Student.StudentUSI = StudentSchoolAssociation.StudentUSI
	WHERE(
        StudentSchoolAssociation.ExitWithdrawDate IS NULL
        OR StudentSchoolAssociation.ExitWithdrawDate >= GETDATE());
	
GO