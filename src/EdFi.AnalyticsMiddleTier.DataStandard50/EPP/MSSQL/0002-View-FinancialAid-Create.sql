-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[analytics].[EPP_FinancialAidFact]') IS NOT NULL
	DROP VIEW [analytics].[EPP_FinancialAidFact]

GO

CREATE VIEW [analytics].[EPP_FinancialAidFact] AS

---Financial Aid
SELECT  CONCAT(Candidate.CandidateIdentifier,'-',AidDescriptor.DescriptorId,'-',CONVERT(VARCHAR,tpdm.FinancialAid.BeginDate,112)) As CandidateAidKey
		,Candidate.CandidateIdentifier as CandidateKey
		,FinancialAid.BeginDate
		,CONVERT(VARCHAR, FinancialAid.BeginDate,112) AS BeginDateKey
		,FinancialAid.EndDate
		,CONVERT(VARCHAR, FinancialAid.EndDate,112) AS EndDateKey
		,COALESCE(FinancialAid.AidConditionDescription,'') as AidConditionDescription
		,AidDescriptor.CodeValue as AidType
		,COALESCE(FinancialAid.AidAmount,0) as AidAmount
		,CAST(COALESCE(FinancialAid.PellGrantRecipient,0) as BIT) AS PellGrantRecipient
		,(SELECT MAX(MaxLastModifiedDate)  FROM
                (VALUES(Candidate.LastModifiedDate), (FinancialAid.LastModifiedDate)
                ) AS VALUE(MaxLastModifiedDate)
		 ) As LastModifiedDate
		FROM tpdm.Candidate
  INNER JOIN edfi.Student ON tpdm.Candidate.PersonId = edfi.Student.PersonId
  LEFT OUTER JOIN tpdm.FinancialAid  ON edfi.Student.StudentUSI = tpdm.FinancialAid.StudentUSI
  LEFT OUTER JOIN edfi.Descriptor AidDescriptor on tpdm.FinancialAid.AidTypeDescriptorId = AidDescriptor.DescriptorId