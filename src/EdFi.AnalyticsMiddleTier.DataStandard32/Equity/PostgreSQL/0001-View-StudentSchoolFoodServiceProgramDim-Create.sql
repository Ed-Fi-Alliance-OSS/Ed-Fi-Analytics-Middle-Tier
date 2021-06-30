-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER VIEW analytics.equity_StudentSchoolFoodServiceProgramDim
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
			CAST(EXTRACT(YEAR FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) AS VARCHAR(4)) 
			|| 
				CASE 
					WHEN EXTRACT(MONTH FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) BETWEEN 1 AND 9 THEN '0' || CAST(EXTRACT(MONTH FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) as VARCHAR(4))
					ELSE CAST(EXTRACT(MONTH FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) as varchar(2))
				END
			|| 
				CASE 
					WHEN EXTRACT(DAY FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) BETWEEN 1 AND 9 THEN '0' || CAST(EXTRACT(DAY FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) as VARCHAR(4))
					ELSE CAST(EXTRACT(DAY FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) as varchar(2))
				END,
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
			CAST(EXTRACT(YEAR FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) AS VARCHAR(4)) 
			|| 
				CASE 
					WHEN EXTRACT(MONTH FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) BETWEEN 1 AND 9 THEN '0' || CAST(EXTRACT(MONTH FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) as VARCHAR(4))
					ELSE CAST(EXTRACT(MONTH FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) as varchar(2))
				END
			|| 
				CASE 
					WHEN EXTRACT(DAY FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) BETWEEN 1 AND 9 THEN '0' || CAST(EXTRACT(DAY FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) as VARCHAR(4))
					ELSE CAST(EXTRACT(DAY FROM StudentSchoolFoodServiceProgramAssociation.BeginDate) as varchar(2))
				END
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
		edfi.studentschoolfoodserviceprogramassociationschoolfoodserv_85a0eb ON
			StudentSchoolFoodServiceProgramAssociation.BeginDate = studentschoolfoodserviceprogramassociationschoolfoodserv_85a0eb.BeginDate
			AND StudentSchoolFoodServiceProgramAssociation.EducationOrganizationId = studentschoolfoodserviceprogramassociationschoolfoodserv_85a0eb.EducationOrganizationId
			AND StudentSchoolFoodServiceProgramAssociation.ProgramEducationOrganizationId = studentschoolfoodserviceprogramassociationschoolfoodserv_85a0eb.ProgramEducationOrganizationId
			AND StudentSchoolFoodServiceProgramAssociation.ProgramName = studentschoolfoodserviceprogramassociationschoolfoodserv_85a0eb.ProgramName
			AND StudentSchoolFoodServiceProgramAssociation.ProgramTypeDescriptorId = studentschoolfoodserviceprogramassociationschoolfoodserv_85a0eb.ProgramTypeDescriptorId
			AND StudentSchoolFoodServiceProgramAssociation.StudentUSI = studentschoolfoodserviceprogramassociationschoolfoodserv_85a0eb.StudentUSI
	INNER JOIN
		edfi.Descriptor SchoolFoodServiceProgramServiceDescriptor ON
			studentschoolfoodserviceprogramassociationschoolfoodserv_85a0eb.SchoolFoodServiceProgramServiceDescriptorId = SchoolFoodServiceProgramServiceDescriptor.DescriptorId
	INNER JOIN
		edfi.Student ON
			GeneralStudentProgramAssociation.StudentUSI = Student.StudentUSI
	INNER JOIN
		edfi.StudentSchoolAssociation ON
			Student.StudentUSI = StudentSchoolAssociation.StudentUSI
	WHERE(
        StudentSchoolAssociation.ExitWithdrawDate IS NULL
        OR StudentSchoolAssociation.ExitWithdrawDate >= NOW());
	