-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Cannot use `CREATE OR REPLACE VIEW` because a column is being removed
DROP VIEW IF EXISTS analytics.equity_StudentDisciplineActionDim;

CREATE VIEW analytics.equity_StudentDisciplineActionDim AS

SELECT DISTINCT CONCAT (
        DisciplineAction.DisciplineActionIdentifier
        ,'-'
        ,TO_CHAR(DisciplineAction.DisciplineDate, 'yyyymmdd')
        ,'-'
        ,Student.StudentUniqueId
        ,'-'
        ,StudentSchoolAssociation.SchoolId
        ) AS StudentDisciplineActionKey
    ,CONCAT (
        Student.StudentUniqueId
        ,'-'
        ,StudentSchoolAssociation.SchoolId
        ) AS StudentSchoolKey
    ,TO_CHAR(DisciplineAction.DisciplineDate, 'yyyymmdd') AS DisciplineDateKey
    ,Student.StudentUniqueId AS StudentKey
    ,StudentSchoolAssociation.SchoolId AS SchoolKey
    ,Descriptor.Description AS DisciplineActionDescription
    ,COALESCE(Staff.StaffUniqueId, '') AS UserKey
    ,(
        SELECT MAX(MaxLastModifiedDate)
        FROM (
            VALUES (Student.LastModifiedDate)
                ,(StudentSchoolAssociation.LastModifiedDate)
                ,(Staff.LastModifiedDate)
            ) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate
FROM edfi.DisciplineAction
INNER JOIN edfi.Student
    ON DisciplineAction.StudentUSI = Student.StudentUSI
INNER JOIN edfi.StudentSchoolAssociation
    ON Student.StudentUSI = StudentSchoolAssociation.StudentUSI
INNER JOIN edfi.DisciplineActionDiscipline
    ON DisciplineAction.DisciplineActionIdentifier = DisciplineActionDiscipline.DisciplineActionIdentifier
        AND DisciplineAction.DisciplineDate = DisciplineActionDiscipline.DisciplineDate
        AND DisciplineAction.StudentUSI = DisciplineActionDiscipline.StudentUSI
INNER JOIN edfi.Descriptor
    ON DisciplineActionDiscipline.DisciplineDescriptorId = Descriptor.DescriptorId
LEFT JOIN edfi.DisciplineActionStaff
    ON DisciplineAction.DisciplineActionIdentifier = DisciplineActionStaff.DisciplineActionIdentifier
        AND DisciplineAction.DisciplineDate = DisciplineActionStaff.DisciplineDate
        AND DisciplineAction.StudentUSI = DisciplineActionStaff.StudentUSI
LEFT JOIN edfi.Staff
    ON DisciplineActionStaff.StaffUSI = Staff.StaffUSI
WHERE (
        StudentSchoolAssociation.ExitWithdrawDate IS NULL
        OR StudentSchoolAssociation.ExitWithdrawDate >= NOW()
        );
