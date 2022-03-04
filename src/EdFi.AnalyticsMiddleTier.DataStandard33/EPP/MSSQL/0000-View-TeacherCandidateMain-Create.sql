-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[analytics].[tpdm_TeacherCandidateMain]') IS NOT NULL 
	DROP VIEW [analytics].[tpdm_TeacherCandidateMain]

GO


CREATE VIEW [analytics].[tpdm_TeacherCandidateMain] AS

SELECT c.CandidateIdentifier 
		,c.FirstName 
		,c.LastSurname 
		,c.SexDescriptorId 
		,rd.RaceDescriptorId 
		,c.HispanicLatinoEthnicity 
		,c.EconomicDisadvantaged 
		,ccy.SchoolYear as Cohort 
		,CAST(CASE WHEN red.CodeValue = 'Received certificate of completion or equivalent' THEN 1 ELSE 0 END AS BIT) ProgramComplete
		,s.StudentUSI 
		,epp.ProgramName 
		,epp.BeginDate 
		,epp.EducationOrganizationId 
		,c.PersonId 
		,CASE WHEN SUM(CASE WHEN cred.CredentialIdentifier IS NOT NULL THEN 1 ELSE 0 END) > 0 THEN MIN(cred.IssuanceDate) END IssuanceDate
        ,termdesc.CodeValue CohortYearTermDescription
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
        ,termdesc.CodeValue
GO