-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('analytics.EPP_CandidateDim') IS NOT NULL 
	DROP VIEW analytics.EPP_CandidateDim

GO


CREATE VIEW analytics.EPP_CandidateDim AS

SELECT Candidate.CandidateIdentifier AS CandidateKey
		,Candidate.FirstName
		,Candidate.LastSurname
		,CAST(Candidate.SexDescriptorId AS VARCHAR) AS SexDescriptorKey
		,SexDescriptor.CodeValue AS SexDescriptor
		,COALESCE(CAST(CandidateRace.RaceDescriptorId AS VARCHAR), '') AS RaceDescriptorKey
		,COALESCE(RaceDescriptor.CodeValue, '') AS RaceDescriptor
		,CAST(COALESCE(Candidate.HispanicLatinoEthnicity, 0) AS BIT) AS HispanicLatinoEthnicity
		,CAST(COALESCE(Candidate.EconomicDisadvantaged, 0) AS BIT) AS EconomicDisadvantaged
		,COALESCE(CAST(CandidateEducatorPreparationProgramAssociationCohortYear.SchoolYear AS VARCHAR), '') AS Cohort
		,CAST(CASE 
			WHEN 
				ReasonExitedDescriptor.CodeValue = 'Completed' 
					THEN 1 
				ELSE 0 
			END AS BIT) ProgramComplete
		,COALESCE(CAST(Student.StudentUSI AS VARCHAR), '') AS StudentUSI
		,CandidateEducatorPreparationProgramAssociation.ProgramName
		,CandidateEducatorPreparationProgramAssociation.BeginDate
		,CandidateEducatorPreparationProgramAssociation.EducationOrganizationId
		,COALESCE(Candidate.PersonId, '') AS PersonId
		,COALESCE(CASE
			WHEN SUM(CASE
				WHEN Credential.CredentialIdentifier IS NOT NULL 
					THEN 1 
				ELSE 0 
				END) > 0 
			THEN CAST(MIN(Credential.IssuanceDate) as NVARCHAR) END, '') IssuanceDate
        ,COALESCE(TermDescriptor.CodeValue, '') AS CohortYearTermDescription,
		(SELECT 
			MAX(MaxLastModifiedDate)
		FROM 
			(VALUES (MAX(Candidate.LastModifiedDate))
					,(MAX(CandidateEducatorPreparationProgramAssociation.LastModifiedDate))
					,(MAX(Student.LastModifiedDate))
					,(MAX(Credential.LastModifiedDate))
				) AS VALUE (MaxLastModifiedDate)
			) AS LastModifiedDate
	FROM
		tpdm.Candidate
	JOIN
		tpdm.CandidateEducatorPreparationProgramAssociation
			ON CandidateEducatorPreparationProgramAssociation.CandidateIdentifier = Candidate.CandidateIdentifier 
	JOIN
		edfi.Descriptor SexDescriptor
			ON Candidate.SexDescriptorId = SexDescriptor.DescriptorId
	LEFT JOIN
		tpdm.CandidateRace
			ON CandidateRace.CandidateIdentifier = Candidate.CandidateIdentifier 
	LEFT JOIN
		edfi.Descriptor RaceDescriptor
			ON RaceDescriptor.DescriptorId = CandidateRace.RaceDescriptorId 
	LEFT JOIN
		edfi.Student
			ON Student.PersonId = Candidate.PersonId
	LEFT JOIN
		tpdm.CandidateEducatorPreparationProgramAssociationCohortYear
			ON CandidateEducatorPreparationProgramAssociationCohortYear.CandidateIdentifier = Candidate.CandidateIdentifier
				AND CandidateEducatorPreparationProgramAssociationCohortYear.ProgramName = CandidateEducatorPreparationProgramAssociation.ProgramName
    LEFT JOIN
		edfi.Descriptor TermDescriptor
			ON CandidateEducatorPreparationProgramAssociationCohortYear.TermDescriptorId = TermDescriptor.DescriptorId
	LEFT JOIN
		tpdm.CredentialExtension
			ON CredentialExtension.PersonId = Candidate.PersonId
	LEFT JOIN
		edfi.Credential
			ON Credential.CredentialIdentifier = CredentialExtension.CredentialIdentifier
	LEFT JOIN
		edfi.Descriptor ReasonExitedDescriptor
			ON CandidateEducatorPreparationProgramAssociation.ReasonExitedDescriptorId = ReasonExitedDescriptor.DescriptorId
    
	GROUP BY Candidate.CandidateIdentifier 
		,Candidate.FirstName 
		,Candidate.LastSurname 
		,Candidate.SexDescriptorId
		,SexDescriptor.CodeValue
		,CandidateRace.RaceDescriptorId
		,RaceDescriptor.CodeValue
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