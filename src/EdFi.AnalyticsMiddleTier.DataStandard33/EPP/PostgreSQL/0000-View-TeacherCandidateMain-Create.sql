-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
DROP VIEW IF EXISTS analytics.tpdm_TeacherCandidateMain;

CREATE VIEW analytics.tpdm_TeacherCandidateMain AS
	SELECT c.CandidateIdentifier
		,c.FirstName
		,c.LastSurname
		,c.SexDescriptorId
		,COALESCE(rd.RaceDescriptorId, 0) AS RaceDescriptorId
		,COALESCE(c.HispanicLatinoEthnicity, false) AS HispanicLatinoEthnicity
		,COALESCE(c.EconomicDisadvantaged, false) AS EconomicDisadvantaged
		,COALESCE(ccy.SchoolYear, 0) AS Cohort
		,CAST(CASE WHEN red.CodeValue = 'Received certificate of completion or equivalent' THEN 1 ELSE 0 END AS BIT) ProgramComplete
		,COALESCE(s.StudentUSI, 0) AS StudentUSI
		,epp.ProgramName
		,epp.BeginDate
		,epp.EducationOrganizationId
		,COALESCE(c.PersonId, '') AS PersonId
		,COALESCE(CASE WHEN SUM(CASE WHEN cred.CredentialIdentifier IS NOT NULL THEN 1 ELSE 0 END) > 0 THEN CAST(MIN(cred.IssuanceDate) as VARCHAR) END, '') IssuanceDate
        ,COALESCE(termdesc.CodeValue, '') AS CohortYearTermDescription
	FROM tpdm.Candidate c 
	JOIN tpdm.CandidateEducatorPreparationProgramAssociation epp on epp.CandidateIdentifier = c.CandidateIdentifier 
	LEFT JOIN tpdm.CandidateRace rd on rd.CandidateIdentifier = c.CandidateIdentifier 
	LEFT JOIN edfi.Descriptor d on d.DescriptorId = rd.RaceDescriptorId 
	LEFT JOIN edfi.Student s on s.PersonId = c.PersonId 
	LEFT JOIN tpdm.CandidateEducatorPreparationProgramAssociationCohortYear ccy on ccy.CandidateIdentifier = c.CandidateIdentifier
        and ccy.ProgramName = epp.ProgramName
    LEFT JOIN edfi.Descriptor termdesc on ccy.TermDescriptorId = termdesc.DescriptorId
	LEFT JOIN tpdm.CredentialExtension ce on ce.PersonId = c.PersonId 
	LEFT JOIN edfi.Credential cred on cred.CredentialIdentifier = ce.CredentialIdentifier
	LEFT JOIN edfi.Descriptor red ON epp.ReasonExitedDescriptorId = red.DescriptorId
    
	GROUP BY c.CandidateIdentifier 
		,c.FirstName 
		,c.LastSurname 
		,c.SexDescriptorId 
		,rd.RaceDescriptorId 
		,c.HispanicLatinoEthnicity 
		,c.EconomicDisadvantaged 
		,ccy.SchoolYear
		,red.CodeValue 
		,s.StudentUSI 
		,epp.ProgramName 
		,epp.BeginDate 
		,epp.EducationOrganizationId 
		,c.PersonId
        ,termdesc.CodeValue;