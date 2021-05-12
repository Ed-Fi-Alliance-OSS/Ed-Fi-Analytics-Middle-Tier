-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE VIEW analytics.SectionDim AS
    SELECT DISTINCT 
          CAST(s.SchoolId AS VARCHAR) AS SchoolKey, 
          CAST(s.SchoolId AS NVARCHAR) + '-' + s.LocalCourseCode + '-' + CAST(s.SchoolYear AS NVARCHAR) + '-' + s.SectionIdentifier + '-' + s.SessionName AS SectionKey, 
		  CONCAT(s.LocalCourseCode,'-',SessionName) AS SectionName,
		  SessionName,
          LocalCourseCode, 
          SchoolYear, 
          EducationalEnvironmentDescriptorId AS EducationalEnvironmentTypeId, 
          sch.LocalEducationAgencyId 
   FROM 
        [edfi].[Section] s
   LEFT JOIN
       [edfi].[School] sch ON
           s.SchoolId = sch.SchoolId
GO