-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'SchoolDim')
BEGIN
	DROP VIEW analytics.SchoolDim
END
GO

CREATE VIEW analytics.SchoolDim
AS
     SELECT CAST(School.SchoolId AS VARCHAR) AS SchoolKey, 
            EducationOrganization.NameOfInstitution AS SchoolName, 
            COALESCE(SchoolType.CodeValue, '') AS SchoolType, 
            COALESCE(SchoolAddress.SchoolAddress, '') AS SchoolAddress, 
            COALESCE(SchoolAddress.SchoolCity, '') AS SchoolCity, 
            COALESCE(SchoolAddress.SchoolCounty, '') AS SchoolCounty, 
            COALESCE(SchoolAddress.SchoolState, '') AS SchoolState, 
            COALESCE(EdOrgLocal.NameOfInstitution, '') AS LocalEducationAgencyName, 
            EdOrgLocal.EducationOrganizationId AS LocalEducationAgencyKey, 
            COALESCE(EdOrgState.NameOfInstitution, '') AS StateEducationAgencyName, 
            EdOrgState.EducationOrganizationId AS StateEducationAgencyKey, 
            COALESCE(EdOrgServiceCenter.NameOfInstitution, '') AS EducationServiceCenterName, 
            EdOrgServiceCenter.EducationOrganizationId AS EducationServiceCenterKey, 
     (
         SELECT MAX(MaxLastModifiedDate)
         FROM(VALUES(EducationOrganization.LastModifiedDate), (SchoolType.LastModifiedDate), (EdOrgLocal.LastModifiedDate), (EdOrgState.LastModifiedDate), (EdOrgServiceCenter.LastModifiedDate), (SchoolAddress.LastModifiedDate)) AS VALUE(MaxLastModifiedDate)
     ) AS LastModifiedDate
     FROM edfi.School
     INNER JOIN
          edfi.EducationOrganization
       ON School.SchoolId = EducationOrganization.EducationOrganizationId
     LEFT OUTER JOIN
          edfi.SchoolType
       ON School.SchoolTypeId = SchoolType.SchoolTypeId
     LEFT OUTER JOIN
          edfi.LocalEducationAgency
       ON School.LocalEducationAgencyId = LocalEducationAgency.LocalEducationAgencyId
     LEFT OUTER JOIN
          edfi.EducationOrganization AS EdOrgLocal
       ON School.LocalEducationAgencyId = EdOrgLocal.EducationOrganizationId
     LEFT OUTER JOIN
          edfi.EducationOrganization AS EdOrgState
       ON LocalEducationAgency.StateEducationAgencyId = EdOrgState.EducationOrganizationId
     LEFT OUTER JOIN
          edfi.EducationOrganization AS EdOrgServiceCenter
       ON LocalEducationAgency.EducationServiceCenterId = EdOrgServiceCenter.EducationOrganizationId
     OUTER APPLY
     (
         SELECT TOP 1 CONCAT(EducationOrganizationAddress.StreetNumberName, ', ', (EducationOrganizationAddress.ApartmentRoomSuiteNumber + ', '), EducationOrganizationAddress.City, StateAbbreviationType.CodeValue, ' ', EducationOrganizationAddress.PostalCode) AS SchoolAddress, 
                      EducationOrganizationAddress.City AS SchoolCity, 
                      EducationOrganizationAddress.NameOfCounty AS SchoolCounty, 
                      StateAbbreviationType.CodeValue AS SchoolState, 
                      EducationOrganizationAddress.BeginDate AS LastModifiedDate
         FROM edfi.EducationOrganizationAddress
         INNER JOIN
              edfi.AddressType
           ON EducationOrganizationAddress.AddressTypeId = AddressType.AddressTypeId
         INNER JOIN
              edfi.StateAbbreviationType
           ON EducationOrganizationAddress.StateAbbreviationTypeId = StateAbbreviationType.StateAbbreviationTypeId
         INNER JOIN
              analytics_config.TypeMap
           ON AddressType.AddressTypeId = TypeMap.TypeId
         INNER JOIN
              analytics_config.DescriptorConstant
           ON DescriptorConstant.DescriptorConstantId = TypeMap.DescriptorConstantId
         WHERE School.SchoolId = EducationOrganizationAddress.EducationOrganizationId
               AND EducationOrganizationAddress.EndDate IS NULL
               AND DescriptorConstant.ConstantName = 'Address.Physical'
     ) AS SchoolAddress;
GO

