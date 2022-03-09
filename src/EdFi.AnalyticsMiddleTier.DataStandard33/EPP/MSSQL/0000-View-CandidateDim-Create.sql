-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('analytics.tpdm_CandidateDim') IS NOT NULL 
	DROP VIEW analytics.tpdm_CandidateDim

GO


CREATE VIEW analytics.tpdm_CandidateDim AS

SELECT Candidate.CandidateIdentifier
		,Candidate.FirstName
		,Candidate.LastSurname
		,Candidate.SexDescriptorId
		,COALESCE(CandidateRace.RaceDescriptorId, 0) AS RaceDescriptorId
		,COALESCE(Candidate.HispanicLatinoEthnicity, 0) AS HispanicLatinoEthnicity
		,COALESCE(Candidate.EconomicDisadvantaged, 0) AS EconomicDisadvantaged
		,COALESCE(CandidateEducatorPreparationProgramAssociationCohortYear.SchoolYear, 0) AS Cohort
		,CAST(CASE WHEN ReasonExitedDescriptor.CodeValue = 'Completed' THEN 1 ELSE 0 END AS BIT) ProgramComplete
		,COALESCE(Student.StudentUSI, 0) AS StudentUSI
		,CandidateEducatorPreparationProgramAssociation.ProgramName
		,CandidateEducatorPreparationProgramAssociation.BeginDate
		,CandidateEducatorPreparationProgramAssociation.EducationOrganizationId
		,COALESCE(Candidate.PersonId, '') AS PersonId
		,COALESCE(CASE WHEN SUM(CASE WHEN cred.CredentialIdentifier IS NOT NULL THEN 1 ELSE 0 END) > 0 THEN CAST(MIN(cred.IssuanceDate) as NVARCHAR) END, '') IssuanceDate
        ,COALESCE(TermDescriptor.CodeValue, '') AS CohortYearTermDescription
	FROM tpdm.Candidate
	JOIN tpdm.CandidateEducatorPreparationProgramAssociation ON CandidateEducatorPreparationProgramAssociation.CandidateIdentifier = Candidate.CandidateIdentifier 
	LEFT JOIN tpdm.CandidateRace ON CandidateRace.CandidateIdentifier = Candidate.CandidateIdentifier 
	LEFT JOIN edfi.Descriptor ON Descriptor.DescriptorId = CandidateRace.RaceDescriptorId 
	LEFT JOIN edfi.Student ON Student.PersonId = Candidate.PersonId
	LEFT JOIN tpdm.CandidateEducatorPreparationProgramAssociationCohortYear ON CandidateEducatorPreparationProgramAssociationCohortYear.CandidateIdentifier = Candidate.CandidateIdentifier
        and CandidateEducatorPreparationProgramAssociationCohortYear.ProgramName = CandidateEducatorPreparationProgramAssociation.ProgramName
    LEFT JOIN edfi.Descriptor TermDescriptor ON CandidateEducatorPreparationProgramAssociationCohortYear.TermDescriptorId = TermDescriptor.DescriptorId
	LEFT JOIN tpdm.CredentialExtension ON CredentialExtension.PersonId = Candidate.PersonId
	LEFT JOIN edfi.Credential cred ON cred.CredentialIdentifier = CredentialExtension.CredentialIdentifier
	LEFT JOIN edfi.Descriptor ReasonExitedDescriptor ON CandidateEducatorPreparationProgramAssociation.ReasonExitedDescriptorId = ReasonExitedDescriptor.DescriptorId
    
	GROUP BY Candidate.CandidateIdentifier 
		,Candidate.FirstName 
		,Candidate.LastSurname 
		,Candidate.SexDescriptorId 
		,CandidateRace.RaceDescriptorId 
		,Candidate.HispanicLatinoEthnicity 
		,Candidate.EconomicDisadvantaged 
		,CandidateEducatorPreparationProgramAssociationCohortYear.SchoolYear
		,ReasonExitedDescriptor.CodeValue 
		,Student.StudentUSI 
		,CandidateEducatorPreparationProgramAssociation.ProgramName 
		,CandidateEducatorPreparationProgramAssociation.BeginDate 
		,CandidateEducatorPreparationProgramAssociation.EducationOrganizationId 
		,Candidate.PersonId
        ,TermDescriptor.CodeValue
GO