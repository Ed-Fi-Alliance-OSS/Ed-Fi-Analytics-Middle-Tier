﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


IF EXISTS
(
    SELECT 1
    FROM [INFORMATION_SCHEMA].[VIEWS]
    WHERE [TABLE_SCHEMA] = 'analytics'
          AND [TABLE_NAME] = 'StudentProgramDim'
)
    BEGIN
        DROP VIEW [analytics].[StudentProgramDim];
END;
GO
CREATE VIEW [analytics].[StudentProgramDim]
AS
    SELECT [BeginDate],program.[EducationOrganizationId],program.[ProgramName],student.[StudentUSI],
    CONCAT (Student.StudentUniqueId,'-',StudentSchoolAssociation.SchoolId) AS StudentSchoolKey
    FROM [edfi].[Program]
    INNER JOIN
        [edfi].[StudentProgramAssociation] StudentProgram
        ON StudentProgram.ProgramName = Program.ProgramName
        AND StudentProgram.ProgramTypeDescriptorId = Program.ProgramTypeDescriptorId
        AND StudentProgram.ProgramEducationOrganizationId = Program.EducationOrganizationId
    INNER JOIN 
        edfi.Student
        ON StudentProgram.StudentUSI = Student.StudentUSI
    INNER JOIN 
        edfi.StudentSchoolAssociation
        ON Student.StudentUSI = edfi.StudentSchoolAssociation.StudentUSI
GO