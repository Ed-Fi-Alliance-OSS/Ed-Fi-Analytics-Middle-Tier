-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.VIEWS
        WHERE TABLE_SCHEMA = 'analytics'
            AND TABLE_NAME = 'equity_StudentProgramCohortDim'
        )
BEGIN
    DROP VIEW analytics.equity_StudentProgramCohortDim
END
GO

CREATE VIEW [analytics].[equity_StudentProgramCohortDim]
AS
	SELECT CONCAT (
			Student.StudentUniqueId
			,'-'
			,StudentSchoolAssociation.SchoolId
			,'-'
			,Program.ProgramName
			,'-'
			,Program.ProgramTypeDescriptorId
			,'-'
			,Cohort.EducationOrganizationId
			,'-'
			,Program.EducationOrganizationId
			,'-'
			,CONVERT(VARCHAR, StudentCohortAssociation.BeginDate, 112)
			,'-'
			,Cohort.CohortIdentifier
			) AS StudentProgramCohortKey
		,CONCAT (
			Student.StudentUniqueId
			,'-'
			,StudentSchoolAssociation.SchoolId
			,'-'
			,Program.ProgramName
			,'-'
			,Program.ProgramTypeDescriptorId
			,'-'
			,Cohort.EducationOrganizationId
			,'-'
			,Program.EducationOrganizationId
			,'-'
			,CONVERT(VARCHAR, StudentCohortAssociation.BeginDate, 112)
			) AS StudentSchoolProgramKey
		,CONCAT (
			Student.StudentUniqueId
			,'-'
			,StudentSchoolAssociation.SchoolId
			) AS StudentSchoolKey
		,EntryGradeDescriptor.Description AS EntryGradeLevelDescriptor
		,CohortTypeDescriptor.Description AS CohortTypeDescriptor
		,Cohort.CohortDescription
		,Program.ProgramName
		,(
			SELECT MAX(MaxLastModifiedDate)
			FROM (
				VALUES (Cohort.LastModifiedDate)
					,(StudentCohortAssociation.LastModifiedDate)
				) AS VALUE(MaxLastModifiedDate)
			) AS LastModifiedDate
	FROM edfi.Cohort
	INNER JOIN edfi.CohortProgram ON Cohort.CohortIdentifier = CohortProgram.CohortIdentifier
		AND Cohort.EducationOrganizationId = CohortProgram.EducationOrganizationId
	INNER JOIN edfi.Program ON CohortProgram.ProgramEducationOrganizationId = program.EducationOrganizationId
		AND CohortProgram.ProgramName = program.ProgramName
		AND CohortProgram.ProgramTypeDescriptorId = program.ProgramTypeDescriptorId
	INNER JOIN edfi.StudentCohortAssociation ON
		Cohort.CohortIdentifier = StudentCohortAssociation.CohortIdentifier
			AND Cohort.EducationOrganizationId = StudentCohortAssociation.EducationOrganizationId
	INNER JOIN edfi.Student ON StudentCohortAssociation.StudentUSI = Student.StudentUSI
	INNER JOIN edfi.StudentSchoolAssociation ON Student.StudentUSI = edfi.StudentSchoolAssociation.StudentUSI
	INNER JOIN edfi.Descriptor AS EntryGradeDescriptor ON StudentSchoolAssociation.EntryGradeLevelDescriptorId = EntryGradeDescriptor.DescriptorId
	INNER JOIN edfi.Descriptor AS CohortTypeDescriptor ON Cohort.CohortTypeDescriptorId = CohortTypeDescriptor.DescriptorId
	WHERE (
			StudentSchoolAssociation.ExitWithdrawDate IS NULL
			OR StudentSchoolAssociation.ExitWithdrawDate >= GETDATE()
			);


GO