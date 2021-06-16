-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER VIEW analytics.equity_StudentDisciplineActionDim
AS
	SELECT DISTINCT CONCAT (
        DisciplineAction.DisciplineActionIdentifier
        ,'-'
        ,DisciplineAction.DisciplineDate
        ,'-'
        ,DisciplineAction.StudentUSI
        ) AS DisciplineActionUniqueKey
        ,CONCAT (
            Student.StudentUniqueId
            ,'-'
            ,StudentSchoolAssociation.SchoolId
            ) AS StudentSchoolKey
        ,Student.StudentUniqueId AS StudentKey
        ,StudentSchoolAssociation.SchoolId AS SchoolKey
        ,Descriptor.Description AS DisciplineActionDescription
        ,COALESCE(DisciplineActionStaff.StaffUSI,'0') AS StaffUSI
    FROM edfi.DisciplineAction
    INNER JOIN edfi.Student ON DisciplineAction.StudentUSI = Student.StudentUSI
    INNER JOIN edfi.StudentSchoolAssociation ON Student.StudentUSI = StudentSchoolAssociation.StudentUSI
    INNER JOIN edfi.DisciplineActionDiscipline ON DisciplineAction.DisciplineActionIdentifier = DisciplineActionDiscipline.DisciplineActionIdentifier
        AND DisciplineAction.DisciplineDate = DisciplineActionDiscipline.DisciplineDate
        AND DisciplineAction.StudentUSI = DisciplineActionDiscipline.StudentUSI
    INNER JOIN edfi.Descriptor ON DisciplineActionDiscipline.DisciplineDescriptorId = Descriptor.DescriptorId
    LEFT JOIN edfi.DisciplineActionStaff ON DisciplineAction.DisciplineActionIdentifier = DisciplineActionStaff.DisciplineActionIdentifier
        AND DisciplineAction.DisciplineDate = DisciplineActionStaff.DisciplineDate
        AND DisciplineAction.StudentUSI = DisciplineActionStaff.StudentUSI;
;