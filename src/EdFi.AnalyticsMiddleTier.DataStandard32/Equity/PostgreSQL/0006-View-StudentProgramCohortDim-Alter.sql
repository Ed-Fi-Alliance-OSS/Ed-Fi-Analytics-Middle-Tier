-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE VIEW analytics.equity_StudentProgramCohortDim
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
			TO_CHAR(StudentProgramAssociation.BeginDate, 'yyyymmdd'),
			'-',
			Cohort.CohortIdentifier
		) AS StudentProgramCohortKey,
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
			TO_CHAR(StudentProgramAssociation.BeginDate, 'yyyymmdd')
        ) AS StudentSchoolProgramKey
		,CONCAT(
			Student.StudentUniqueId,
			'-',
			StudentSchoolAssociation.SchoolId
		) AS StudentSchoolKey
		,EntryGradeDescriptor.Description AS EntryGradeLevelDescriptor
		,CohortTypeDescriptor.Description AS CohortTypeDescriptor
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
		edfi.GeneralStudentProgramAssociation ON
			Program.EducationOrganizationId = GeneralStudentProgramAssociation.EducationOrganizationId
			AND Program.ProgramName = GeneralStudentProgramAssociation.ProgramName
			AND Program.ProgramTypeDescriptorId = GeneralStudentProgramAssociation.ProgramTypeDescriptorId
	INNER JOIN
		edfi.StudentProgramAssociation ON
			GeneralStudentProgramAssociation.BeginDate = StudentProgramAssociation.BeginDate
			AND GeneralStudentProgramAssociation.EducationOrganizationId = StudentProgramAssociation.EducationOrganizationId
			AND GeneralStudentProgramAssociation.ProgramEducationOrganizationId = StudentProgramAssociation.ProgramEducationOrganizationId
			AND GeneralStudentProgramAssociation.ProgramName = StudentProgramAssociation.ProgramName
			AND GeneralStudentProgramAssociation.ProgramTypeDescriptorId = StudentProgramAssociation.ProgramTypeDescriptorId
			AND GeneralStudentProgramAssociation.StudentUSI = StudentProgramAssociation.StudentUSI
	INNER JOIN 
		edfi.Student ON
			GeneralStudentProgramAssociation.StudentUSI = Student.StudentUSI
	INNER JOIN 
		edfi.StudentSchoolAssociation ON 
			Student.StudentUSI = edfi.StudentSchoolAssociation.StudentUSI
	INNER JOIN
		edfi.Descriptor AS EntryGradeDescriptor ON
			StudentSchoolAssociation.EntryGradeLevelDescriptorId = EntryGradeDescriptor.DescriptorId
	INNER JOIN
		edfi.Descriptor AS CohortTypeDescriptor ON
			Cohort.CohortTypeDescriptorId = CohortTypeDescriptor.DescriptorId
	WHERE (
        StudentSchoolAssociation.ExitWithdrawDate IS NULL
			OR StudentSchoolAssociation.ExitWithdrawDate >= NOW()
        );
