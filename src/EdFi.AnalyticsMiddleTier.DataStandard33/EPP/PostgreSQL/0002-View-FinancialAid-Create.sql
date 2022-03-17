-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS analytics.EPP_FinancialAidFact;

CREATE VIEW analytics.EPP_FinancialAidFact AS

---Financial Aid
SELECT   tpdm.Candidate.CandidateIdentifier
		,tpdm.FinancialAid.BeginDate
		,tpdm.FinancialAid.EndDate
		,COALESCE(tpdm.FinancialAid.AidConditionDescription,'') as AidConditionDescription
		,AidDescriptor.CodeValue as AidType
		,COALESCE(tpdm.FinancialAid.AidAmount,0) as AidAmount
		,COALESCE(tpdm.FinancialAid.PellGrantRecipient,false) as PellGrantRecipient
		,(SELECT MAX(MaxLastModifiedDate)  FROM
                (VALUES(Candidate.LastModifiedDate), (FinancialAid.LastModifiedDate)
                ) AS VALUE(MaxLastModifiedDate)
		 ) As LastModifiedDate
		FROM tpdm.Candidate
  INNER JOIN edfi.Student ON tpdm.Candidate.PersonId = edfi.Student.PersonId
  LEFT OUTER JOIN tpdm.FinancialAid  ON edfi.Student.StudentUSI = tpdm.FinancialAid.StudentUSI
  LEFT OUTER JOIN edfi.Descriptor AidDescriptor on tpdm.FinancialAid.AidTypeDescriptorId = AidDescriptor.DescriptorId;