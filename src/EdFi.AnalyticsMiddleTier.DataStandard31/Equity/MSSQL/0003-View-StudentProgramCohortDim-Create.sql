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

CREATE VIEW analytics.equity_StudentProgramCohortDim
AS
	SELECT
		CONCAT(
			Student.StudentUniqueId,
			'-',
			StudentSchoolAssociation.SchoolId,
			'-',
			StudentProgramAssociation.ProgramName,
			'-',
			StudentProgramAssociation.ProgramTypeDescriptorId,
			'-',
			StudentProgramAssociation.EducationOrganizationId,
			'-',
			StudentProgramAssociation.ProgramEducationOrganizationId,
			'-',
			CONVERT(varchar, StudentProgramAssociation.BeginDate, 112),
			'-',
			Cohort.CohortIdentifier
		) AS StudentProgramCohortKey
		,CONCAT(
			Student.StudentUniqueId,
			'-',
			StudentSchoolAssociation.SchoolId
		) AS StudentSchoolKey
		,Cohort.CohortDescription
		,Program.ProgramName
		,(
            SELECT
                MAX(MaxLastModifiedDate)
            FROM (VALUES
                (Cohort.LastModifiedDate)
                ,(GeneralStudentProgramAssociation.LastModifiedDate)
            ) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate
	FROM
		edfi.Cohort
	INNER JOIN
		edfi.CohortProgram ON
			Cohort.CohortIdentifier = CohortProgram.CohortIdentifier
			AND Cohort.EducationOrganizationId = CohortProgram.EducationOrganizationId
	INNER JOIN
		edfi.Program ON
			CohortProgram.EducationOrganizationId = program.EducationOrganizationId
			AND CohortProgram.ProgramName = program.ProgramName
			AND CohortProgram.ProgramTypeDescriptorId = program.ProgramTypeDescriptorId
	INNER JOIN
		edfi.StudentProgramAssociation ON 
			StudentProgramAssociation.ProgramName = Program.ProgramName
			AND StudentProgramAssociation.ProgramTypeDescriptorId = Program.ProgramTypeDescriptorId
			AND StudentProgramAssociation.ProgramEducationOrganizationId = Program.EducationOrganizationId
	INNER JOIN
		edfi.GeneralStudentProgramAssociation ON
			StudentProgramAssociation.BeginDate = GeneralStudentProgramAssociation.BeginDate
			AND StudentProgramAssociation.EducationOrganizationId = GeneralStudentProgramAssociation.EducationOrganizationId
			AND StudentProgramAssociation.ProgramEducationOrganizationId = GeneralStudentProgramAssociation.ProgramEducationOrganizationId
			AND StudentProgramAssociation.ProgramName = GeneralStudentProgramAssociation.ProgramName
			AND StudentProgramAssociation.ProgramTypeDescriptorId = GeneralStudentProgramAssociation.ProgramTypeDescriptorId
			AND StudentProgramAssociation.StudentUSI = GeneralStudentProgramAssociation.StudentUSI
	INNER JOIN 
		edfi.Student ON 
			StudentProgramAssociation.StudentUSI = Student.StudentUSI
	INNER JOIN 
		edfi.StudentSchoolAssociation ON 
			Student.StudentUSI = edfi.StudentSchoolAssociation.StudentUSI;
GO