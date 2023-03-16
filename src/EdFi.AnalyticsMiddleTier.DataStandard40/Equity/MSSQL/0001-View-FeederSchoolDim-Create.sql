-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
IF EXISTS (
        SELECT 1
        FROM INFORMATION_SCHEMA.VIEWS
        WHERE TABLE_SCHEMA = 'analytics'
            AND TABLE_NAME = 'equity_FeederSchoolDim'
        )
BEGIN
    DROP VIEW analytics.equity_FeederSchoolDim
END
GO

CREATE VIEW analytics.equity_FeederSchoolDim
AS
SELECT 
    CONCAT(FeederSchoolAssociation.SchoolId,'-',FeederSchoolAssociation.FeederSchoolId) AS FeederSchoolUniqueKey
    ,CAST(FeederSchoolAssociation.SchoolId AS VARCHAR) AS SchoolKey
    ,CAST(FeederSchoolAssociation.FeederSchoolId AS VARCHAR) AS FeederSchoolKey
    ,EducationOrganization.NameOfInstitution AS FeederSchoolName
    ,(
        SELECT MAX(MaxLastModifiedDate)
        FROM (
            VALUES (FeederSchoolAssociation.LastModifiedDate)
                ,(EducationOrganization.LastModifiedDate)
            ) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate
FROM edfi.FeederSchoolAssociation
INNER JOIN edfi.School ON FeederSchoolAssociation.SchoolId = School.SchoolId
INNER JOIN edfi.School FeederSchool ON FeederSchoolAssociation.FeederSchoolId = FeederSchool.SchoolId
INNER JOIN edfi.EducationOrganization ON FeederSchool.SchoolId = EducationOrganization.EducationOrganizationId
WHERE (
        FeederSchoolAssociation.EndDate IS NULL
        OR FeederSchoolAssociation.EndDate >= GETDATE());
